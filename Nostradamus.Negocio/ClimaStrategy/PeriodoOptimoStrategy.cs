using System;
using System.Collections.Generic;
using MathNet.Spatial.Euclidean;
using Nostradamus.Negocio.Helpers;
using Nostradamus.Negocio.Model;
using Nostradamus.Negocio.Model.Enum;

namespace Nostradamus.Negocio.ClimaStrategy
{
    public class PeriodoOptimoStrategy : IPeriodoStrategy
    {
        public AuxiliarPronostico ObtenerAuxiliarPronostico(List<Planeta> planetas)
        {
            return new AuxiliarPronostico(PeriodoEnum.Optimo);
        }

        public bool ValidarAuxiliarPronostico(List<Planeta> planetas, Point2D posicionDelSol)
        {
            if (planetas.Count >= 3)
            {
                Point2D a = planetas[0].ObtenerPosicionCartesiana();
                Point2D b = planetas[1].ObtenerPosicionCartesiana();
                Point2D c = planetas[2].ObtenerPosicionCartesiana();
                bool answer = MathHelper.HayTriangulo(a, b, c) ? false : MathHelper.HayTriangulo(a, b, posicionDelSol);
                return answer;
            }
            else
            {
                throw new Exception("Deben ser 3 planetas al menos");
            }
        }
    }
}
