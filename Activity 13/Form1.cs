namespace Activity_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            NewGame();
        }

        private void NewGame()
        {
            //initializes board (-1 represents empty space)
            int[,] board = { { -1, -1, -1 },
                             { -1, -1, -1 },
                             { -1, -1, -1 } };

            int turn = 1;
            //checks for winner
            bool isWon = false;
            while (turn <= 9)
            {
                //update board with new placement
                board = PlaceMark(turn % 2, board);
                //display board after each turn
                DisplayBoard(board);
                //checks to see if a winner
                isWon = IsWinner(board);
                if (isWon)
                {
                    //if someone one, determine who based on last placement. 
                    if (turn % 2 == 0)
                    {
                        winnerLabel.Text = "O wins!";
                    }
                    else
                    {
                        winnerLabel.Text = "X wins!";
                    }
                    //breaks turn-based while loop, ending game
                    break;
                }
                turn++;
            }
            
            //used if turn order finishes with no winner
            if (!isWon)
            {
                winnerLabel.Text = "Draw!";
            }

        }

        //Method to place the marking using random number generator
        private int[,] PlaceMark(int turn, int[,] board)
        {
            Random r = new Random();
            //initialize row and col, never uses -1 value
            int row = -1, col = -1;
            //initialize boolean to make while loop function
            bool taken = true;
            while (taken)
            {
                //randomize row and col from 0-2
                row = r.Next(3);
                col = r.Next(3);
                //if space on row and col is not -1, it is taken, so skips if statement
                if (board[row, col] == -1)
                {
                    taken = false;
                }
            }

            //turn is modded, making it either 0 or 1 (0 represent O, 1 represents X)
            board[row, col] = turn;


            //returns updated board with new placement
            return board;
        }

        private bool IsWinner(int[,] board)
        {
            //Check top left corner for wins
            int check = board[0, 0];
            //across top row
            if (board[0, 1] == check && board[0, 2] == check && check != -1)
            {
                return true;
            }
            //diagonally down
            if (board[1, 1] == check && board[2, 2] == check && check != -1)
            {
                return true;
            }
            //down left col
            if (board[1, 0] == check && board[2, 0] == check && check != -1)
            {
                return true;
            }

            //Check mid left box for wins
            check = board[1, 0];
            //across middle row
            if (board[1, 1] == check && board[1, 2] == check && check != -1)
            {
                return true;
            }

            //check bottom left corner for wins
            check = board[2, 0];
            //diagonally up
            if (board[1, 1] == check && board[0, 2] == check && check != -1)
            {
                return true;
            }
            //across bottom row
            if (board[2, 1] == check && board[2, 2] == check && check != -1)
            {
                return true;
            }

            //check top middle box for wins
            check = board[0, 1];
            //down middle col
            if (board[1, 1] == check && board[2, 1] == check && check != -1)
            {
                return true;
            }

            //check top right corner for wins
            check = board[0, 2];
            //down right col
            if (board[1, 2] == check && board[2, 2] == check && check != -1)
            {
                return true;
            }

            //if none above match, return false
            return false;

        }

        //Method to display the board
        private void DisplayBoard(int[,] board)
        {
            //nested for-loop to traverse 2-dimensional array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //nested if statements to determine which box to edit
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            if (board[i, j] == 0)
                            {
                                box0_0.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box0_0.Text = "X";
                            }
                            //if slot is still -1, leaves blank
                        }
                        else if (j == 1)
                        {
                            if (board[i, j] == 0)
                            {
                                box0_1.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box0_1.Text = "X";
                            }
                        }
                        else
                        {
                            if (board[i, j] == 0)
                            {
                                box0_2.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box0_2.Text = "X";
                            }
                        }
                    }
                    else if (i == 1)
                    {
                        if (j == 0)
                        {
                            if (board[i, j] == 0)
                            {
                                box1_0.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box1_0.Text = "X";
                            }
                        }
                        else if (j == 1)
                        {
                            if (board[i, j] == 0)
                            {
                                box1_1.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box1_1.Text = "X";
                            }
                        }
                        else
                        {
                            if (board[i, j] == 0)
                            {
                                box1_2.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box1_2.Text = "X";
                            }
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            if (board[i, j] == 0)
                            {
                                box2_0.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box2_0.Text = "X";
                            }
                        }
                        else if (j == 1)
                        {
                            if (board[i, j] == 0)
                            {
                                box2_1.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box2_1.Text = "X";
                            }
                        }
                        else
                        {
                            if (board[i, j] == 0)
                            {
                                box2_2.Text = "O";
                            }
                            else if (board[i, j] == 1)
                            {
                                box2_2.Text = "X";
                            }
                        }
                    }
                }
            }
        }

        //Method to clear boxes between each round
        private void ClearBoxes()
        {
            box0_0.Text = "";
            box0_1.Text = "";
            box0_2.Text = "";
            box1_0.Text = "";
            box1_1.Text = "";
            box1_2.Text = "";
            box2_0.Text = "";
            box2_1.Text = "";
            box2_2.Text = "";
        }
    }
}