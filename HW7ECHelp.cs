using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7ECHelp
{
    public class DoubleDabble
    {
        private string userInput;
        private int[] values;

        public DoubleDabble(string userInput)
        {
            this.userInput = userInput;
            int arraySize = userInput.Length + (4 *
                                                Convert.ToInt32(Math.Ceiling((double)(userInput.Length / 3))));
            values = new int[arraySize];
            for (int i = 0; i < userInput.Length; i++)
            {
                values[i] = Convert.ToInt32(userInput[i].ToString());
            }


        }
        public int[] getSection(int sectionNumber)
        {
            int[] section = new int[4];
            int position = userInput.Length + (4 * (sectionNumber - 1)) - 1;
            section[0] = values[position];
            section[1] = values[position+1];
            section[2] = values[position+2];
            section[3] = values[position+3];
            return section;
        }

        public int ConvertIntArrayToInt(int[] arr)
        {
            return Convert.ToInt32(String.Join("", arr.Reverse()), 2);
        }

        public void shiftLeft()
        {
            int[] tmpArray = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
                tmpArray[(i + 1) % values.Length] = values[i];
            values = tmpArray;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your binary number: ");
            string userInput = Console.ReadLine();
            DoubleDabble db = new DoubleDabble(userInput);
            db.shiftLeft();
            db.shiftLeft();

            Console.WriteLine(db.ConvertIntArrayToInt(db.getSection(1)));
            

        }
    }
}
