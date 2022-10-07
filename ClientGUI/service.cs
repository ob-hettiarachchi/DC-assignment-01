using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI
{
    class service
    {
          public service() { }

        public service(string aPIEndPoint)
        {
            APIEndPoint = aPIEndPoint;
        }

        public service(string name, string description, string aPIEndPoint, int noOperands, string operandType)
        {
            Name = name;
            Description = description;
            APIEndPoint = aPIEndPoint;
            NoOperands = noOperands;
            OperandType = operandType;
            Status = "";
            Reason = "";
        }
         public service(string status, string reason)
        {
            Status = status;
            Reason = reason;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string APIEndPoint { get; set; }
        public int NoOperands { get; set; }
        public string OperandType { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }


    }
}
