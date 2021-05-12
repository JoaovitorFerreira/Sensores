using Microsoft.AspNetCore.Mvc;
using SensorWebAPI.Models;
using SensorWebAPI.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using SensorWebApi.Models;

namespace SensorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SensorController : ControllerBase
    {
        // GET api/sensor
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<List<Sensor>> Get()
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {
                var result = sensorDao.GetAllSensores();
                Response.StatusCode = 200;
                return result;

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }

        // GET api/sensor/5
        [HttpGet("{id}")]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<Sensor> Get(string id)
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {
                var result = sensorDao.GetSensorById(id);
                if (result == null)
                {
                    Response.StatusCode = 404;
                    return Content("Não encontrado sensor com o id:" + id);

                }
                Response.StatusCode = 200;
                return result;

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }

        // GET api/sensor/listNames
        [HttpGet("listnames")]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<List<string>> GetNomeSensores()
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {
                var result = sensorDao.GetSensoresNames();
                if (result == null)
                {
                    Response.StatusCode = 404;
                    return Content("Não encontrado");

                }
                Response.StatusCode = 200;
                return result;

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }


        // GET api/sensor/tag/
        [HttpGet("tag/{tag}")]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<List<Sensor>> GetTag(string tag)
        {
            SensorDAO sensorDao = SensorDAO.Instancia();

            try
            {
                var result = sensorDao.GetSensoresByTag(tag.ToLower());
                if (result == null)
                {
                    Response.StatusCode = 404;
                    return Content("Não encontrado sensor com tag:" + tag.ToLower());

                }
                Response.StatusCode = 200;
                return result;

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }

        // GET api/sensor/graficos/total/
        [HttpGet("graficos/total")]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<long> GetTotal()
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {
                var result = sensorDao.GetTotalSensores();
                Response.StatusCode = 200;
                return result;

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }

        // GET api/sensor/graficos/regiao/total
        [HttpGet("graficos/{regiao}/total/")]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<long> GetTotalPorRegiao(string regiao)
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {
                var result = sensorDao.GetTotalPerRegion(regiao.ToLower());
                Response.StatusCode = 200;
                return result;

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }
        // GET api/sensor/graficos/regiao/total
        [HttpGet("graficos/regioes/total/")]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<List<RegionSensors>> GetRegiaoSensores()
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {
                var result = sensorDao.GetRegionsTotal();

                return result;
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }

        // GET api/sensor/sensor/total
        [HttpGet("{sensor}/total")]
        [EnableCors("AllowAnyOrigin")]
        public ActionResult<long> GetTotalPorSensor(string sensor)
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {
                var result = sensorDao.GetTotalPerSensor(sensor.ToLower());
                Response.StatusCode = 200;
                return result;

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return Content(e.Message);
            }
        }

        // POST api/sensor
        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        public void Post([FromBody] Sensor sensor)
        {
            SensorDAO sensorDao = SensorDAO.Instancia();
            try
            {

                var result = sensorDao.PostSensor(sensor);
                Response.StatusCode = 200;
                Content("Sensor de tag: " + sensor.GetTag() + " criado com sucesso");

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                Content(e.Message);
            }

        }

    }
}
