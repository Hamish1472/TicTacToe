namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe!\n");
            Console.WriteLine("Start?");
            string start = Console.ReadLine().ToLower();
            while (start == "yes" || start == "y")
            {
                Console.Clear();

                int[,] grid = {
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 }
                };
                int player = 1;

                while (true)
                {
                    DrawGrid(grid);
                    Console.WriteLine($"Player {player}, choose square in grid");
                    string coord = Console.ReadLine().ToUpper();
                    UpdateGrid(coord, grid, player);
                    if (Win(grid) || Full(grid))
                    {
                        Console.Clear();
                        DrawGrid(grid);
                        if (Win(grid))
                        {
                            Console.WriteLine($"Congratulations Player {player}, YOU WIN!\n");
                        }
                        else if (Full(grid))
                        {
                            Console.WriteLine("No Winners This Time!");
                        }
                        Console.WriteLine("Play Again?");
                        start = Console.ReadLine();
                        break;
                    }
                    switch (player)
                    {
                        case 1: player = 2; break;
                        case 2: player = 1; break;
                    }
                    Console.Clear();
                }
            }
        }
        static bool Full(int[,] grid)
        {
            // Check for empty square
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i,j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool Win(int[,] grid)
        {
            // Check Rows
            for (int i = 0; i < 3; i++)
            {
                int rowVal = grid[i, 0];
                if (rowVal == 0)
                {
                    continue;
                }
                bool match = true;
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] != rowVal)
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return true;
                }
            }

            // Check Cols
            for (int j = 0; j < 3; j++)
            {
                int colVal = grid[0, j];
                if (colVal == 0)
                {
                    continue;
                }
                bool match = true;
                for (int i = 0; i < 3; i++)
                {
                    if (grid[i, j] != colVal)
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return true;
                }
            }

            // Check Diagonals
            if (grid[1,1] != 0)
            {
                if (grid[0,0] == grid[1,1] && grid[0,0] == grid[2,2])
                {
                    return true;
                }
                if (grid[0,2] == grid[1,1] && grid[0,2] == grid[2,0])
                {
                    return true;
                }
            }

            return false;
        }

        static void UpdateGrid(string coord, int[,] grid, int player)
        {
            bool validCoord = GetCoordinates(coord, out int row, out int col);
            while (!validCoord || grid[row, col] != 0)
            {
                Console.WriteLine("Invalid Placement");
                Console.WriteLine("Re-Enter Placement: ");
                coord = Console.ReadLine().ToUpper();
                validCoord = GetCoordinates(coord, out row, out col);
            }

            grid[row, col] = player;
        }

        static bool GetCoordinates(string coord, out int row, out int col)
        {
            row = -1;
            col = -1;

            if (coord.Length != 1)
                return false;

            int index = coord[0] - 'A';

            if (index < 0 || index >= 9)
                return false;

            row = index / 3;
            col = index % 3;

            return true;
        }

        static void DrawGrid(int[,] grid)
        {
            Dictionary<int, string> xo = new()
            {
                [0] = " ",
                [1] = "X",
                [2] = "O"
            };

            Console.WriteLine("A      |B      |C      ");                                                   // A      |B      |C      
            Console.WriteLine($"   {xo[grid[0, 0]]}   |   {xo[grid[0, 1]]}   |   {xo[grid[0, 2]]}   ");     //        |       |       
            Console.WriteLine("       |       |       ");                                                   //        |       |       
            Console.WriteLine("-----------------------");                                                   // -----------------------
            Console.WriteLine("D      |E      |F      ");                                                   // D      |E      |F      
            Console.WriteLine($"   {xo[grid[1, 0]]}   |   {xo[grid[1, 1]]}   |   {xo[grid[1, 2]]}   ");     //        |       |       
            Console.WriteLine("       |       |       ");                                                   //        |       |       
            Console.WriteLine("-----------------------");                                                   // -----------------------
            Console.WriteLine("G      |H      |I      ");                                                   // G      |H      |I      
            Console.WriteLine($"   {xo[grid[2, 0]]}   |   {xo[grid[2, 1]]}   |   {xo[grid[2, 2]]}   ");     //        |       |       
            Console.WriteLine("       |       |       ");                                                   //        |       |       
        }
    }
}