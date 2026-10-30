using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge
{
    public class MyMathImplementation
    {
        

        internal static int Add(int a, int b)
        {
            return a + b;
        }

        internal static List<int> GenericSort(List<int> toSort, Func<int, int, bool> isInOrder)
        {
            bool genericIsListInOrder(List<int> toSort)
            {
                for (int i = 0; i < toSort.Count - 2; i++)
                {
                    if (isInOrder(toSort[i], toSort[i + 1]) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            
            while (genericIsListInOrder(toSort) == false)
            {
                for (int i = 0; i < toSort.Count - 1; i++)
                {
                    if (isInOrder(toSort[i], toSort[i + 1]) == false)
                    {
                        int temp = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = temp;
                    }
                }
            }
            return toSort;
        }

        internal static List<int> GetAllPrimary(int a)
        {
            List<int> result = new List<int>();
            if (a == 2)result.Add(2);
            for (int i = 2; i < a; i++)
            {
                if (IsPrimary(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        internal static bool IsDivisible(int a, int b)
        {
            return a % b == 0;
        }

        internal static bool IsEven(int a)
        {
            return a % 2 == 0;
        }

        internal static bool IsInOrder(int a, int b)
        {
            return a <= b;
        }

        internal static bool IsInOrderDesc(int arg1, int arg2)
        {
            return arg1 > arg2;
        }

        internal static bool IsListInOrder(List<int> list)
        {
            for (int i = 0; i < list.Count - 2; i++)
            {
                if (IsInOrder(list[i], list[i + 1]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool IsMajeur(int age)
        {
            if (age < 0) throw new ArgumentException("age cannot be negative");
            if (age > 140) throw new ArgumentException("age cannot be too high");

            //return age >= 18;
            if (age >= 18) return true; 
            else return false;
        }

        internal static bool IsPrimary(int a)
        {
            for(int i = 2; i <= Mathf.Sqrt(a); i++)
            {
                if(a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        internal static int Power(int a, int b)
        {
            int result = a;
            for (int i = 0; i < b - 1; i++)
            {
                result *= a;
            }
            return result;
        }

        internal static int Power2(int a)
        {
            return a * a;
        }

        internal static List<int> Sort(List<int> toSort)
        {
            while (IsListInOrder(toSort) == false)
            {
                for (int i = 0; i < toSort.Count - 1; i++)
                {
                    if (IsInOrder(toSort[i], toSort[i + 1]) == false)
                    {
                        int temp = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = temp;
                    }
                }
            }
            return toSort;
        }
    }
}
