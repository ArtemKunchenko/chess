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
            int pos_row = 0, pos_col = 0;
            bool exit = true;
            int choice;
            int[,] field = new int[row, col];
            setArr(field, row, col);
            while (exit)
            {
                printOptions();
                Console.Write("Number: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                printField(field, row, col);
                
                switch (choice)
                {
                    case 0:
                        exit = false;
                        Console.Clear();
                        break;
                    case 1:
                        setPosition(ref pos_row, ref pos_col);
                        Console.Clear();
                        showKing(field, pos_row, pos_col);
                        printField(field, row, col);
                        break;
                    case 2:
                        setPosition(ref pos_row, ref pos_col);
                        Console.Clear();
                        showQueen(field, pos_row, pos_col);
                        printField(field, row, col);
                        break;
                    case 3:
                        setPosition(ref pos_row, ref pos_col);
                        Console.Clear();
                        showRook(field, pos_row, pos_col);
                        printField(field, row, col);
                        break;
                    case 4:
                        setPosition(ref pos_row, ref pos_col);
                        Console.Clear();
                        showBishop(field, pos_row, pos_col);
                        printField(field, row, col);
                        break;
                    case 5:
                        setPosition(ref pos_row, ref pos_col);
                        Console.Clear();
                        showKnight(field, pos_row, pos_col);
                        printField(field, row, col);
                        break;
                    case 6:
                        setPosition(ref pos_row, ref pos_col);
                        Console.Clear();
                        showPawn(field, pos_row, pos_col);
                        printField(field, row, col);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid value");
                        break;
                }

                setArr(field, row, col);
                Console.ReadKey();
            }
         
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
            int k = 1;
            Console.Write(" ");
            for (int i = 1; i < 9; i++)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
            for (int i = 0; i < row; i++, k++)
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
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write("**");
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

        #region PRINT OPTIONS
        static void printOptions()
        {
            Console.Clear();
            Console.WriteLine("Choose chess piece:");
            Console.WriteLine("1 - KING");
            Console.WriteLine("2 - QUEEN");
            Console.WriteLine("3 - ROOK");
            Console.WriteLine("4 - BISHOP");
            Console.WriteLine("5 - KNIGHT");
            Console.WriteLine("6 - PAWN");
            Console.WriteLine("0 - for exit");
            Console.WriteLine();

        }
        #endregion

        #region SET POSITION
        static void setPosition(ref int row, ref int col)
        {
            do
            {
                Console.WriteLine("Choose pocition (row and col) using numbers from 1 to 8");
                Console.Write("Row: ");
                row = int.Parse(Console.ReadLine());
                Console.Write("Col: ");
                col = int.Parse(Console.ReadLine());
                if (row >= 1 && row <= 8 && col >= 1 && col <= 8) break;
                Console.WriteLine("Invalid value");
            }
            while (row < 1 || row > 8 || col < 1 || col > 8);
            row--;
            col--;
        }
        #endregion

        #region SHOW PAWN
        static void showPawn(int[,] arr, int row, int col)
        {
            arr[row, col] = 2;
            if ((row - 1) >= 0) arr[row - 1, col] = 3;
            if ((row - 1) >= 0 && (col - 1) >= 0) arr[row - 1, col - 1] = 3;
            if ((row - 1) >= 0 && (col + 1) <= 7) arr[row - 1, col + 1] = 3;
        }
        #endregion

        #region SHOW KING
        static void showKing(int[,] arr, int row, int col)
        {
            arr[row, col] = 2;
            if ((row - 1) >= 0) arr[row - 1, col] = 3;
            if ((row + 1) <= 7) arr[row + 1, col] = 3;
            if ((col - 1) >= 0) arr[row, col - 1] = 3;
            if ((col + 1) <= 7) arr[row, col + 1] = 3;
        }
        #endregion

        #region SHOW QUEEN
        static void showQueen(int[,] arr, int row, int col)
        {
            arr[row, col] = 2;
            for (int i = -7; i < arr.Length; i++) //vertical placement
            { if ((row + i) >= 0 && (row + i) <= 7 && (row + i) != row) arr[row + i, col] = 3; }
            for (int i = -7; i < arr.Length; i++)//horisontal placement
            { if ((col + i) >= 0 && (col + i) <= 7 && (col + i) != col) arr[row, col + i] = 3; }
            for (int i = -7; i < arr.Length; i++)//diogonal placement
            { if ((row + i) >= 0 && (row + i) <= 7 && (row + i) != row && (col + i) >= 0 && (col + i) <= 7 && (col + i) != col) arr[row + i, col + i] = 3; }
            for (int i = -7; i < arr.Length; i++)//oposit diogonal placement
            { if ((row + i) >= 0 && (row + i) <= 7 && (row + i) != row && (col - i) >= 0 && (col - i) <= 7 && (col - i) != col) arr[row + i, col - i] = 3; }

        }
        #endregion

        #region SHOW ROOK
        static void showRook(int[,] arr, int row, int col)
        {
            arr[row, col] = 2;
            for (int i = -7; i < arr.Length; i++) //vertical placement
            { if ((row + i) >= 0 && (row + i) <= 7 && (row + i) != row) arr[row + i, col] = 3; }
            for (int i = -7; i < arr.Length; i++)//horisontal placement
            { if ((col + i) >= 0 && (col + i) <= 7 && (col + i) != col) arr[row, col + i] = 3; }
        }
        #endregion

        #region SHOW BISHOP
        static void showBishop(int[,] arr, int row, int col)
        {
            arr[row, col] = 2;
            for (int i = -7; i < arr.Length; i++)//diogonal placement
            { if ((row + i) >= 0 && (row + i) <= 7 && (row + i) != row && (col + i) >= 0 && (col + i) <= 7 && (col + i) != col) arr[row + i, col + i] = 3; }
            for (int i = -7; i < arr.Length; i++)//oposit diogonal placement
            { if ((row + i) >= 0 && (row + i) <= 7 && (row + i) != row && (col - i) >= 0 && (col - i) <= 7 && (col - i) != col) arr[row + i, col - i] = 3; }

        }
        #endregion

        #region SHOW KNIGHT
        static void showKnight(int[,] arr, int row, int col)
        {
            arr[row, col] = 2;
            if ((row - 2) >= 0 && (col - 1) >= 0) arr[row - 2, col - 1] = 3; //up-left
            if ((row - 2) >= 0 && (col + 1) <= 7) arr[row - 2, col + 1] = 3; //up-right
            if ((row + 2) <= 7 && (col - 1) >= 0) arr[row + 2, col - 1] = 3; //down-left
            if ((row + 2) <= 7 && (col + 1) <= 7) arr[row + 2, col + 1] = 3; //down-right
            if ((row - 1) >= 0 && (col - 2) >= 0) arr[row - 1, col - 2] = 3; //left-up
            if ((row - 1) >= 0 && (col + 2) <= 7) arr[row - 1, col + 2] = 3; //right-up
            if ((row + 1) <= 7 && (col - 2) >= 0) arr[row + 1, col - 2] = 3; //left-down
            if ((row + 1) <= 7 && (col + 2) <= 7) arr[row + 1, col + 2] = 3; //right-down
        } 
        #endregion

    }
}
