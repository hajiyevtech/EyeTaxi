using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EyeTaxi.Annotations;
using Esri.ArcGISRuntime.Portal;
using System.Threading.Tasks;

namespace EyeTaxi.ViewModels
{
    class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {
            _ = SetupMap();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Map _map;
        public Map Map
        {
            get { return _map; }
            set
            {
                _map = value;
                OnPropertyChanged();
            }
        }

        private async Task SetupMap()
        {
            // Create a portal. If a URI is not specified, www.arcgis.com is used by default.
            ArcGISPortal portal = await ArcGISPortal.CreateAsync();

            // Get the portal item for a web map using its unique item id.
            PortalItem mapItem = await PortalItem.CreateAsync(portal, "41281c51f9de45edaf1c8ed44bb10e30");

            
            

            // Create the map from the item.
            Map map = new Map(mapItem);


            // To display the map, set the MapViewModel.Map property, which is bound to the map view.
            this.Map = map;

        }
    }
}
