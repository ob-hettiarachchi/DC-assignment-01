using Authenticator;
using Newtonsoft.Json;
using Registry.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace Registry.Controllers
{
    public class PublishController : ApiController
    {
        interfaceConnect iconnect = new interfaceConnect();
        ServerInterface foob;


        // GET: Publish
        public IHttpActionResult Post([FromUri()] string data, [FromUri()] int token)
        {

            foob = iconnect.createchannel();
            string result = foob.validate(token);
            if (result.Equals("Authentication Successful"))
            {
                string filepath = @"C:/Users/osand/source/repos/DC_Assignment_01_OB_Hettiarachchi_20908883/Registry/Service/services.txt";
                List<string> lines = new List<string>();
                service services = JsonConvert.DeserializeObject<service>(data);
                using (StreamWriter sw = new StreamWriter(filepath, append: true))
                {
                    sw.WriteLine(data);
                    sw.Close();
                }
                return Ok(services);
            }
            else
            {
                authentication authfail = new authentication("Denied", "Authentication Error");
                return Ok(authfail);
            }

        }

    }
}
