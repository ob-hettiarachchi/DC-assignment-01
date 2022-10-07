using Authenticator;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

////OB Hettiarachchi - 20908883 - Assignment 01

namespace ServiceProvider.Controllers
{
    public class ServiceController : Controller
    {
        //Dictionary uses <Key,Value> pair
        //object from authenticator
        ImplementService interfaceService = new ImplementService();

        //ActionName passed to WebApiConfig
        [HttpGet]
        [ActionName("AddTwoNumbers")]

        //addition of two numbers
        public Dictionary<string, string> AddTwoNumbers(int input1, int input2, int token)
        {
            string str1 = null;
            string str2 = null;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (interfaceService.validate(token).Equals("Authentication Successful"))
            {
                int sum = input1 + input2;
                string output = sum.ToString();
                dictionary.Add("Output", output);
            }
            else
            {
                str1 = "Denied";
                str2 = "Authentication Error";
                dictionary.Add("Status", str1);
                dictionary.Add("Reason", str2);
                return dictionary;

            }
            return dictionary;

        }

        [HttpGet]
        [ActionName("AddThreeNumbers")]

        //addition of three numbers
        public Dictionary<string, string> AddThreeNumbers(int input1, int input2, int input3, int token)
        {
            string str1 = null;
            string str2 = null;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (interfaceService.validate(token).Equals("Authentication Successful"))
            {
                int sum = (input1 + input2 + input3);
                string output = sum.ToString();
                dictionary.Add("Output", output);
            }
            else
            {
                str1 = "Denied";
                str2 = "Authentication Error";
                dictionary.Add("Status", str1);
                dictionary.Add("Reason", str2);
                return dictionary;

            }
            return dictionary;
        }

        [HttpGet]
        [ActionName("MulTwoNumbers")]

        //multiplication of two numbers
        public Dictionary<string, string> MulTwoNumbers(int input1, int input2, int token)
        {
            string str1 = null;
            string str2 = null;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (interfaceService.validate(token).Equals("Authentication Successful"))
            {
                int multiply = input1 * input2;
                string output = multiply.ToString();
                dictionary.Add("Output", output);
            }
            else
            {
                str1 = "Denied";
                str2 = "Authentication Error";
                dictionary.Add("Status", str1);
                dictionary.Add("Reason", str2);
                return dictionary;

            }
            return dictionary;

        }

        [HttpGet]
        [ActionName("MulThreeNumbers")]

        //multiplication of three numbers
        public Dictionary<string, string> MulThreeNumbers(int input1, int input2, int input3, int token)
        {
            string str1 = null;
            string str2 = null;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (interfaceService.validate(token).Equals("Authentication Successful"))
            {
                int multiply = (input1 * input2 * input3);
                string output = multiply.ToString();
                dictionary.Add("Output", output);
            }
            else
            {
                str1 = "Denied";
                str2 = "Authentication Error";
                dictionary.Add("Status", str1);
                dictionary.Add("Reason", str2);
                return dictionary;

            }
            return dictionary;
        }
    }
}