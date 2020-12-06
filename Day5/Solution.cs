using System;
using System.Collections.Generic;

namespace AdventOfCode.Day5
{
    public struct Seat
    {
        public Seat(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int row;
        public int col;

        public int GetSeatId() {
            return (row * 8) + col;
        }
    }

    public class Solution
    {
        public static void Solve(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day5/input");
            int maxSeatId = 0;
            foreach (string line in lines) {
                Seat seat = GetSeat(line);
                int seatId = seat.GetSeatId();
                Console.WriteLine(line + ": row " + seat.row + ", column " + seat.col + ", seat ID " + seatId);
                if (seatId > maxSeatId) {
                    maxSeatId = seatId;
                }
            }
            Console.WriteLine(maxSeatId);
        }

        public static Seat GetSeat(string instructions) {
            string rowInstructions = instructions.Substring(0,7);
            string colInstructions = instructions.Substring(7,3);
            int row = BinaryPartition(0, 127, rowInstructions);
            int col = BinaryPartition(0, 7, colInstructions);
            return new Seat(row, col);
        }

        public static int BinaryPartition(int min, int max, string row) {
            int midPoint = ((max-min) / 2) + min;
            if (row == "") {
                return min;
            }
            char instruction = row[0];

            if (instruction == 'F' || instruction == 'L') {
                return BinaryPartition(min, midPoint, row.Substring(1, row.Length-1));
            } else if (instruction == 'B' || instruction == 'R') {
                return BinaryPartition(midPoint+1, max, row.Substring(1, row.Length-1));
            } else {
                Console.WriteLine("invalid binary partition call");
                return -1;
            }
        }
    }
}

