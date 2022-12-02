using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22.Classes {
    internal class DayTwo {
        // Part One Entry Method
        public static void DayTwo_PartOne(string[] input) {
            List<int>? values = GetRoundScores_PartOne(input);
            if (values == null) {
                Console.WriteLine("Something went wrong in GetRoundScore_PartOne, check input file");
                return; 
            }

            Console.WriteLine(values.Sum());
        }

        // Part Two Entry Method
        public static void DayTwo_PartTwo(string[] input) {
            List<int>? values = GetRoundScores_PartTwo(input);
            if (values == null) {
                Console.WriteLine("Something went wrong in GetRoundScore_PartTwo, check input file");
                return;
            }

            Console.WriteLine(values.Sum());
        }

        private static List<int>? GetRoundScores_PartOne(string[] input) {
            List<int> values = new List<int>();

            for (int i = 0; i < input.Length; i++) {
                RockPaperScissors opponentRps = GetRockPaperScissors(input[i][0]);
                RockPaperScissors playerRps = GetRockPaperScissors(input[i][2]);
                
                if (opponentRps == RockPaperScissors.DEFAULT) return null;
                if (playerRps == RockPaperScissors.DEFAULT) return null;

                int? roundScore = GetScore(opponentRps, playerRps);
                if (roundScore == null) return null;

                values.Add((int)roundScore);

            }

            return values;
        }

        private static int? GetScore(RockPaperScissors opponentRps, RockPaperScissors playerRps) {
            RoundStatus roundStatus = GetRoundStatus(opponentRps, playerRps);

            int rpsScore = GetRockPaperScissorScore(playerRps);
            if (rpsScore == -1) return null;

            int roundStatusScore = GetRoundStatusScore(roundStatus);
            if (roundStatusScore == -1) return null;

            return rpsScore + roundStatusScore;
        }

        private static RoundStatus GetRoundStatus(RockPaperScissors opponentRps, RockPaperScissors playerRps) {
            return RoundStatusLookup[Tuple.Create(opponentRps, playerRps)];
        }

        private static RockPaperScissors GetRockPaperScissors(char character) {
            switch (character) {
                case 'A':
                    return RockPaperScissors.ROCK;
                case 'X':
                    return RockPaperScissors.ROCK;
                case 'B':
                    return RockPaperScissors.PAPER;
                case 'Y':
                    return RockPaperScissors.PAPER;
                case 'C':
                    return RockPaperScissors.SCISSORS;
                case 'Z':
                    return RockPaperScissors.SCISSORS;
                default:
                    return RockPaperScissors.DEFAULT;
            }
        }

        private static int GetRoundStatusScore(RoundStatus status) {
            switch (status) { 
                case RoundStatus.WIN:
                    return 6;
                case RoundStatus.LOSE:
                    return 0;
                case RoundStatus.DRAW:
                    return 3;
                default:
                    return -1;
            }
        }

        private static int GetRockPaperScissorScore(RockPaperScissors rps) {
            switch (rps) { 
                case RockPaperScissors.ROCK:
                    return 1;
                case RockPaperScissors.PAPER:
                    return 2;
                case RockPaperScissors.SCISSORS:
                    return 3;
                default:
                    return -1;
            }
        }

        enum RockPaperScissors { 
            ROCK,
            PAPER,
            SCISSORS,
            DEFAULT
        }

        enum RoundStatus { 
            WIN,
            LOSE,
            DRAW,
            DEFAULT
        }

        private static readonly Dictionary<Tuple<RockPaperScissors, RockPaperScissors>, RoundStatus> RoundStatusLookup = new Dictionary<Tuple<RockPaperScissors, RockPaperScissors>, RoundStatus>() {
            { Tuple.Create(RockPaperScissors.ROCK, RockPaperScissors.ROCK), RoundStatus.DRAW },
            { Tuple.Create(RockPaperScissors.ROCK, RockPaperScissors.PAPER), RoundStatus.WIN },
            { Tuple.Create(RockPaperScissors.ROCK, RockPaperScissors.SCISSORS), RoundStatus.LOSE },
            { Tuple.Create(RockPaperScissors.PAPER, RockPaperScissors.ROCK), RoundStatus.LOSE },
            { Tuple.Create(RockPaperScissors.PAPER, RockPaperScissors.PAPER), RoundStatus.DRAW },
            { Tuple.Create(RockPaperScissors.PAPER, RockPaperScissors.SCISSORS), RoundStatus.WIN },
            { Tuple.Create(RockPaperScissors.SCISSORS, RockPaperScissors.ROCK), RoundStatus.WIN },
            { Tuple.Create(RockPaperScissors.SCISSORS, RockPaperScissors.PAPER), RoundStatus.LOSE },
            { Tuple.Create(RockPaperScissors.SCISSORS, RockPaperScissors.SCISSORS), RoundStatus.DRAW }
        };

        // PART_TWO ===================
        private static List<int>? GetRoundScores_PartTwo(string[] input) {
            List<int> values = new List<int>();

            for (int i = 0; i < input.Length; i++) {
                RockPaperScissors opponentRps = GetRockPaperScissors(input[i][0]);
                if (opponentRps == RockPaperScissors.DEFAULT) return null;

                RockPaperScissors playerRps = GetRockPaperScissors_PartTwo(opponentRps, input[i][2]);
                if (playerRps == RockPaperScissors.DEFAULT) return null;

                int? roundScore = GetScore(opponentRps, playerRps);
                if (roundScore == null) return null;

                values.Add((int)roundScore);

            }

            return values;
        }

        private static RockPaperScissors GetRockPaperScissors_PartTwo(RockPaperScissors opponentRps, char character) {
            return RoundStatusBackwardsLookup[Tuple.Create(opponentRps, GetRoundStatus_PartTwo(character))];
        }

        private static RoundStatus GetRoundStatus_PartTwo(char character) {
            switch (character) {
                case 'X':
                    return RoundStatus.LOSE;
                case 'Y':
                    return RoundStatus.DRAW;
                case 'Z':
                    return RoundStatus.WIN;
                default:
                    return RoundStatus.DEFAULT;
            }
        }

        private static readonly Dictionary<Tuple<RockPaperScissors, RoundStatus>, RockPaperScissors> RoundStatusBackwardsLookup = new Dictionary<Tuple<RockPaperScissors, RoundStatus>, RockPaperScissors>() {
            { Tuple.Create(RockPaperScissors.ROCK, RoundStatus.WIN), RockPaperScissors.PAPER },
            { Tuple.Create(RockPaperScissors.ROCK, RoundStatus.DRAW), RockPaperScissors.ROCK },
            { Tuple.Create(RockPaperScissors.ROCK, RoundStatus.LOSE), RockPaperScissors.SCISSORS },
            { Tuple.Create(RockPaperScissors.PAPER, RoundStatus.WIN), RockPaperScissors.SCISSORS },
            { Tuple.Create(RockPaperScissors.PAPER, RoundStatus.DRAW), RockPaperScissors.PAPER },
            { Tuple.Create(RockPaperScissors.PAPER, RoundStatus.LOSE), RockPaperScissors.ROCK },
            { Tuple.Create(RockPaperScissors.SCISSORS, RoundStatus.WIN), RockPaperScissors.ROCK },
            { Tuple.Create(RockPaperScissors.SCISSORS, RoundStatus.DRAW), RockPaperScissors.SCISSORS },
            { Tuple.Create(RockPaperScissors.SCISSORS, RoundStatus.LOSE), RockPaperScissors.PAPER }
        };
    }
}
