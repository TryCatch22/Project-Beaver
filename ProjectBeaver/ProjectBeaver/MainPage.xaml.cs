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

namespace ProjectBeaver
{
	public partial class MainPage : PhoneApplicationPage
	{
        private IList<Tree> trees;

		// Constructor
		public MainPage()
		{
			InitializeComponent();
            trees = Tree.ParseCsv("L2P_0_UCOUTGU_801_26062012_111306_GLC_3211912_VILLEMARIE.csv");
		}

		// Simple button Click event handler to take us to the second page
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
		}

		private void buttonRoad_Click(object sender, RoutedEventArgs e)
		{
			map1.Mode = new RoadMode();
		}
		
		private void buttonAerial_Click(object sender, RoutedEventArgs e)
		{
			map1.Mode = new AerialMode();
		}

		private void buttonZoomIn_Click(object sender, RoutedEventArgs e)
		{
			double zoom;
			zoom = map1.ZoomLevel;
			map1.ZoomLevel = ++zoom;
		}

		private void buttonZoomOut_Click(object sender, RoutedEventArgs e)
		{
			double zoom;
			zoom = map1.ZoomLevel;
			map1.ZoomLevel = --zoom;
		}		
	}
}