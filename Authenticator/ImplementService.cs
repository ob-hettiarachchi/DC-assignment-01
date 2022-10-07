using System.Collections.Generic;
using System.ServiceModel;
using System;
using System.IO;
using System.Linq;
using System.Threading;

//OB Hettiarachchi - 20908883 - Assignment 01

namespace Authenticator
{
    //Make service multithreaded
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ImplementService : ServerInterface
    {
        //constructor
        public ImplementService() { }

        //path - text files
        string filePath = @"C:\Users\osand\source\repos\DC_Assignment_01_OB_Hettiarachchi_20908883\Authenticator\credentials.txt";
        string tokenPath = @"C:\Users\osand\source\repos\DC_Assignment_01_OB_Hettiarachchi_20908883\Authenticator\tokens.txt";

        //Random token generation
        private readonly Random randToken = new Random();

        //login implementation
        public int Login(string name, string pass)
        {

            //read entire file and add info to list
            List<string> lines = File.ReadAllLines(filePath).ToList();
           //int token;
            List<string> tokens = File.ReadAllLines(tokenPath).ToList();

            //loop over each line
            foreach (string line in lines)
            {
                string[] records = line.Split(','); //separate name and password
                String loginName = records[0];
                String loginPassword = records[1];
                if (loginName == name && loginPassword == pass)
                {
                    Console.WriteLine("Login Successful");
                    Console.WriteLine("Your Token is :");
                    //token ranges from 1 - 30000
                    int token = randToken.Next(1, 3000);
                    tokens.Add($"{token}");
                    //add token to file
                    File.WriteAllLines(tokenPath, tokens);
                    return token;
                }
            }
            return 0;
        }

        public string Register(string name, string pass)
        {
            try
            {
                //saved to list so data isn't replaced
                List<string> lines = File.ReadAllLines(filePath).ToList();
                lines.Add(name + "," + pass);
                //add new record to file
                File.WriteAllLines(filePath, lines);
                return "Successfully Registered!";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Unsuccessful Registration";
            }

        }

        public string validate(int token)
        {
            //check if token is available and validate
            List<string> tokenrecords = File.ReadAllLines(tokenPath).ToList();
            string display = null;
            foreach (var savedToken in tokenrecords)
            {
                if (savedToken == token.ToString())
                {
                    return "Authentication Successful";
                    
                }
                else
                {
                    display = "Authentication Failed";
                }
            }
            return display;
        }

        int time = 0;
        public void setTime(int tokentime)
        {
            this.time = tokentime;
        }
        public void cleartoken()
        {
            while (true)
            {
                Thread.Sleep(time*1000);
                File.WriteAllText(tokenPath, "");
                Console.WriteLine("Tokens are cleared!");
            }
        }

        public ServerInterface createchannel()
        {
            throw new NotImplementedException();
        }
    }
}