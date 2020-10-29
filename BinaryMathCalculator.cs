using System;
using System.Collections;

namespace bianryMathCalculatorFA20
{
    public class BinaryMathResult
    {
        public bool sum { get; set; }
        public bool carry { get; set; }
    }

    public class HelperMethods
    {
        public static bool[] createFromArray(int[] arr)
        {
            bool[] ret = new bool[arr.Length];
            for (int i = 0; i < arr.Length ; i++)
            {
                ret[i] = arr[arr.Length - i - 1] == 1 ? true : false;
            }

            return ret; 
        }

        public static int convertBoolArrayToInt(bool[] arr)
        {
            BitArray bitField = new BitArray(arr);
            byte[] data = new byte[4];
            bitField.CopyTo(data, 0);
            return BitConverter.ToInt32(data, 0);
        }
    }

    public class Calculator
    {
        public static BinaryMathResult fullAdder(bool abit, bool bbit, bool cbit)
        {
            return new BinaryMathResult()
            {
                sum = (abit ^ bbit) ^ cbit,
                carry = (abit & bbit) | (bbit & cbit) | (abit & cbit)
            };
        }

        public static bool[] add(bool[] num1, bool[] num2)
        {
            if(num1.Length != num2.Length)
                throw new Exception("Must be same size!");

            bool[] resultAdder = new bool[num1.Length];
            bool carry = false;
            BinaryMathResult result;
            for (int i = 0; i < num1.Length; i++)
            {
                result = fullAdder(num1[i], num2[i], carry);
                resultAdder[i] = result.sum;
                carry = result.carry;
            }

            return resultAdder;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool[] num1 = HelperMethods.createFromArray(new[] {0, 0, 1, 0}); // 2
            bool[] num2 = HelperMethods.createFromArray(new[] {0, 0, 1, 1}); // 3
            bool[] num3 = Calculator.add(num1, num2);
            Console.WriteLine(HelperMethods.convertBoolArrayToInt(num3));

            Console.WriteLine(HelperMethods.convertBoolArrayToInt(HelperMethods.createFromArray(new [] { 0, 0, 1, 0})));
            Console.WriteLine(HelperMethods.convertBoolArrayToInt(HelperMethods.createFromArray(new[] { 0, 0, 1, 1})));

            num1 = HelperMethods.createFromArray(new[] { 0, 1, 0, 0 }); // 2
            num2 = HelperMethods.createFromArray(new[] { 1, 1, 0, 0 }); // 3
            num3 = Calculator.add(num1, num2);
            Console.WriteLine(HelperMethods.convertBoolArrayToInt(num3));
        }
    }
}
