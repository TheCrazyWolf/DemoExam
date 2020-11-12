using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShitSGK
{
    public class SerivceController
    {
       public List<ServiceW> ServiceWs { get; set; }
        
        public SerivceController()
        {
            ServiceWs = new List<ServiceW>();
            Database.masterEntities entities = new Database.masterEntities();
            List<Database.Service> services = entities.Service.ToList();

         
                services = entities.Service.ToList();
          
         
            foreach (var item in services)
            {
                ServiceW serviceW = new ServiceW(item);
                ServiceWs.Add(serviceW);

            }

        }

    }
}
