using MathNet.Spatial.Euclidean;
using Nostradamus.Negocio.Helpers;
using System;

namespace Nostradamus.Negocio.Model
{
    public class Planeta
    {
        public int IdPlaneta {get; set;}
        public string Descripcion { get; set; }
        public double Desplazamiento { get; set; }
        public double DistanciaDelSol { get; set; }
        public double PosicionAngular { get; set; }
        public bool SentidoAntiHorario { get; set; }

        public Point2D ObtenerPosicionCartesiana()
        {
            double X = Math.Cos(MathHelper.ConvertirARadianes(PosicionAngular)) * DistanciaDelSol;
            double Y = Math.Sin(MathHelper.ConvertirARadianes(PosicionAngular)) * DistanciaDelSol;        
            return new Point2D(X, Y);
        }

        public void Moverse()
        {
            PosicionAngular += Desplazamiento;
            if (Math.Abs(PosicionAngular) >= 360.0)
            {
                if (PosicionAngular > 0.0)
                {
                    PosicionAngular -= 360.0;
                }
                else
                {
                    PosicionAngular += 360.0;
                }
            }
        }

        public double DistanciaDe(Planeta planeta)
        {
            return ObtenerPosicionCartesiana().DistanceTo(planeta.ObtenerPosicionCartesiana());
        }
    }
}
