using MathNet.Spatial.Euclidean;
using System;

namespace Nostradamus.Negocio.Helpers
{
    public static class MathHelper
    {
        public static double CalcularPerimetroDelTriangulo(Point2D a, Point2D b, Point2D c)
        {
            double distanciaAB = a.DistanceTo(b);
            double distanciaBC = b.DistanceTo(c);
            double distanciaCA = c.DistanceTo(a);
            return distanciaAB + distanciaBC + distanciaCA;
        }

        public static double ConvertirAGrado(double radianes)
        {
            return (radianes * 180) / Math.PI;
        }

        public static double ConvertirARadianes(double grados)
        {
            return (grados * Math.PI) / 180;
        }


        public static bool HayTriangulo(Point2D a, Point2D b, Point2D c)
        {
            return !CompararDouble(CalcularAreaTriangulo(a, b, c), 0.0);
        }

       
        public static double CalcularAreaTriangulo(Point2D a, Point2D b, Point2D c)
        {
            return Math.Abs((a.X - c.X) * (b.Y - a.Y)
                    - (a.X - b.X) * (c.Y - a.Y)) * 0.5;
        }

        public static bool SolAdentro(Point2D a, Point2D b, Point2D c, Point2D posicionDelSol)
        {
            bool signo1 = Signo(posicionDelSol,a,b) < 0.0;
            bool signo2 = Signo(posicionDelSol,b,c) < 0.0;
            bool signo3 = Signo(posicionDelSol,c,a) < 0.0;
            return ((signo1 == signo2) && (signo2 == signo3));
        }

        private static double Signo(Point2D a, Point2D b, Point2D c)
        {
            return (a.X - c.X) * (b.Y - c.Y) - (b.X - c.X) * (a.Y - c.Y);
        }

        public static bool CompararDouble(double a, double b)
        {
            double diferencia = Math.Abs(a * .00001);
            return Math.Abs(a - b) <= diferencia;
        }
    }
}