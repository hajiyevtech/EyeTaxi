﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
using Esri.ArcGISRuntime.UI;

namespace EyeTaxiAdmin.Views
{
    /// <summary>
    /// Interaction logic for Test2.xaml
    /// </summary>
    public partial class Test2 : Window
    {
        // Holds locations of hospitals around San Diego.
        private List<Facility> _facilities;

        // Graphics overlays for facilities and incidents.
        private GraphicsOverlay _facilityGraphicsOverlay;

        // Symbol for facilities.
        private PictureMarkerSymbol _facilitySymbol;

        // Overlay for the incident.
        private GraphicsOverlay _incidentGraphicsOverlay;

        // Black cross where user clicked.
        private MapPoint _incidentPoint;

        // Symbol for the incident.
        private SimpleMarkerSymbol _incidentSymbol;

        // Used to display route between incident and facility to mapview.
        private SimpleLineSymbol _routeSymbol;

        // Solves task to find closest route between an incident and a facility.
        private ClosestFacilityTask _task;

        public Test2()
        {
            InitializeComponent();

            // Create the map and graphics overlays.
            Initialize();
        }

        private async void Initialize()
        {
            // Hook up the DrawStatusChanged event.
            MyMapView.DrawStatusChanged += OnDrawStatusChanged;

            // Construct the map and set the MapView.Map property.
            Map map = new Map(BasemapStyle.ArcGISLightGray);
            MyMapView.Map = map;

            try
            {
                Esri.ArcGISRuntime.ArcGISRuntimeEnvironment.ApiKey = "AAPKbbf60ca566504f1b938d0c307ed2d1e9ykfeXs6T5VJxNRVsGCVVKn6UcwW0dpvtpGYgI1XE0mb08vvdAl6VKpGx9AY2rs5B";
                // Create a ClosestFacilityTask using the San Diego Uri.
                _task = await ClosestFacilityTask.CreateAsync(new Uri("https://route.arcgis.com/arcgis/rest/services/World/ClosestFacility/NAServer/ClosestFacility_World/solveClosestFacility"));

                // List of facilities to be placed around San Diego area.
                _facilities = new List<Facility> {
                    new Facility(new MapPoint(-1.3042129900625112E7, 3860127.9479775648, SpatialReferences.WebMercator)),
                    new Facility(new MapPoint(-1.3042193400557665E7, 3862448.873041752, SpatialReferences.WebMercator)),
                    new Facility(new MapPoint(-1.3046882875518233E7, 3862704.9896770366, SpatialReferences.WebMercator)),
                    new Facility(new MapPoint(-1.3040539754780494E7, 3862924.5938606677, SpatialReferences.WebMercator)),
                    new Facility(new MapPoint(-1.3042571225655518E7, 3858981.773018156, SpatialReferences.WebMercator)),
                    new Facility(new MapPoint(-1.3039784633928463E7, 3856692.5980474586, SpatialReferences.WebMercator)),
                    new Facility(new MapPoint(-1.3049023883956768E7, 3861993.789732541, SpatialReferences.WebMercator))
                };

                // Center the map on the San Diego facilities.
                Envelope fullExtent = GeometryEngine.CombineExtents(_facilities.Select(facility => facility.Geometry));
                await MyMapView.SetViewpointGeometryAsync(fullExtent, 50);

                // Create a symbol for displaying facilities.
                _facilitySymbol = new PictureMarkerSymbol(new Uri("https://static.arcgis.com/images/Symbols/SafetyHealth/Hospital.png"))
                {
                    Height = 30,
                    Width = 30
                };

                // Incident symbol.
                _incidentSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Cross, Color.FromArgb(255, 0, 0, 0), 30);

                // Route to hospital symbol.
                _routeSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, Color.FromArgb(255, 0, 0, 255), 5.0f);

                // Create Graphics Overlays for incidents and facilities.
                _incidentGraphicsOverlay = new GraphicsOverlay();
                _facilityGraphicsOverlay = new GraphicsOverlay();

                // Create a graphic and add to graphics overlay for each facility.
                foreach (Facility facility in _facilities)
                {
                    _facilityGraphicsOverlay.Graphics.Add(new Graphic(facility.Geometry, _facilitySymbol));
                }

                // Add each graphics overlay to MyMapView.
                MyMapView.GraphicsOverlays.Add(_incidentGraphicsOverlay);
                MyMapView.GraphicsOverlays.Add(_facilityGraphicsOverlay);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }

        private void OnDrawStatusChanged(object sender, DrawStatusChangedEventArgs e)
        {
            if (e.Status == DrawStatus.Completed)
            {
                // Link the action of tapping on the map with the MyMapView_GeoViewTapped method.
                MyMapView.GeoViewTapped += MyMapView_GeoViewTapped;

                // Remove this method from DrawStatusChanged events.
                MyMapView.DrawStatusChanged -= OnDrawStatusChanged;
            }
        }

        private void MyMapView_GeoViewTapped(object sender, Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            // Clear any prior incident and routes from the graphics.
            _incidentGraphicsOverlay.Graphics.Clear();

            // Get the tapped point.
            _incidentPoint = e.Location;

            // Populate the facility parameters than solve using the task.
            PopulateParametersAndSolveRouteAsync();
        }

        private async void PopulateParametersAndSolveRouteAsync()
        {
            try
            {
                // Set facilities and incident in parameters.
                ClosestFacilityParameters closestFacilityParameters = await _task.CreateDefaultParametersAsync();
                closestFacilityParameters.SetFacilities(_facilities);
                closestFacilityParameters.SetIncidents(new List<Incident> { new Incident(_incidentPoint) });

                // Use the task to solve for the closest facility.
                ClosestFacilityResult result = await _task.SolveClosestFacilityAsync(closestFacilityParameters);

                // Get the index of the closest facility to incident. (0) is the index of the incident, [0] is the index of the closest facility.
                int closestFacility = result.GetRankedFacilityIndexes(0)[0];

                // Get route from closest facility to the incident and display to mapview.
                ClosestFacilityRoute route = result.GetRoute(closestFacility, 0);

                // Add graphics for the incident and route.
                _incidentGraphicsOverlay.Graphics.Add(new Graphic(_incidentPoint, _incidentSymbol));
                _incidentGraphicsOverlay.Graphics.Add(new Graphic(route.RouteGeometry, _routeSymbol));
            }
            catch (Esri.ArcGISRuntime.Http.ArcGISWebException exception)
            {
                if (exception.Message.Equals("Unable to complete operation."))
                {
                    System.Windows.MessageBox.Show("Incident not within San Diego area!", "Sample error");
                }
                else
                {
                    System.Windows.MessageBox.Show("An ArcGIS web exception occurred. \n" + exception.Message.ToString(), "Sample error");
                }
            }
        }
    }

}
