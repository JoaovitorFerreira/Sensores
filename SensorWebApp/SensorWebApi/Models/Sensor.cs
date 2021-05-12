using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorWebAPI.Models
{
    public class Sensor
    {
        [JsonProperty("Id")]
        private string Id;
        [JsonProperty("Tag")]
        private string Tag;
        [JsonProperty("Status")]
        private StatusEvento Status;
        [JsonProperty("Valor")]
        private string Valor;
        [JsonProperty("Timestamp")]
        private DateTime Timestamp;

        public Sensor(string tag, String valor, long unixTimestamp){

            try
            {
                Guid guid = Guid.NewGuid();

                var validateTag = tag.Split('.').Count() == 3;
                if (validateTag)
                {

                    this.Id = guid.ToString();
                    this.Tag = tag;
                    SetStatus(valor);
                    this.Valor = valor;
                    SetTimestamp(unixTimestamp);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        //getters
        public string GetId()
        {
            return this.Id;
        }
        public string GetTag()
        {
            return this.Tag;
        }
        public StatusEvento GetStatus()
        {
            return this.Status;
        }
        public string GetValor()
        {
            return this.Valor;
        }
        public DateTime GetTimestamp()
        {
            return this.Timestamp;
        }

        //setters
        public void SetId(string id)
        {
            this.Id = id;
        }
        public void SetTag(string tag)
        {
            this.Tag = tag;
        }
        public void SetValor(String valor)
        {
            if (valor.Equals(null))
            {
                this.Valor = "";
            }
            this.Valor = valor;
        }

        //setter modificado para poder permitir uma validacao de status do evento sem inserir manualmente.
        public void SetStatus(String valorRecebido)
        {


            if (valorRecebido.Equals(null) || valorRecebido =="")
            {
                this.Status = StatusEvento.Erro;
            }
            else
            {
                this.Status = StatusEvento.Processado;
            }
            
        }

        //setter modificado para poder permitir alteracao de unixtimestamp na API
        public void SetTimestamp(long unixTimestamp)
        {
            //conversao de unix long para datetime

            DateTime dateTimeConverter = DateTimeOffset.FromUnixTimeMilliseconds(unixTimestamp).UtcDateTime;
            this.Timestamp = dateTimeConverter;
        }

        //funcoes extras

        public string GetNomeSensor()
        {
            string[] words= this.Tag.Split('.');
            string name = words.GetValue(2).ToString();
            return name;

        }

    }

    public enum StatusEvento
    {
        Erro =0,
        Processado=1
    }
}
