using Nostradamus.Datos;
using Nostradamus.Negocio.Model;

namespace Nostradamus.Negocio.Managers
{
    public static class PronosticoManager
    {
        public static void SalvarPronostico (AuxiliarPronostico auxiliarPronosticos)
        {
            Pronostico pronostico = new Pronostico
            {
                Periodo = auxiliarPronosticos.Periodo.ToString(),
                Dia = auxiliarPronosticos.Dia
            };
            Contexto.Add("Pronostico", pronostico);
        }
    }
}
