using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Classes {
    internal class DayFour {
        public static void DayFour_PartOne(string[] input) {
            int count = 0;

            for (int i = 0; i < input.Length; i++) {
                int[] vals = GetValues(input[i]);

                int lowerA = vals[0];
                int upperA = vals[1];
                int lowerB = vals[2];
                int upperB = vals[3];

                if ((lowerA <= lowerB && upperA >= upperB) || (lowerA >= lowerB && upperA <= upperB)) {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        public static void DayFour_PartTwo(string[] input) {
            int count = 0;

            for (int i = 0; i < input.Length; i++) {
                int[] vals = GetValues(input[i]);

                int lowerA = vals[0];
                int upperA = vals[1];
                int lowerB = vals[2];
                int upperB = vals[3];

                if (!(lowerA > upperB || upperA < lowerB)) {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static int[] GetValues(string input) {
            string[] stringSplit = input.Split(',');
            string[] inputA = stringSplit[0].Split('-');
            string[] inputB = stringSplit[1].Split('-');

            return new int[] { int.Parse(inputA[0]), int.Parse(inputA[1]), int.Parse(inputB[0]), int.Parse(inputB[1]) };
        }
    }
}
