using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GeometrieDemo
{
    public interface IGeometrie
    {
        double surface();
        double perimetre();
    }



    public class Point
    {
        private int x;
        private int y;

        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point symetrique()
        {
            Point point = new Point();
            return point;
            //return new Point (-1 * this._x, -1 * this._y);
        }
        public bool coincide(Point p)
        {
            return true;
            //return (this._x == p._x) && (this._y == p.y)
        }

        public override string ToString()
        {
            return base.ToString();
            //return "(" + this._x. ToString() + "," + this._y")"
        }
    }



    public abstract class FormGeo : IGeometrie
    {
        private Point p = new Point();

        abstract public double surface();
        abstract public double perimetre();

        public Point P
        {
            get { return p; }
            set { p = value; }
        }
        
        protected FormGeo()
        {
        }

        protected FormGeo(Point p)
        {
            this.p = p;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }



    class Cercle : FormGeo
    {
        private double rayon;

        public double Rayon
        {
            get { return rayon; }
            set { rayon = value; }
        }

        public Cercle()
        {
        }

        public Cercle(double rayon, Point p) : base(p)
        {
            this.rayon = rayon;
        }

        public override double surface()
        {
            return Math.PI * rayon * rayon;
        }
        public override double perimetre()
        {
            return 2 * Math.PI * rayon;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cercle de centre : ");
            sb.AppendLine(base.P.ToString());
            sb.AppendFormat("rayon : {0}\n", this.rayon);
            sb.Append("Surface : ");
            sb.AppendLine(this.surface().ToString());
            sb.Append("Perimetre : ");
            sb.AppendLine(this.perimetre().ToString());
            return sb.ToString();
        }
    }



    class Rectangle : FormGeo
    {
        private Point p;
        protected double longueur;
        protected double largeur;

        public double Longueur { get => longueur; set => Longueur = value; }
        public double Largeur { get => largeur; set => largeur = value; }

        public Rectangle(double longueur, double largeur, Point p)
        {
            this.longueur = longueur;
            this.largeur = largeur;
        }

        public override double surface()
        {
            return longueur * largeur;
        }
        public override double perimetre()
        {
            return 2 * (longueur + largeur);
        }

        public override string ToString()
        {
            //return base.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append("Rectangle de coin sup gauche : ");
            sb.AppendLine(base.P.ToString());
            sb.AppendFormat("Longueur : {0}\n", this.longueur);
            sb.AppendFormat("Largeur : {0}\n", this.largeur);
            sb.Append("Surface : ");
            sb.AppendLine(this.surface().ToString());
            sb.Append("Perimetre : ");
            sb.AppendLine(this.perimetre().ToString());
            return sb.ToString();
        }
    }



    class Carre : Rectangle
    {
        private double cote
        {
            get
            {
                return this.largeur;
            }
            set
            {
                this.largeur = value;
                this.longueur = value;
            }
        }

        public Carre(double cote, Point p) : base(cote, cote, p)
        {
            this.cote = cote;
        }

        public override double surface()
        {
            return longueur * largeur;
        }
        public override double perimetre()
        {
            return 2 * (longueur + largeur);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Carre de coin sup gauche : ");
            sb.AppendLine(base.P.ToString());
            sb.AppendFormat("cote : {0}\n", this.cote);
            sb.Append("Surface : ");
            sb.AppendLine(this.surface().ToString());
            sb.Append("Perimetre : ");
            sb.AppendLine(this.perimetre().ToString());
            return sb.ToString();
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Choisissez la forme à calculer");
            WriteLine("1: RECTANGLE");
            WriteLine("2: CERCLE");
            WriteLine("3: CARRE");
            string figure = ReadLine();

            switch (figure)
            {
                case "1":
                    WriteLine("RECTANGLE");

                    WriteLine("Saisissez la position x du rectangle");
                    int position1 = int.Parse(ReadLine());
                    WriteLine("Saisissez la position y du rectangle");
                    int position2 = int.Parse(ReadLine());
                    Point p1 = new Point(position1, position2);

                    WriteLine("Veuillez saisir une longeur");
                    int saisie1 = int.Parse(ReadLine());
                    WriteLine("Veuillez saisir une largeur");
                    int saisie2 = int.Parse(ReadLine());
                    Rectangle rectangle = new Rectangle(saisie1, saisie2, p1);
                    WriteLine($"Le périmetre du rectangle est  : {rectangle.perimetre()} et la surface est : {rectangle.surface()}");

                    ReadKey();
                    break;

                case "2":
                    WriteLine("CERCLE");

                    WriteLine("Saisissez la position x du rectangle");
                    int position3 = int.Parse(ReadLine());
                    WriteLine("Saisissez la position y du rectangle");
                    int position4 = int.Parse(ReadLine());
                    Point p2 = new Point(position3, position4);

                    WriteLine("Veuillez saisir le rayon du cercle");
                    int saisie = int.Parse(ReadLine());
                    Cercle cercle = new Cercle(saisie, p2);
                    WriteLine($"Le périmetre du cercle est : { cercle.perimetre()} et la surface est : {cercle.surface()}");

                    ReadKey();
                    break;

                case "3":
                    WriteLine("CARRE");

                    WriteLine("Saisissez la position x du rectangle");
                    int position5 = int.Parse(ReadLine());
                    WriteLine("Saisissez la position y du rectangle");
                    int position6 = int.Parse(ReadLine());
                    Point p3 = new Point(position5, position6);
                    WriteLine("Merci de saisir le côté Carré");

                    int saisieC = int.Parse(ReadLine());
                    Cercle carre = new Cercle(saisieC, p3);
                    WriteLine($"Le périmetre du carré est : { carre.perimetre()} et la surface est : {carre.surface()}");

                    ReadKey();
                    break;

                default:
                    WriteLine("Veuillez saisir un numéro correct");
                    break;
            }

            ReadKey();
        }
    }
}
