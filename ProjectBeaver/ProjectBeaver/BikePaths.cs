using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Microsoft.Phone.Controls.Maps;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Device.Location;
using System.Diagnostics;

namespace ProjectBeaver
{
    public class BikePaths
    {
        public IList<LocationCollection> Paths { get; private set; }

        public BikePaths()
        {
            Paths = new List<LocationCollection>();
            string xmlString;

            // Load the bike paths in memory.
            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri("Data/BikePaths.kml", UriKind.Relative)).Stream))
            {
                xmlString = reader.ReadToEnd();
            }

            // Parse the bike paths into a list of GeoCoordinates.
            XElement xmlContent = XElement.Load(Application.GetResourceStream(new Uri("Data/BikePaths.kml", UriKind.Relative)).Stream);
            XNamespace xmlNamespace = "http://www.opengis.net/kml/2.2";

            var coordinates =
                from placemark in xmlContent.Descendants(xmlNamespace + "Placemark")
                select placemark.Descendants(xmlNamespace + "coordinates").First().Value;

            foreach (var coordinate in coordinates)
	        {
                var points = coordinate.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var collection = new LocationCollection();
                
                foreach (var point in points)
                {
                    // Get the longitude and latitude out of the string and store it in a way the map can process.
                    var data = point.Split(',');
                    double longitude;
                    double latitude;

                    if (double.TryParse(data[0], out longitude) && double.TryParse(data[1], out latitude))
                    {
                        collection.Add(new GeoCoordinate(latitude, longitude));
                    }
                }

                Paths.Add(collection);
	        }

        }

        public void AddPathsToMap(Map map)
        {
            MapPolyline line;

            foreach (var path in this.Paths)
            {
                line = new MapPolyline();
                line.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                line.StrokeThickness = 5;
                line.Locations = path;

                map.Children.Add(line);
            }
            
        }
    }
}