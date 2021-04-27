using Newtonsoft.Json;
using System;

namespace WPF.MonAppli.CoucheDonnees.Entities
{
    public class ModelBase
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        public string Document { get; set; }
    }
}