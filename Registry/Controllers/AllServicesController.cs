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
    public class AllServicesController : ApiController
    {
        interfaceConnect iconnect = new interfaceConnect();
        ServerInterface foob;


        // GET: Publish
        public IHttpActionResult Get(int token)
        {
            string filepath = @"C:/Users/osand/source/repos/DC_Assignment_01_OB_Hettiarachchi_20908883/Registry/Service/services.txt";
            StreamReader reader = new StreamReader(filepath);
            foob = iconnect.createchannel();
            string result = foob.validate(token);
            if (result.Equals("Authentication Successful"))
            {
                reader.Close();
                //send all services if token validated
                return Ok(File.ReadAllLines(filepath));
            }
            else
            {
                authentication authfail = new authentication("Denied", "Authentication Error");
                return Ok(authfail);
            }

        }
    }
}
