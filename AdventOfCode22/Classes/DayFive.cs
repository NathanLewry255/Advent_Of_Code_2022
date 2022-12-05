using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Classes {
    internal class DayFive {

        public static void DayFive_PartOne(string[] input) {
            Dictionary<int, List<char>> crates;

            int split = 0; // Where there is an empty line in input
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == "") {
                    split = i;
                    break;
                }
            }

            crates = getCrateState(input[..(split - 1)]);
            DoSortSingleMove(ref crates, input[(split + 1)..]);

            Output(ref crates);
        }

        public static void DayFive_PartTwo(string[] input) {
            Dictionary<int, List<char>> crates;

            int split = 0; // Where there is an empty line in input
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == "") {
                    split = i;
                    break;
                }
            }

            crates = getCrateState(input[..(split - 1)]);
            DoSortMultiMove(ref crates, input[(split + 1)..]);

            Output(ref crates);
        }

        private static Dictionary<int, List<char>> getCrateState(string[] input) {
            Dictionary<int, List<char>> crates = new Dictionary<int, List<char>>();

            for (int i = 0; i < input.Length; i++) {
                int index = 0;

                for (int j = 1; j < input[i].Length; j += 4) {
                    index++;
                    if (!(input[i][j] < 65 || input[i][j] > 90)) { // Can always assume caps
                        if (crates.ContainsKey(index)) {
                            crates[index].Add(input[i][j]);
                        }
                        else {
                            crates.Add(index, new List<char>() { input[i][j] });
                        }
                    }
                }
            }

            return crates;
        }

        private static void DoSortSingleMove(ref Dictionary<int, List<char>> crates, string[] actions) {
            for (int i = 0; i < actions.Length; i++) {
                string[] split = actions[i].Split(' ');
                Move(ref crates, int.Parse(split[1]), int.Parse(split[3]), int.Parse(split[5]));
            }
        }

        private static void DoSortMultiMove(ref Dictionary<int, List<char>> crates, string[] actions) {
            for (int i = 0; i < actions.Length; i++) {
                string[] split = actions[i].Split(' ');
                MoveMultiple(ref crates, int.Parse(split[1]), int.Parse(split[3]), int.Parse(split[5]));
            }
        }

        private static void Move(ref Dictionary<int, List<char>> crates, int value, int stack, int target) {
            for (int i = 0; i < value; i++) {
                if (crates[stack].Count == 0) {
                    return;
                }
                char tmp = crates[stack][0];
                crates[target].Insert(0, tmp);
                crates[stack].RemoveAt(0);
            }
        }

        private static void MoveMultiple(ref Dictionary<int, List<char>> crates, int value, int stack, int target) {
            List<char> tmp = crates[stack].GetRange(0, value);
            for (int i = 0; i < value; i++) {
                crates[target].Insert(i, tmp[i]);
                crates[stack].RemoveAt(0);
            }
        }
        private static void Output(ref Dictionary<int, List<char>> crates) {
            foreach (KeyValuePair<int, List<char>> crate in crates.OrderBy(it => it.Key)) {
                Console.Write(crate.Key + ": ");
                for (int i = 0; i < crate.Value.Count; i++) {
                    Console.Write(crate.Value[i] + " ");
                }
                Console.Write("\n\n");
            }
        }
    }
}
