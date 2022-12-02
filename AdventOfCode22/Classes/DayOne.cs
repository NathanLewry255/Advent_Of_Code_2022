using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Classes {
    public static class DayOne {
        public static void DayOne_PartOne(string[] input) => Console.WriteLine(GetInputSums(input).Max());

        public static void DayOne_PartTwo(string[] input) => Console.WriteLine(GetInputSums(input).OrderBy(it => it).TakeLast(3).Sum());

        private static List<int> GetInputSums(string[] input) {
            List<int> values = new List<int>();

            int sum = 0;
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == "") {
                    values.Add(sum);
                    sum = 0;
                    continue;
                }
                sum += int.Parse(input[i]);
            }

            return values;
        }
    }
}
