using MathNet.Spatial.Euclidean;
using Nostradamus.Negocio.Model;
using Nostradamus.Negocio.Model.Enum;
using System.Collections.Generic;



namespace Nostradamus.Negocio.ClimaStrategy
{
    public class ClimaStrategyManager
    {
        private readonly List<IPeriodoStrategy> estrategias = new List<IPeriodoStrategy>();
        public AuxiliarPronostico ObtenerPrediccion(List<Planeta> planetas, Point2D posicionDelSol)
        {
            AuxiliarPronostico auxiliarPronostico = null;

            estrategias.Add(new PeriodoLluviosoStrategy());
            estrategias.Add(new PeriodoOptimoStrategy());
            estrategias.Add(new PeriodoSecoStrategy());
            
            foreach (var est in estrategias)
            {
                if (est.ValidarAuxiliarPronostico(planetas, posicionDelSol))
                {
                    auxiliarPronostico = est.ObtenerAuxiliarPronostico(planetas);
                    return auxiliarPronostico;
                }
                else
                {
                    auxiliarPronostico = new AuxiliarPronostico(PeriodoEnum.Indefinido);
                }                
            }
            return auxiliarPronostico;            
        }
    }
}
