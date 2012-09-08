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

namespace ProjectBeaver
{
	public partial class FindTreePage : PhoneApplicationPage
	{
		public static MainPage mainPage { get; set; }
		public static List<Tree> trees { get; set; }

		public FindTreePage()
		{
			InitializeComponent();
		}

		private void FindNorwayMaples_Click(object sender, RoutedEventArgs e)
		{
			var norwayMaples =
				from t in trees
				where t.NameAcronym == "ACPL"
				select t;

			mainPage.SetTreePins(norwayMaples.ToList(), "Norway Maple");
		}

		private void FindHomesteadElms_Click(object sender, RoutedEventArgs e)
		{
			var homesteadElms =
				from t in trees
				where t.NameAcronym == "ULXXHO"
				select t;

			mainPage.SetTreePins(homesteadElms.ToList(), "Homestead Elms");
		}

		private void button3_Click(object sender, RoutedEventArgs e)
		{
			var commonHackberry =
				from t in trees
				where t.NameAcronym == "CEOC"
				select t;

			mainPage.SetTreePins(commonHackberry.ToList(), "Common Hackberry");
		}
	}
}