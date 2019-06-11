using System;
using System.Collections.Generic;
using MathNet.Spatial.Euclidean;
using Nostradamus.Negocio.Helpers;
using Nostradamus.Negocio.Model;
using Nostradamus.Negocio.Model.Enum;

namespace Nostradamus.Negocio.ClimaStrategy
{
    public class PeriodoLluviosoStrategy : IPeriodoStrategy
    {
        public AuxiliarPronostico ObtenerAuxiliarPronostico(List<Planeta> planetas)
        {
            if (planetas.Count >= 3)
            {
                Point2D a = planetas[0].ObtenerPosicionCartesiana();
                Point2D b = planetas[1].ObtenerPosicionCartesiana();
                Point2D c = planetas[2].ObtenerPosicionCartesiana();
                double perimetroDelTriangulo = MathHelper.CalcularPerimetroDelTriangulo(a,b,c);
                return new AuxiliarPronostico(PeriodoEnum.Lluvioso, perimetroDelTriangulo);
            }
            else
            {
                throw new Exception("Deben ser 3 planetas al menos");
            }
        }

        public bool ValidarAuxiliarPronostico(List<Planeta> planetas, Point2D posicionDelSol)
        {
            if (planetas.Count >= 3)
            {
                Point2D a = planetas[0].ObtenerPosicionCartesiana();
                Point2D b = planetas[1].ObtenerPosicionCartesiana();
                Point2D c = planetas[2].ObtenerPosicionCartesiana();
                if (!MathHelper.HayTriangulo(a, b, c))
                {
                    return false;
                }
                else
                {
                    return MathHelper.SolAdentro(a,b,c, new Point2D(0.0,0.0));
                }
                //double areaTrianguloABSOL = MathHelper.CalcularAreaTriangulo(a, b, posicionDelSol);
                //double areaTrianguloASOLC = MathHelper.CalcularAreaTriangulo(a, posicionDelSol, c);
                //double areaTrianguloSOLBC = MathHelper.CalcularAreaTriangulo(posicionDelSol, b, c);
                //double areaTrianguloABC = MathHelper.CalcularAreaTriangulo(a, b, c);

                //double sumaConSol = areaTrianguloABSOL + areaTrianguloASOLC + areaTrianguloSOLBC;
                //bool answer = MathHelper.CompararDouble(sumaConSol, areaTrianguloABC);
                //return answer;
            }
            else
            {
                throw new Exception("Deben ser 3 planetas al menos");
            }
        }
    }
}
