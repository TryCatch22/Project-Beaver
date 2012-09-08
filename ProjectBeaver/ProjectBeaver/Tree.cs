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
		public int BoroughCode { get; set; }
		public string BoroughName { get; set; }
		public string StreetName { get; set; }
		public string StreetSide { get; set; }
		public int StreetAddress { get; set; }
		public int LocationNumber { get; set; }
		public string LocationType { get; set; }
		public Point Coordinates { get; set; }
		public string NameAcronym { get; set; }
		public string NameLatin { get; set; }
		public string NameFrench { get; set; }
		public string NameEnglish { get; set; }
		public int Diameter { get; set; }
		public DateTime DateDiameterUpdate { get; set; }
		public DateTime DatePlantation { get; set; }
		public string Property { get; set; }
		public bool Remarkable { get; set; }
		public double DistanceSidewalk { get; set; }
		public string Localisation { get; set; }
		public string Obstacle { get; set; }
		public string ParkCode { get; set; }
		public string ParkName { get; set; }
		public int SectorCode { get; set; }
		public string SectorName { get; set; }

		public Tree()
		{

		}

		public Tree(string[] elements)
		{
			Inventory = elements[0];
			BoroughCode = int.Parse(elements[1]);
			BoroughName = elements[2];
			StreetName = elements[3];
			StreetSide = elements[4];
			StreetAddress = int.Parse(elements[5]);
			LocationNumber = int.Parse(elements[6]);
			LocationType = elements[7];
			Coordinates = new Point(double.Parse(elements[8]), double.Parse(elements[9]));
			NameAcronym = elements[10];
			NameLatin = elements[11];
			NameFrench = elements[12];
			NameEnglish = elements[13];
			Diameter = int.Parse(elements[14]);
			DateDiameterUpdate = DateTime.Parse(elements[15]);
			DatePlantation = DateTime.Parse(elements[16]);
			Property = elements[17];
			if (elements[18].Equals("O"))
				Remarkable = true;
			else
				Remarkable = false;
			DistanceSidewalk = double.Parse(elements[19]);
			Localisation = elements[20];
			Obstacle = elements[21];
			ParkCode = elements[22];
			ParkName = elements[23];
			SectorCode = int.Parse(elements[24]);
			SectorName = elements[25];
		}

		public static IList<Tree> ParseCsv()
		{
			List<Tree> trees = new List<Tree>();

			IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();

			using (StreamReader file = new StreamReader(new IsolatedStorageFileStream("TreeData.csv", FileMode.Open, FileAccess.Read, FileShare.Read, isf)))
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
