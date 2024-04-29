using System;

namespace Praktikumsaufgabe02_Klassen
{

    class CPoint
    {
        double x, y;



        public CPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Operatorüberladung für Multiplikation mit einem Skalar
        public static CPoint operator *(CPoint p, double scalar)
        {
            return new CPoint(p.x * scalar, p.y * scalar);
        }

        // Operatorüberladung für Subtraktion von zwei Vektoren
        public static CPoint operator -(CPoint p1, CPoint p2)
        {
            return new CPoint(p1.x - p2.x, p1.y - p2.y);
        }

        // Operatorüberladung für Umwandlung in einen Double (Vektorlänge)
        public static explicit operator double(CPoint p)
        {
            return Math.Sqrt(p.x * p.x + p.y * p.y);
        }

        // Operatorüberladung für Gleichheit von Punkten
        public static bool operator ==(CPoint p1, CPoint p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        // Operatorüberladung für Ungleichheit von Punkten
        public static bool operator !=(CPoint p1, CPoint p2)
        {
            return !(p1 == p2);
        }

        
        //Überschreibung der Equals-Methode
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CPoint other = (CPoint)obj;
            return this == other;
        }

        // Überschreibung der GetHashCode-Methode
        public override int GetHashCode()
        {
            return Tuple.Create(x, y).GetHashCode();
        }

        // Überschreibung der ToString-Methode für die Konsolenausgabe
        public override string ToString()
        {
            return $"({x},{y})";
        }
    }


    

    class Program
    {
        public static void Main()
        {
            CPoint p1 = new CPoint(2546, 39);
            CPoint p2 = p1 * 2; // Skalarprodukt (alle Komponenten werden mit dem Faktor multipliziert)
            CPoint p3 = p2 - p1; // Differenz zweier Vektoren
            double d = (double)p3; // Vektorlänge (mittels Konvertierung nach double)
            if (p2 - p1 == p1) 
                Console.WriteLine("Punkte sind gleich!");
            else 
                Console.WriteLine("Punkte sind nicht gleich!");
            Console.WriteLine(p2 * 3 - p1);
            Console.WriteLine(d);
        }
    }
}