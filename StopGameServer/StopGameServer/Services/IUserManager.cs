﻿using Logic;
using System;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IUserManager
    {
        [OperationContract]
        Logic.User Login(String userName, String password);

        [OperationContract]
        bool Register(User user);

        [OperationContract]
        bool ExistsEmailOrUserName(String userName, string email);

        [OperationContract]
        bool SendValidationEmail(String toEmail, String affair, int validationCode);

        [OperationContract]
        bool UpdatePassword(string password, string email);
    }
}
