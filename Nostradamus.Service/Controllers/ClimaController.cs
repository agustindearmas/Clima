using Newtonsoft.Json;
using Nostradamus.Negocio.Managers;
using System;
using System.Web.Http;

namespace Nostradamus.Service.Controllers
{
    public class ClimaController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                PrediccionManager pm = new PrediccionManager();
                dynamic answer = pm.PredecirClima();
                return Ok(JsonConvert.SerializeObject(answer));
            }
            catch (Exception e)
            {
                return InternalServerError(e);

            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {

                PrediccionManager pm = new PrediccionManager();
                dynamic answer = pm.ObtenerPronostico(id);
                return Ok(JsonConvert.SerializeObject(answer));
            }
            catch (Exception e)
            {
                return InternalServerError(e);

            }
        }
    }
}
