using AdventOfCode22.Classes;
using System;

namespace MyApp
{
    internal class Program {
        private static Puzzle mSelectedPuzzle = Puzzle.DAY_3_PART_2;
        private static string mInputFileRootDir = "C:\\Users\\theco\\source\\repos\\AdventOfCode22\\AdventOfCode22\\bin\\Debug\\net6.0\\";

        static void Main(string[] args) {
            switch (mSelectedPuzzle) {
                case Puzzle.DAY_1_PART_1:
                    DoPuzzle(mPuzzleFileDayOne, DayOne.DayOne_PartOne);
                    break;
                case Puzzle.DAY_1_PART_2:
                    DoPuzzle(mPuzzleFileDayOne, DayOne.DayOne_PartTwo);
                    break;
                case Puzzle.DAY_2_PART_1:
                    DoPuzzle(mPuzzleFileDayTwo, DayTwo.DayTwo_PartOne);
                    break;
                case Puzzle.DAY_2_PART_2:
                    DoPuzzle(mPuzzleFileDayTwo, DayTwo.DayTwo_PartTwo);
                    break;
                case Puzzle.DAY_3_PART_1:
                    DoPuzzle(mPuzzleFileDayThree, DayThree.DayThree_PartOne);
                    break;
                case Puzzle.DAY_3_PART_2:
                    DoPuzzle(mPuzzleFileDayThree, DayThree.DayThree_PartTwo);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void DoPuzzle(string puzzleFileName, Action<string[]> puzzleMethod) {
            string[]? input = GetInputIfFileExists(mInputFileRootDir, puzzleFileName);
            if (input == null) {
                return;
            }
            if (input.Length == 0) {
                Console.WriteLine("Puzzle input from file '" + puzzleFileName + "' was empty");
                return;
            }

            puzzleMethod(input);
        }

        private static string[]? GetInputIfFileExists(string directory, string fileName) => CheckFileExists(directory, fileName) ? File.ReadAllLines(directory + fileName) : null;

        private static bool CheckFileExists(string directory, string fileName) {
            if (!File.Exists(directory + fileName)) {
                Console.WriteLine("File '" + fileName + "' could not be found at '" + directory + "'");
                return false;
            }
            return true;
        }

        enum Puzzle { 
            DAY_1_PART_1,
            DAY_1_PART_2,
            DAY_2_PART_1,
            DAY_2_PART_2,
            DAY_3_PART_1,
            DAY_3_PART_2
        }

        private static readonly string mPuzzleFileDayOne = "DayOne.txt";
        private static readonly string mPuzzleFileDayTwo = "DayTwo.txt";
        private static readonly string mPuzzleFileDayThree = "DayThree.txt";
    }
}