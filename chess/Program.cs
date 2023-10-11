using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int row = 8;
            const int col = 8;
            int[,] field = new int[row, col];
            int position_row, position_col;
            setArr(field, row, col);
            printField(field, row, col);


            Console.ReadKey();
        }
        #region SET INITIAL ARRAY
        static void setArr(int[,] arr, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((i + j) % 2 == 0) arr[i, j] = 0;
                    else arr[i, j] = 1;
                }
            }
        }
        #endregion

        #region PRINT FIELD
        static void printField(int[,] arr, int row, int col)
        {
            int k = 8;
            Console.Write(" ");
            for (char i = 'A'; i < 'I'; i++)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
            for (int i = 0; i < row; i++, k--)
            {
                Console.Write(k + " ");
                for (int j = 0; j < col; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (arr[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (arr[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (arr[i, j] == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                Console.WriteLine();
            }
        } 
        #endregion
    }
}
