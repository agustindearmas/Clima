using Nostradamus.Negocio.Model.Enum;
using System.Collections.Generic;

namespace Nostradamus.Negocio.Model
{
    public class Prediccion
    {
        private AuxiliarPronostico Mojado;

        private AuxiliarPronostico UltimoPronostico;

        private IDictionary<PeriodoEnum, long> Periodo = new Dictionary<PeriodoEnum, long>();

        public Prediccion()
        {
            Periodo.Add(PeriodoEnum.Indefinido, 0L);
            Periodo.Add(PeriodoEnum.Lluvioso, 0L);
            Periodo.Add(PeriodoEnum.Optimo, 0L);
            Periodo.Add(PeriodoEnum.Seco, 0L);
        }

        public void AgregarPronostico(AuxiliarPronostico pronostico)
        {
            if (UltimoPronostico == null || !UltimoPronostico.Equals(pronostico))
            {
                UltimoPronostico = pronostico;
                Periodo[pronostico.Periodo] = Periodo[pronostico.Periodo] + 1;
            }

            if (PeriodoEnum.Lluvioso == pronostico.Periodo)
            {
                if (Mojado == null || Mojado.PerimetroDelTriangulo < pronostico.PerimetroDelTriangulo)
                {
                    Mojado = pronostico;
                }
            }

       
        }

        public CondicionesMeteorologicas Concluir()
        {
            return new CondicionesMeteorologicas {
                CantidadPeriodosDeSequia = Periodo[PeriodoEnum.Seco],
                CantidadPeriodosDeLluvia = Periodo[PeriodoEnum.Lluvioso],
                CantidadPeriodosOptimos = Periodo[PeriodoEnum.Optimo],
                DiaMojado = Mojado == null ? 0L: Mojado.Dia                
            };
        }
    }
}
