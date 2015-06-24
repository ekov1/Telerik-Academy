namespace MineSweeper
{
    using System;
    using System.Collections.Generic;

    public class MineSweeper
    {
        public static void Main()
        {
            const int MAX = 35;

            string command = string.Empty;
            char[,] field = GenerateField();
            char[,] mines = PlaceMines();
            int uncoveredTiles = 0;
            bool gameOver = false;
            var scores = new List<Highscore>(6);
            int row = 0;
            int col = 0;
            bool newGame = true;
            bool victoryAchieved = false;

            do
            {
                if (newGame)
                {
                    Console.WriteLine(">>> Mine Sweeper - The Ultimate Console Edition <<<\n\rTry uncovering all fields without stepping on a mine.\n\r" +
                    "Commands: 'top' - displays the Highscore\n\r'restart' - initiates a new game\n\r'exit' - terminates the game.");

                    DisplayPlayfield(field);
                    newGame = false;
                }

                Console.Write("Row & Column to be reveal?: ");

                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                    row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        DisplayScore(scores);
                        break;
                    case "restart":
                        field = GenerateField();
                        mines = PlaceMines();
                        DisplayPlayfield(field);
                        gameOver = false;
                        newGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                PlayerTurn(field, mines, row, col);
                                uncoveredTiles++;
                            }
                            if (MAX == uncoveredTiles)
                            {
                                victoryAchieved = true;
                            }
                            else
                            {
                                DisplayPlayfield(field);
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (gameOver)
                {
                    DisplayPlayfield(mines);

                    Console.Write("\nGAME OVER!\n\rYou stepped on a mine with {0} uncovered tiles. Good job! " +
                        "What is your name? : ", uncoveredTiles);
                    string nickname = Console.ReadLine();

                    var currentScore = new Highscore(nickname, uncoveredTiles);

                    if (scores.Count < 5)
                    {
                        scores.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < scores.Count; i++)
                        {
                            if (scores[i].Score < currentScore.Score)
                            {
                                scores.Insert(i, currentScore);
                                scores.RemoveAt(scores.Count - 1);
                                break;
                            }
                        }
                    }

                    scores.Sort((Highscore r1, Highscore r2) => r2.Name.CompareTo(r1.Name));
                    scores.Sort((Highscore r1, Highscore r2) => r2.Score.CompareTo(r1.Score));
                    DisplayScore(scores);

                    field = GenerateField();
                    mines = PlaceMines();
                    uncoveredTiles = 0;
                    gameOver = false;
                    newGame = true;
                }

                if (victoryAchieved)
                {
                    Console.WriteLine("\nCongratulations! You managed to reveal all 35 tiles without triggering a mine!");
                    DisplayPlayfield(mines);
                    Console.WriteLine("What is your name? : ");
                    string nickname = Console.ReadLine();

                    var currentScore = new Highscore(nickname, uncoveredTiles);
                    scores.Add(currentScore);
                    DisplayScore(scores);

                    field = GenerateField();
                    mines = PlaceMines();
                    uncoveredTiles = 0;
                    victoryAchieved = false;
                    newGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Thank you for playing. Do come back some day!");
            Console.Read();
        }

        private static void DisplayScore(List<Highscore> score)
        {
            Console.WriteLine("\nHighscores:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} uncovered tiles", i + 1, score[i].Name, score[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no highscores at the moment!\n");
            }
        }

        private static void PlayerTurn(char[,] field, char[,] mines, int row, int col)
        {
            char mineCount = AdjacentMines(mines, row, col);
            mines[row, col] = mineCount;
            field[row, col] = mineCount;
        }

        private static void DisplayPlayfield(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GenerateField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            var mines = new List<int>();
            while (mines.Count < 15)
            {
                var random = new Random();
                int mineId = random.Next(50);
                if (!mines.Contains(mineId))
                {
                    mines.Add(mineId);
                }
            }

            foreach (var mine in mines)
            {
                int col = (mine / cols);
                int row = (mine % cols);
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static char AdjacentMines(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}