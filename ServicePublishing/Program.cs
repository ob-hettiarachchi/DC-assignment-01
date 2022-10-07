using Authenticator;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.ServiceModel;
using System.Xml.Linq;

namespace ServicePublishing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            ImplementService imp = new ImplementService();
            interfaceConnect interCont = new interfaceConnect();
            ServerInterface serverInterface;
            customer cus = new customer();
            int exit = -1;
            while (exit <= 0)
            {
                Console.WriteLine("Service Publishing Console Online");
                Console.WriteLine("Select Option \n 1. Register \n 2. Login \n 3. Publish Services \n 4. Unpublish Services");
                Console.WriteLine("Choose Option :");
                userInput = int.Parse(Console.ReadLine());
                //Registration
                if (userInput == 1)
                {
                    Console.WriteLine("Enter Username :");
                    String name = Console.ReadLine();
                    Console.WriteLine("Enter Password :");
                    String Password = Console.ReadLine();
                    Console.WriteLine(imp.Register(name, Password));

                    serverInterface = interCont.createchannel();
                    int token;
                    string result = serverInterface.Register(name, Password);
                    if (result.Equals("Successfully Registered!"))
                    {
                        Console.WriteLine("======================= WELCOME =======================");
                        Console.WriteLine("User Succesfully Registered !");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                //Login
                else if (userInput == 2)
                {
                    Console.WriteLine("Enter Username");
                    String name = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    String Password = Console.ReadLine();
                    Console.WriteLine(imp.Login(name, Password));
                    serverInterface = interCont.createchannel();
                    int token = serverInterface.Login(name, Password);
                    if (token > 0)
                    {
                        Console.WriteLine("===================== WELCOME =========================");
                        Console.WriteLine("Successfully Loggedin : " + name);
                        cus.setToken(token);
                    }
                    else
                    {
                        Console.WriteLine("Sorry.. Username or password is incorrect... Please Try Again!");

                    }
                }
                //Publish Services
                else if (userInput == 3)
                {
                    //use restsharp restclient
                    Console.WriteLine("Enter Name Service : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Service Description : ");
                    string desc = Console.ReadLine();
                    Console.WriteLine("Enter API Endpoint : ");
                    string apiEndPoint = Console.ReadLine();
                    Console.WriteLine("Enter Number of Operands : ");
                    int noOfOperands = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Operand Type");
                    string operandType = Console.ReadLine();
                    registryService services = new registryService(name, desc, apiEndPoint, noOfOperands, operandType);
                    string json = JsonConvert.SerializeObject(services);
                    //API call to publish the service
                    string url = @"http://localhost:59849/api/Publish/?data=" + json + "&token=" + cus.getToken();
                    var clinet = new RestClient(url);
                    var request = new RestRequest();
                    var response = clinet.Post(request);
                    Console.WriteLine("Data Recived: " + response.Content.ToString());
                }
                //Unpublish services
                else if (userInput == 4)
                {
                    Console.WriteLine("Enter Service endpoint to unpublish the service: ");
                    string endpoint = Console.ReadLine();

                    string url = @"http://localhost:59849/api/Unpublish/?endpoint=" + endpoint + "&token=" + cus.getToken();
                    var client = new RestClient(url);
                    var request = new RestRequest();
                    var response = client.Get(request);



                    Console.WriteLine("Response : " + response.Content.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
