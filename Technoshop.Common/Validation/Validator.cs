using System;
using System.Collections.Generic;
using System.Text;

namespace Technoshop.Common.Validation
{
    public static class Validator
    {

        public static void EnsureNotNull (object obj, string message = "")
        {
            if (obj == null)
            {
                throw new ArgumentException(message);
            }
        }
        public static void EnsureStringIsNotNullOrEmpty(string str, string message = "")
        {
            if (str == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void EnsureDoubleIsNotNegativeOrZero(double num, string message = "")
        {
            if (num <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
