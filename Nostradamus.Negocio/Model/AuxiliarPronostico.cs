using Nostradamus.Negocio.Model.Enum;

namespace Nostradamus.Negocio.Model
{
    public class AuxiliarPronostico
    {
        public long Dia {get; set;}
        public PeriodoEnum Periodo { get; set; }
        public double PerimetroDelTriangulo { get; set; }

        public AuxiliarPronostico(PeriodoEnum periodo, double perimetroDelTriangulo)
        {
            Periodo = periodo;
            PerimetroDelTriangulo = perimetroDelTriangulo;
        }

        public AuxiliarPronostico(PeriodoEnum periodo)
        {
            Periodo = periodo;
            PerimetroDelTriangulo = 0.0;
        }

        public bool Equals(AuxiliarPronostico p)
        {
            return Periodo == p.Periodo;
        }
    }
}
