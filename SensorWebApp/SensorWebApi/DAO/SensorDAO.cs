using SensorWebApi.Models;
using SensorWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorWebAPI.DAO
{
    public class SensorDAO
    {
        //controle de instancia, apenas para simulacao
        private static SensorDAO sensorDao = null;

        public static SensorDAO Instancia()
        {
            if (sensorDao == null)
            {
                sensorDao = new SensorDAO();
                
            }
            return sensorDao;
        }
        public void ResetaInstancia()
        {
             sensorDao = null;
        }
        //simulacao de um banco de dados
        private List<Sensor> sensores = new List<Sensor>
        {
            new Sensor("brasil.sudeste.sensor01","1",1539112021301),
            new Sensor("brasil.sudeste.sensor02","2",1539112021301),
            new Sensor("brasil.sudeste.sensor03","3",1539112021301),
            new Sensor("brasil.sudeste.sensor04","1",1539112021301),
            new Sensor("brasil.sudeste.sensor05","",1539112021301),
            new Sensor("brasil.sul.sensor06","6",1539112021301),
            new Sensor("brasil.sudeste.sensor07","recebido",1539112021301),
            new Sensor("brasil.sudeste.sensor08","3",1539112021301),
            new Sensor("brasil.sudeste.sensor01","recebido",1539112021301),
            new Sensor("brasil.sudeste.sensor01","atraso",1539113021301),
            new Sensor("brasil.nordeste.sensor01","3",1539112021301),
            new Sensor("brasil.sudeste.sensor04","4",1539114021301),
            new Sensor("brasil.sudeste.sensor05","2",1539112021301),
            new Sensor("brasil.sudeste.sensor03","1",1539132021301),
            new Sensor("brasil.centrooeste.sensor10","",1539112021301),
            new Sensor("brasil.norte.sensor18","3",1539112051301)
        };


        //Metodos da API

        //getAll
        public List<Sensor> GetAllSensores()
        {

            return sensores;
        }
        //getById
        public Sensor GetSensorById(string id)
        {
            try
            {
                Sensor sensor = sensores.Find(x => x.GetId().Contains(id));
                return sensor;
            }
            catch (ArgumentNullException)
            {

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //getSensoresByTag
        public List<Sensor> GetSensoresByTag(string tag)
        {
            try
            {
                List<Sensor> sensoresPorTag = new List<Sensor>();
                sensoresPorTag.AddRange(sensores.FindAll(x => x.GetTag().Contains(tag)));
                return sensoresPorTag;
            }
            catch (ArgumentNullException)
            {

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //getSensoresByTag
        public List<string> GetSensoresNames()
        {
            try
            {
                List<string> nomesSensores = new List<string>();
                foreach (var sensor in sensores)
                {
                    nomesSensores.Add(sensor.GetNomeSensor());
                    

                }


                return nomesSensores;
            }
            catch (ArgumentNullException)
            {

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        //getTotalPerRegion
        public long GetTotalPerRegion(string region)
        {
            try
            {
                List<Sensor> sensoresPorTag = new List<Sensor>();
                sensoresPorTag.AddRange(sensores.FindAll(x => x.GetTag().Contains(region)));
                var total = sensoresPorTag.Count();
                return total;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //getTotalPerRegion
        public List<RegionSensors> GetRegionsTotal()
        {
            try
            {
                List<RegionSensors> totalSensoresPorRegiao = new List<RegionSensors>();
                
                RegionSensors regiaoSudeste = new RegionSensors("sudeste", GetTotalPerSensor("sudeste"));
                RegionSensors regiaoNordeste = new RegionSensors("nordeste", GetTotalPerSensor("nordeste"));
                RegionSensors regiaoCentroOeste = new RegionSensors("centro oeste", GetTotalPerSensor("centrooeste"));
                RegionSensors regiaoSul = new RegionSensors("sul", GetTotalPerSensor("sul"));
                RegionSensors regiaoNorte = new RegionSensors("norte", GetTotalPerSensor("norte"));


                totalSensoresPorRegiao.Add(regiaoNordeste);
                totalSensoresPorRegiao.Add(regiaoNorte);
                totalSensoresPorRegiao.Add(regiaoCentroOeste);
                totalSensoresPorRegiao.Add(regiaoSul);
                totalSensoresPorRegiao.Add(regiaoSudeste);
                
                return totalSensoresPorRegiao;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //getTotalPerSensor
        public long GetTotalPerSensor(string sensor)
        {
            try
            {
                List<Sensor> sensoresPorTag = new List<Sensor>();
                sensoresPorTag.AddRange(sensores.FindAll(x => x.GetTag().Contains(sensor)));
                var total = sensoresPorTag.Count();
                return total;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //GetTotalValues
        public long GetTotalSensores()
        {
            try
            {
                var total = sensores.Count();
                return total;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //post
        public Sensor PostSensor(Sensor sensor)
        {
            try
            {
                sensores.Add(sensor);

                return sensor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

