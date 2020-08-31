using SudokuSolver;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        public class test
        {
            [Fact]
            public void IsSafe_ReturnFalse()
            {
                var result = Program.IsSafe(0, 1, 3, Program._board);

                Assert.False(result, "0,1, 3 should be false");
            }
            [Fact]
            public void IsSafe_ReturnTrue()
            {
                var result = Program.IsSafe(0, 1, 1, Program._board);

                Assert.True(result, "0,1, 1 should be true");
            }

            [Fact]
            public void IsSafe_ReturnFalse2()
            {
                var result = Program.IsSafe(0, 1, 7, Program._board);

                Assert.False(result, "0,1, 7 should be false");
            }
            [Fact]
            public void IsSafe_ReturnTrue2()
            {
                var result = Program.IsSafe(0, 1, 9, Program._board);

                Assert.True(result, "0,1, 9 should be true");
            }
            [Fact]
            public void Recursive_Test1()
            {
                int[,] v = { { 1, 2 }, { 2, 1 } };
                var result = Program.Solve(0, 0, v);
                Assert.True(result, "0,1, 9 should be true");
            }

            [Fact]
            public void Recursive_Test2()
            {
                int[,] v = { { 1, 2 }, { 2, 0 } };
                var result = Program.Solve(0, 0, v);
                Assert.True(result, "0,1, 9 should be true");
            }
        }
    }
}
