using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFZene.Models;

namespace WCFZene
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //CRUD operations for "Eloado" entity
        //Create
        [OperationContract]
        string InsertEloado(Eloado eloado);
        //Read
        [OperationContract]
        List<Eloado> GetEloadok();
        //Update
        [OperationContract]
        string UpdateEloado(Eloado eloado);
        //Delete
        [OperationContract]
        string DeleteEloado(int id);

        // TODO: Add your service operations here
    }
}
