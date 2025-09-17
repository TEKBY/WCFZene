using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFZene.Controllers;
using WCFZene.Models;

namespace WCFZene
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string DeleteEloado(int id)
        {
            throw new NotImplementedException();
        }

        public List<Eloado> GetEloadok()
        {
            return new EloadoController().EloadokListaja();
        }

        public string InsertEloado(Eloado eloado)
        {
            throw new NotImplementedException();
        }

        public string UpdateEloado(Eloado eloado)
        {
            throw new NotImplementedException();
        }
    }
}
