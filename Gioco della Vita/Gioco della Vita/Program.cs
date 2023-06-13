using System.Text;

string[] unconvertedBoard = new string[] {
"-------------------------X----------" ,
"----------------------XXXX----X-----" ,
"-------------X-------XXXX-----X-----" ,
"------------X-X------X--X---------XX" ,
"-----------X---XX----XXXX---------XX" ,
"XX---------X---XX-----XXXX----------" ,
"XX---------X---XX--------X----------" ,
"------------X-X---------------------" ,
"-------------X----------------------" };



bool[,] board = ConvertBoard(unconvertedBoard, 20, 40);

while (true)
{
    RenderBoard(board);
    board = Calculate(board);

    //Console.ReadLine();
    Thread.Sleep(50);
}


bool[,] Calculate(bool[,] board)
{
    bool[,] newBoard = new bool[board.GetLength(0), board.GetLength(1)];
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            bool isAlive = board[i, j];
            int countBools = 0;
            int[] xVar = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
            int[] yVar = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
            //int[] xVar = new int[] { 0, -1 , 0, 1};
            //int[] yVar = new int[] { 1, 0, -1, 0};
            for (int count = 0; count < xVar.Length; count++)
            {
                int x = i + xVar[count];
                int y = j + yVar[count];
                if (x >= 0 && x < board.GetLength(0) && y >= 0 && y < board.GetLength(1))
                {
                    if (board[x, y])
                    {
                        countBools++;
                    }
                }
            }

            if (isAlive)
            {
                if (countBools == 2 || countBools == 3) { newBoard[i, j] = true; }
            }
            else //  if it is dead
            {
                if (countBools == 3) { newBoard[i, j] = true; }
            }

        }
    }
    return newBoard;
}


void RenderBoard(bool[,] board)
{
    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            sb.Append(board[i, j] ? ' ' : '█');
        }
        sb.Append('\n');
    }
    Console.Clear();
    Console.Write(sb.ToString());
}


bool[,] ConvertBoard(string[] unconvertedBoard, int xMaxSize, int yMaxSize)
{
    int x = unconvertedBoard.Length;
    int y = unconvertedBoard[0].Length;
    bool[,] board = new bool[xMaxSize, yMaxSize];
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            if (unconvertedBoard[i][j] == 'X')
            {
                board[i, j] = true;
            }
            else
            {
                board[i, j] = false;
            }
        }
    }
    return board;
}


