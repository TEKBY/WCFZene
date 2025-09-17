using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFZene.Models
{
    [DataContract]
    public class Eloado
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nev { get; set; }
        [DataMember]
        public string Nemzetiseg { get; set; }
        [DataMember]
        public bool Szolo { get; set; }

        
    }
}