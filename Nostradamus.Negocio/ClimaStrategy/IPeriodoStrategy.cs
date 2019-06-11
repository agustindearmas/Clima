using MathNet.Spatial.Euclidean;
using Nostradamus.Negocio.Model;
using System.Collections.Generic;

namespace Nostradamus.Negocio.ClimaStrategy
{
    public interface IPeriodoStrategy
    {
        bool ValidarAuxiliarPronostico(List<Planeta> planetas, Point2D posicionDelSol);
        AuxiliarPronostico ObtenerAuxiliarPronostico(List<Planeta> planetas);
    }
}
