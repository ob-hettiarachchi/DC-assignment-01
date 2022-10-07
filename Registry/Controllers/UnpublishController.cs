using Authenticator;
using Newtonsoft.Json;
using Registry.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Registry.Controllers
{
    public class UnpublishController : ApiController
    {

        interfaceConnect iconnect = new interfaceConnect();
        ServerInterface foob;


        // GET: Publish
        public IHttpActionResult Get(string endpoint, int token)
        {

            foob = iconnect.createchannel();
            string result = foob.validate(token);
            if (result.Equals("Authentication Successful"))
            {
                string filepath = @"C:/Users/osand/source/repos/DC_Assignment_01_OB_Hettiarachchi_20908883/Registry/Service/services.txt";
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filepath).ToList();
                List<service> data2 = new List<service>();
                service services;
                service removedService = new service();

                foreach (string line in lines)
                {
                    services = new service();
                    services = JsonConvert.DeserializeObject<service>(line);
                    data2.Add(services);
                }

                lines.Clear();

                for (int i = 0; i < data2.Count; i++)
                {
                    if (data2[i].APIEndPoint.Equals(endpoint))
                    {
                        removedService = data2[i];
                        data2.RemoveAt(i);
                        break;
                    }
                }
                for (int i = 0; i < data2.Count; i++)
                {
                    string jsonstring = JsonConvert.SerializeObject(data2[i]);
                    lines.Add(jsonstring);
                }
                //add new list after removing the service to the file
                File.WriteAllLines(filepath, lines);
                return Ok(removedService);
            }
            else
            {
                authentication authfail = new authentication("Denied", "Authentication Error");
                return Ok(authfail);
            }

        }

    }
}
