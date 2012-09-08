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

namespace ProjectBeaver
{
    public class BikePaths
    {
        public IList<LocationCollection> Paths { get; private set; }

        public BikePaths()
        {
            // Try a polyline
            //MapPolyline line = new MapPolyline();
            //line.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
            //line.StrokeThickness = 5;
            //line.Locations = new LocationCollection {
                
            //    new GeoCoordinate(45.519119, -73.612232),
            //    new GeoCoordinate(45.520060, -73.611372),
            //    new GeoCoordinate(45.520704, -73.610769),
            //    new GeoCoordinate(45.521348, -73.610157)
            //};

            //map.Children.Add(line);
            Paths = new List<LocationCollection>();
            string xmlString;

            // Load the bike paths in memory.
            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri("Data/BikePaths.kml", UriKind.Relative)).Stream))
            {
                xmlString = reader.ReadToEnd();
            }

            // Parse the bike paths into a list of GeoCoordinates.
            XElement xmlContent = XElement.Load(Application.GetResourceStream(new Uri("Data/BikePaths.kml", UriKind.Relative)).Stream);

            var coordinates =
                from placemark in xmlContent.Descendants("xmlContent")
                select placemark.Element("coordinates").Value;
                
            foreach (var coordinate in coordinates)
	        {
                var points = coordinate.Split(' ');
                var collection = new LocationCollection();

                foreach (var point in points)
	            {
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
    }
}