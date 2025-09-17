using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFZene_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:3000");
            WebHttpBinding binding = new WebHttpBinding();
            using (ServiceHost host = new ServiceHost(typeof(WCFZene.Service1), uri))
            {
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(___.IService1), binding, "");
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                host.Open();
                Console.WriteLine($"A szerverem elindult: {DateTime.Now}");
                Console.ReadKey();
                host.Close();

            }

        }
    }
}
