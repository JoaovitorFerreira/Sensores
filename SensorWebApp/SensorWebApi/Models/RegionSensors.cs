using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorWebApi.Models
{
    public class RegionSensors
    {

        [JsonProperty("Regiao")]
        private string Regiao;
        [JsonProperty("Total")]
        private long Total;
        

        public RegionSensors(string regiao, long total)
        {
            this.Regiao = regiao;
                this.Total = total;
        }

        public string GetRegiao()
        {
            return this.Regiao;
        }
        public long GetTotal()
        {
            return this.Total;
        }

        //setters
        public void SetId(string regiao)
        {
            this.Regiao = regiao;
        }
        public void SetId(long total)
        {
            this.Total = total;
        }

    }
}
