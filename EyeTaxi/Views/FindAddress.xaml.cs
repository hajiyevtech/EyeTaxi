﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;

namespace EyeTaxi.Views
{
    
    public partial class FindAddress : Page
    {
        // Addresses for suggestion.
        private readonly string[] _addresses =
        {
            "277 N Avenida Caballeros, Palm Springs, CA",
            "380 New York St, Redlands, CA 92373",
            "Ð‘ÐµÐ¾Ð³Ñ€Ð°Ð´",
            "ÐœÐ¾ÑÐºÐ²Ð°",
            "åŒ—äº¬"
        };

        // The LocatorTask provides geocoding services
        private LocatorTask _geocoder;

        // Service Uri to be provided to the LocatorTask (geocoder)
        private Uri _serviceUri = new Uri("https://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer");

        public FindAddress()
        {
            InitializeComponent();

            // Setup the control references and execute initialization
            Initialize();
        }

        private async void Initialize()
        {
            // Create new Map with basemap
            Map myMap = new Map(BasemapStyle.ArcGISImagery);

            // Provide used Map to the MapView
            MyMapView.Map = myMap;

            // Set addresses as items source
            SearchBox.ItemsSource = _addresses;

            // Enable tap-for-info pattern on results
            MyMapView.GeoViewTapped += MyMapView_GeoViewTapped;

            // Initialize the LocatorTask with the provided service Uri
            try
            {
                _geocoder = await LocatorTask.CreateAsync(_serviceUri);

                // Enable UI controls now that the LocatorTask is ready
                SearchBox.IsEnabled = true;
                SearchButton.IsEnabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }

        private async void UpdateSearch()
        {
            // Get the text in the search bar
            string enteredText = SearchBox.Text;

            // Clear existing marker
            MyMapView.GraphicsOverlays.Clear();

            // Return gracefully if the textbox is empty or the geocoder isn't ready
            if (String.IsNullOrWhiteSpace(enteredText) || _geocoder == null) { return; }

            try
            {
                // Get suggestions based on the input text
                IReadOnlyList<> suggestions = await _geocoder.SuggestAsync(enteredText);

                // Stop gracefully if there are no suggestions
                if (suggestions.Count < 1) { return; }

                // Get the full address for the first suggestion
                SuggestResult firstSuggestion = suggestions.First();
                IReadOnlyList addresses = await _geocoder.GeocodeAsync(firstSuggestion.Label);

                // Stop gracefully if the geocoder does not return a result
                if (addresses.Count < 1) { return; }

                // Place a marker on the map - 1. Create the overlay
                GraphicsOverlay resultOverlay = new GraphicsOverlay();
                // 2. Get the Graphic to display
                Graphic point = await GraphicForPoint(addresses.First().DisplayLocation);
                // 3. Add the Graphic to the GraphicsOverlay
                resultOverlay.Graphics.Add(point);
                // 4. Add the GraphicsOverlay to the MapView
                MyMapView.GraphicsOverlays.Add(resultOverlay);

                // Update the map extent to show the marker
                MyMapView.SetViewpoint(new Viewpoint(addresses.First().Extent));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }

        /// 
        /// Creates and returns a Graphic associated with the given MapPoint
        /// 
        private async Task GraphicForPoint(MapPoint point)
        {
            // Get current assembly that contains the image
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            // Get image as a stream from the resources
            // Picture is defined as EmbeddedResource and DoNotCopy
            Stream resourceStream = currentAssembly.GetManifestResourceStream(
                "ArcGISRuntime.Resources.PictureMarkerSymbols.pin_star_blue.png");

            // Create new symbol using asynchronous factory method from stream
            PictureMarkerSymbol pinSymbol = await PictureMarkerSymbol.CreateAsync(resourceStream);
            pinSymbol.Width = 60;
            pinSymbol.Height = 60;
            // The image is a pin; offset the image so that the pinpoint
            //     is on the point rather than the image's true center
            pinSymbol.LeaderOffsetX = 30;
            pinSymbol.OffsetY = 14;
            return new Graphic(point, pinSymbol);
        }

        private void OnSuggestionChosen(object sender, SelectionChangedEventArgs e)
        {
            // Return if the user is typing.
            if (SearchBox.SelectedValue == null)
            {
                return;
            }

            // Update the search
            SearchBox.Text = SearchBox.SelectedValue.ToString();
            UpdateSearch();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateSearch();
        }

        /// 
        /// Handle tap event on the map; displays callouts showing the address for a tapped search result
        /// 
        private async void MyMapView_GeoViewTapped(object sender, GeoViewInputEventArgs e)
        {
            try
            {
                // Search for the graphics underneath the user's tap
                IReadOnlyList results = await MyMapView.IdentifyGraphicsOverlaysAsync(e.Position, 12, false);

                // Return gracefully if there was no result
                if (results.Count < 1 || results.First().Graphics.Count < 1) { return; }

                // Reverse geocode to get addresses
                IReadOnlyList addresses = await _geocoder.ReverseGeocodeAsync(e.Location);

                // Get the first result
                GeocodeResult address = addresses.First();
                // Use the city and region for the Callout Title
                string calloutTitle = address.Attributes["City"] + ", " + address.Attributes["Region"];
                // Use the metro area for the Callout Detail
                string calloutDetail = address.Attributes["MetroArea"].ToString();

                // Define the callout
                CalloutDefinition calloutBody = new CalloutDefinition(calloutTitle, calloutDetail);

                // Show the callout on the map at the tapped location
                MyMapView.ShowCalloutAt(e.Location, calloutBody);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}
