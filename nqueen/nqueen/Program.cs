using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nqueen
{
    class Program
    {
       
        public  int[,] chessBoard ;
        private static int N = 8;

        public Program(int [,]chessBoard)
        {
            this.chessBoard = chessBoard;
        }

     
    public  void print() {
        for (int row = 0; row < N; row++) {
            for (int col = 0; col < N; col++) {
                Console.Write(chessBoard[row,col] + " ");
            }
            Console.WriteLine();
        }
    }

    public  bool placeQueen( int col) {
        if (col >= N) {
            return true;
        }

        for (int row = 0; row < N; row++) {
            
            if (isSafe( row, col)) {
                chessBoard[row,col] = 1;
                if (placeQueen( col + 1)) {
                    return true;
                }
            }
            chessBoard[row,col] = 0;
        }

        return false;
    }

    public  bool isSafe( int row, int col) {
        
        
        //check safe row 

        for (int i = 0; i < N; i++)
        {
            if (chessBoard[i,col] == 1)
                return false;
        }

        // check if it is already a queen on the same column
        for (int i = 0; i < N; i++)
        {
            if (chessBoard[row,i] == 1)
                return false;
        }
        // now the diagonals.. a little bit more complicated
        // going down right
        int X = row;
        int Y = col;
        while (X < N && Y < N)
        {
            if (chessBoard[X,Y] == 1)
                return false;
            X++;
            Y++;
        }
        // going up left
        X = row - 1;
        Y = col - 1;
        while (X >= 0 && Y >= 0)
        {
            if (chessBoard[X,Y] == 1)
                return false;
            X--;
            Y--;
        }
        // going up right
        X = row + 1;
        Y = col - 1;
        while (X < N && Y >= 0)
        {
            if (chessBoard[X,Y] == 1)
                return false;
            X++;
            Y--;
        }
        // going down left
        X = row - 1;
        Y = col + 1;
        while (X >= 0 && Y < N)
        {
            if (chessBoard[X,Y] == 1)
                return false;
            X--;
            Y++;
        }
        // ok pass  
        return true;
    }

        static void Main(string[] args)
        {
           int [,] solu = new int[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    solu[i,j] = 0;
                }
            }

            Program nqueen = new Program(solu);

            nqueen.placeQueen(0);
            nqueen.print();
            Console.ReadLine();
        }
    }
}
