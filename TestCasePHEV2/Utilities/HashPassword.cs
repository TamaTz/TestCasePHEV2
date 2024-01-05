﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCasePHEV2.Utilities.Handler
{
    public class Hashing
    {
        private static string CreateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, CreateSalt());
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}