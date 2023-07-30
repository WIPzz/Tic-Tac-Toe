using System;
using System.Windows.Forms;

/*
x - Create 1. window
    'Start Game' button = opens 2. window
    'Exit' button = closes the app
x - Create 2. window
    create a grid
    create two shapes
    place shapes on the white spaces of the grid
    shapes alternates
    Show whos turn it is
x - Win-Lose logic
    1-2-3
    4-5-6
    7-8-9
    
    1-4-7
    2-5-8
    3-6-9

    1-5-9
    3-5-7
x - Game ends
    Winner is...
    Play again
    Exit


Fix
- (KI  as opponent)
x - Improve playerTurn() logic (Cleaner code) (Module?)
x - Better Win-Lose logic
    array / list ?
x - Add a draw
x - Add a Score
x - Add a 2D Array for better code
x - Score goes up for winner of the round if game ended and more buttons are pressed
x - Restart game if score is resetted



*/


namespace Tic_Tac_Toe
{
    public partial class Form2 : Form
    {
        private Button[,] board;
        private int turnCount = 1;
        private bool gameEnded = false;

        private int playerX = 0;
        private int playerO = 0;

        public Form2()
        {
            InitializeComponent();
            board = new Button[3, 3] {
                { bttn1, bttn2, bttn3 },
                { bttn4, bttn5, bttn6 },
                { bttn7, bttn8, bttn9 }
            };
            textBox1.Text = "X";
        }

        //Ignore
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        // Click X / O button
        private void clickBttn(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!gameEnded && button.Text == "")
            {
                button.Text = (turnCount == 1) ? "X" : "O";
                turnCount = (turnCount % 2) + 1;
                textBox1.Text = (turnCount == 1) ? "X" : "O";
            }
            if (!gameEnded)
            {
                checkWin();
            }
        }

        // Checks if a player wins
        private void checkWin()
        {
            string[] players = { "X", "O" };

            foreach (string player in players)
            {
                for (int row = 0; row < 3; row++)
                {
                    // Check rows
                    if (board[row, 0].Text == player && board[row, 1].Text == player && board[row, 2].Text == player)
                    {
                        gameEnded = true;
                        textBox1.Text = $"{player} wins!";

                        // For score
                        if (player == "X")
                        {
                            playerX++;
                        }
                        else if (player == "O")
                        {
                            playerO++;
                        }
                        
                        scoreX.Text = "PlayerX: " + playerX.ToString();
                        scoreO.Text = "PlayerO: " + playerO.ToString();
                        return;
                    }

                    // Check columns
                    if (board[0, row].Text == player && board[1, row].Text == player && board[2, row].Text == player)
                    {
                        gameEnded = true;
                        textBox1.Text = $"{player} wins!";

                        // For score
                        if (player == "X")
                        {
                            playerX++;
                        }
                        else if (player == "O")
                        {
                            playerO++;
                        }

                        scoreX.Text = "PlayerX: " + playerX.ToString();
                        scoreO.Text = "PlayerO: " + playerO.ToString();
                        return;
                    }
                }

                // Check diagonals
                if ((board[0, 0].Text == player && board[1, 1].Text == player && board[2, 2].Text == player) ||
                    (board[0, 2].Text == player && board[1, 1].Text == player && board[2, 0].Text == player))
                {
                    gameEnded = true;
                    textBox1.Text = $"{player} wins!";

                    // For score
                    if (player == "X")
                    {
                        playerX++;
                    }
                    else if (player == "O")
                    {
                        playerO++;
                    }

                    scoreX.Text = "PlayerX: " + playerX.ToString();
                    scoreO.Text = "PlayerO: " + playerO.ToString();
                    return;
                }
            }

            // Check for a draw
            bool isDraw = true;
            foreach (Button button in board)
            {
                if (button.Text == "")
                {
                    isDraw = false;
                    break;
                }
            }

            if (isDraw)
            {
                gameEnded = true;
                textBox1.Text = "Draw";
            }
        }

        // Restart button
        private void restartBttn(object sender, EventArgs e)
        {
            textBox1.Text = "X";
            foreach (Button button in board)
            {
                button.Text = "";
            }

            gameEnded = false;
            turnCount = 1;
        }

        //Scoreboard
        private void resetScore(object sender, EventArgs e)
        {
            restartBttn(sender, e);
            playerX = 0;
            playerO = 0;
            scoreX.Text = "PlayerX: " + playerX.ToString();
            scoreO.Text = "PlayerO: " + playerO.ToString();
        }
    }
}

