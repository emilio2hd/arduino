using System;
using System.Runtime.Serialization;

namespace LeitorDeClimaComArduino
{
    [DataContract]
    public class Clima
    {
        [DataMember(Name = "erro")]
        public string Erro { get; set; }
        [DataMember(Name = "umidade")]
        public string Umidade { get; set; }
        [DataMember(Name = "temperatura")]
        public string Temperatura { get; set; }
        public DateTime Data { get; set; }
    }
}
