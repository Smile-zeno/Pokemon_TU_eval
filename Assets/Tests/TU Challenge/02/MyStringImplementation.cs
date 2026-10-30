using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        internal static string BazardString(string input)
        {
            throw new NotImplementedException();
        }

        internal static bool IsNullEmptyOrWhiteSpace(string input)
        {
            if (input == null) return true;
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] == ' ') == false) return false;
            }

            return true;
        }

        internal static string MixString(string a, string b)
        {
            if (IsNullEmptyOrWhiteSpace(a)) throw new ArgumentException("input must not be null or empty");
            if (IsNullEmptyOrWhiteSpace(b)) throw new ArgumentException("input must not be null or empty");
            
            int size = a.Length > b.Length ? a.Length : b.Length;
            string newString = "";
            for (int i = 0; i < size; i++)
            {
                if (a.Length <= i && b.Length > i)
                {
                    newString += b[i].ToString();
                }
                else if (b.Length <= i && a.Length > i)
                {
                    newString += a[i].ToString();
                }
                else
                {
                    newString += a[i].ToString() + b[i].ToString();
                }
            }
            return newString;
        }

        internal static string ToCesarCode(string input, int offset)
        {
            throw new NotImplementedException();
        }

        internal static string ToLowerCase(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                throw new NotImplementedException();
            }
            return a;
        }

        internal static string UnBazardString(string input)
        {
            throw new NotImplementedException();
        }

        internal static string Voyelles(string a)
        {
            throw new NotImplementedException();
        }
    }
}
