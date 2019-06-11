
using Nostradamus.Negocio.Model;
using Nostradamus.Negocio.ClimaStrategy;

using MathNet.Spatial.Euclidean;

using System;
using System.Linq;
using System.Collections.Generic;
using Nostradamus.Datos;

namespace Nostradamus.Negocio.Managers
{
    public class PrediccionManager
    {
        private const double Grados = 360;
        private const int Años = 10;
        private long DiaActual = 0L;

        private readonly List<Planeta> planetas = Contexto.GetAll<Planeta>("Planeta");
        private readonly Point2D posicionDelSol = new Point2D(0.0, 0.0);
        public CondicionesMeteorologicas PredecirClima()
        {
            try
            {
                Contexto.MasiveDelete("Pronostico");
                Prediccion prediccion = new Prediccion();
                Dictionary<int, int> diasEnUnAño = new Dictionary<int, int>();              
               
                foreach (var p in planetas)
                {
                    diasEnUnAño.Add(p.IdPlaneta, Convert.ToInt32(CalcularDiasEnUnAño(p.Desplazamiento)));
                }
                
                int mayorCantidadDeDias = diasEnUnAño.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;
                int totalDeDias = mayorCantidadDeDias * Años;

                for (int i = 1; i <= totalDeDias; i++)
                {
                    AuxiliarPronostico auxiliarPronostico = ObtenerAuxiliarPronostico();
                    prediccion.AgregarPronostico(auxiliarPronostico);               
                }
                var answer = prediccion.Concluir();                    

                return answer;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public dynamic ObtenerPronostico(int dia)
        {
            try
            {
                if (dia <= (360 * 10))
                {
                    var answer = Contexto.GetById<Pronostico>(new { Dia = dia }, "Pronostico");
                    return new { answer.Dia, clima = answer.Periodo };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private AuxiliarPronostico ObtenerAuxiliarPronostico()
        {
            ClimaStrategyManager csm = new ClimaStrategyManager();
            AuxiliarPronostico auxiliarPronostico = csm.ObtenerPrediccion(planetas, posicionDelSol);
            auxiliarPronostico.Dia = DiaActual;
            foreach (var p in planetas)
            {
                p.Moverse();
            }
            DiaActual++;
            PronosticoManager.SalvarPronostico(auxiliarPronostico);
            return auxiliarPronostico;
        }

        private double CalcularDiasEnUnAño(double desplazamiento)
        {
            return Grados / Math.Abs(desplazamiento);
        }
    }
}
