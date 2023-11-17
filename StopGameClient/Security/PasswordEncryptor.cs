﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Security
{
    public class PasswordEncryptor
    {
        public static string ComputeSHA512Hash(string input)
        {
            var encryptedPassword = "";
            using (SHA512 sHA512Hash = SHA512.Create())
            {
                byte[] hash = sHA512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                encryptedPassword = BitConverter.ToString(hash)
                    .Replace("-", string.Empty)
                    .ToLowerInvariant();
            }
            return encryptedPassword;
        }
    }
}
