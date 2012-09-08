using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;

namespace ProjectBeaver
{
	public partial class MainPage : PhoneApplicationPage
	{
        private IList<Tree> trees;

		// Constructor
		public MainPage()
		{
			InitializeComponent();
<<<<<<< HEAD
            trees = Tree.ParseCsv("L2P_0_UCOUTGU_801_26062012_111306_GLC_3211912_VILLEMARIE.csv");
		}
=======
>>>>>>> 24a57eaa9e145320d6ee289e76915fdae64e0e5d

			Map map = new Map();
			map.CredentialsProvider = new ApplicationIdCredentialsProvider("Atvj6eBBbDS6-dL7shp9KmzY-0v0NL2ETYCFoHIDzQwK8_9bJ2ZdRgeMAj0sDs_F");

			// Set the center coordinate and zoom level
			GeoCoordinate mapCenter = new GeoCoordinate(45.504693, -73.576494);
			int zoom = 15;

			// Create a pushpin to put at the center of the view
			Pushpin pin1 = new Pushpin();
			pin1.Location = mapCenter;
			pin1.Content = "McGill University";
			map.Children.Add(pin1);

			// Set the map style to Aerial
			map.Mode = new Microsoft.Phone.Controls.Maps.AerialMode();

			// Set the view and put the map on the page
			map.SetView(mapCenter, zoom);
			ContentPanel.Children.Add(map);
		}

		// Simple button Click event handler to take us to the second page
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
		}	
	}
}