using System;
using System.ServiceModel;

//OB Hettiarachchi - 20908883 - Assignment 01

namespace Authenticator
{
    [ServiceContract]
    public interface ServerInterface
    {
        [OperationContract]
        string Register(
            string name,
            string Password
            );

        [OperationContract]
        int Login(
            string name,
            string Password
            );

        [OperationContract]
        string validate(
            int token
            );
    }
}