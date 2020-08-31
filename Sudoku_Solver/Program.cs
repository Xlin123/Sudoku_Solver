using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SudokuSolver
{
    //Made By: Xavier Lin
    public class Program
    {
        public static int[,] _board = new int[,] {
            { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
        };
        public static void Main(string[] args)
        {   //our sudoku board
           
        
            //printing the solved sudoku board, or printing that it's unsolvable
            if (Solve(0, 0, _board))
            {
                for (int i = 0; i < _board.GetLength(0); i++)
                {
                    for (int j = 0; j < _board.GetLength(0); j++)
                    {
                        Console.Write(_board[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Solved!!");
            }
            else
                Console.WriteLine("Unsolvable");
        }

        public static bool Solve(int row, int col, int[,] board)
        {
            var boardLength = board.GetLength(0);
            //checks if we are looking out of the bounds of the board
            if (col == boardLength)
            {
                row++;
                col = 0;
            }
            //only definite TRUE case
            //checks if we have hit the row is out of bounds, which means we have completed the board.
            if (row == boardLength)
            {
                _board = board;
                return true;
            }
            //checks if there is a number in the index we are looking at, if so we move on to the next one.
            if (board[row, col] != 0)
                return Solve(row, col + 1, board);
            //recursive backtracking algorithm
            //tries numbers from 1-9
            for (var trynum = 1; trynum < 10; trynum++)
            {
                //checks if safe
                if (IsSafe(row, col, trynum, board))
                {   //set number on the board 
                    board[row, col] = trynum;
                    //recursing forward
                    //recurses to the next number, if the final recursion hits the base case then it returns true all the way back.
                    if (Solve(row, col + 1, board))
                        return true;
                }
            }
            //backtracking
            //if NONE of the numbers work, set the current  index to 0, and return to the previous number and try the rest of the possible solutions
            board[row, col] = 0;
            return false;
        }

        public static bool IsSafe(int row, int col, int num, int[,] board)
        {
            //row is X, col is y
            var boardLength = board.GetLength(0);

            //row
            for (int i = 0; i < boardLength; i++)
                if (board[i, col] == num) return false;

            //column
            for (int j = 0; j < boardLength; j++)
                if (board[row, j] == num) return false;

            //checking the sub squares
            int sqrt = (int)Math.Sqrt(boardLength);
            int rowStart = row - row % sqrt;
            int colStart = col - col % sqrt;
            for (int x = rowStart; x < rowStart + sqrt; x++)
                for (int y = colStart; y < colStart + sqrt; y++)
                    if (board[x, y] == num)
                        return false;
            return true;
        }
    }
}
