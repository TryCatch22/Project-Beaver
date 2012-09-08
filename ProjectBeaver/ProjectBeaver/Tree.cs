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
        public Invent Inventory {get; set; }
        public int BoroughCode { get; set; }
        public string BoroughMame { get; set; }
        public string StreetMame { get; set; }
        public string StreetSide { get; set; }
        public int StreetAddress { get; set; }
        public int LocationNumber { get; set; }
        public TypeEmpl LocationType { get; set; }
        public Point Coordinates { get; set; }
        public string NameAcronym { get; set; }
        public string NameLatin { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public int Diameter { get; set; }
        public DateTime DateDiameterUpdate { get; set; }
        public DateTime DatePlantation { get; set; }
        public Propriete Property { get; set; }
        public bool Remarkable { get; set; }
        public double DistanceSidewalk { get; set; }
        public string Localisation { get; set; }
        public string Obstacle { get; set; }
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public int SectorCode { get; set; }
        public string SectorName { get; set; }
    }
}
