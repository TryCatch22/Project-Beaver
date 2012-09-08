using System;
using System.IO;
using System.IO.IsolatedStorage;
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
	public enum Invent
	{
		H = 0,
		R
	};

	public enum TypeEmpl
	{
		BanquetteGazonnee = 0,
		BanquetteAsphaltee,
		FondDeTrottoir,
		Parc,
		ParterreGazonne,
		ParterreAsphalte,
		Parterre,
		TerrePlein,
		Trottoir,
		Autre
	};

	public enum Propriete
	{
		Ville = 0,
		Copropriete,
		Prive
	};

	public enum Remarquable
	{
		N = 0,
		O
	};


	public class Tree
	{
		public string Inventory { get; set; }
		public int? BoroughCode { get; set; }
		public string BoroughName { get; set; }
		public string StreetName { get; set; }
		public string StreetSide { get; set; }
		public int? StreetAddress { get; set; }
		public int? LocationNumber { get; set; }
		public string LocationType { get; set; }
		public Point Coordinates { get; set; }
		public string NameAcronym { get; set; }
		public string NameLatin { get; set; }
		public string NameFrench { get; set; }
		public string NameEnglish { get; set; }
		public int? Diameter { get; set; }
		public DateTime? DateDiameterUpdate { get; set; }
		public DateTime? DatePlantation { get; set; }
		public string Property { get; set; }
		public bool Remarkable { get; set; }
		public double? DistanceSidewalk { get; set; }
		public string Localisation { get; set; }
		public string Obstacle { get; set; }
		public string ParkCode { get; set; }
		public string ParkName { get; set; }
		public int? SectorCode { get; set; }
		public string SectorName { get; set; }

		public Tree()
		{

		}

		public Tree(string[] elements)
		{
            int tempInt;
            double tempDouble1, tempDouble2;
            DateTime tempDateTime;
			Inventory = elements[0];
            if (int.TryParse(elements[1], out tempInt))
            {
                BoroughCode = tempInt;
            }
			BoroughName = elements[2];
			StreetName = elements[3];
			StreetSide = elements[4];
            if (int.TryParse(elements[5], out tempInt))
            {
                StreetAddress = tempInt;
            }
            if (int.TryParse(elements[6], out tempInt))
            {
                LocationNumber = tempInt;
            }
			LocationType = elements[7];
            if (double.TryParse(elements[8], out tempDouble1))
            {
                if (double.TryParse(elements[9], out tempDouble2))
                {
                    Coordinates = new Point(tempDouble1, tempDouble2);
                }
            }
			NameAcronym = elements[10];
			NameLatin = elements[11];
			NameFrench = elements[12];
			NameEnglish = elements[13];
            if (int.TryParse(elements[14], out tempInt))
            {
                Diameter = tempInt;
            }
            if (DateTime.TryParse(elements[15], out tempDateTime))
            {
                DateDiameterUpdate = tempDateTime;
            }
            if (DateTime.TryParse(elements[16], out tempDateTime))
            {
                DatePlantation = tempDateTime;
            } 
            Property = elements[17];
			if (elements[18].Equals("O"))
				Remarkable = true;
			else
				Remarkable = false;
            if (double.TryParse(elements[19], out tempDouble1))
            {
                DistanceSidewalk = tempInt;
            }
            Localisation = elements[20];
			Obstacle = elements[21];
			ParkCode = elements[22];
			ParkName = elements[23];
            if (int.TryParse(elements[24], out tempInt))
            {
                SectorCode = tempInt;
            }
            SectorName = elements[25];
		}

		public static IList<Tree> ParseCsv()
		{
			List<Tree> trees = new List<Tree>();

            // Read the contents of the tree data file
            using (StreamReader file = new StreamReader(Application.GetResourceStream(new Uri("Data/TreeData.csv", UriKind.Relative)).Stream))
            {
                string line;
                Tree newTree;
                while ((line = file.ReadLine()) != null)
                {
                    newTree = new Tree(line.Split(';'));
                    trees.Add(newTree);
                }
            }
			return trees;
		}
	}
}
