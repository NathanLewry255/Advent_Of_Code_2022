using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Classes {
    internal class DayThree {
        public static void DayThree_PartOne(string[] input) {
            int sum = 0;

            for (int i = 0; i < input.Length; i++) {
                sum += GetAllItemValues(
                    GetSharedItems(input[i])
                ).Sum();
            }

            Console.WriteLine(sum);
        }

        public static void DayThree_PartTwo(string[] input) {
            int sum = 0;

            for (int i = 0; i < input.Length; i += 3) {
                sum += GetAllItemValues(
                    GetSingleItemSharedMultiLine(new string[] { input[i], input[i + 1], input[i + 2] })
                ).Sum();
            }

            Console.WriteLine(sum);
        }

        private static List<char> GetSingleItemSharedMultiLine(string[] lines) { 
            string currentIntersect = lines[0];

            for (int i = 1; i < lines.Length; i++) {
                currentIntersect = new string(currentIntersect.Intersect(lines[i]).ToArray());
            }

            return currentIntersect.ToList();
        }

        private static List<char> GetSharedItems(string line) {
            int lineLength = line.Length / 2;

            string sectionA = line.Substring(0, lineLength);
            string sectionB = line.Substring(lineLength, lineLength);

            return sectionA.Intersect(sectionB).ToList();
        }

        private static List<int> GetAllItemValues(List<char> items) {
            List<int> values = new List<int>();

            for (int i = 0; i < items.Count; i++) {
                values.Add(GetItemValue(items[i]));
            }

            return values;
        }

        private static int GetItemValue(char item) {
            if (IsUppers(item)) {
                return item - 38; // A == 27
            }
            return item - 96; // a == 1
        }

        private static bool IsUppers(char item) {
            return item > 64 && item < 91;
        }
    }
}
