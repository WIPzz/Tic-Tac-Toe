using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
- Better Win-Lose logic
    array / list ?
- Add a draw
- Add a Score


*/

namespace Tic_Tac_Toe
{
    public partial class Form2 : Form
    {
        int turnCount = 1;

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;

        bool gameEnded = false;


        public Form2()
        {
            InitializeComponent();
            button1 = bttn1;
            button2 = bttn2;
            button3 = bttn3;
            button4 = bttn4;
            button5 = bttn5;
            button6 = bttn6;
            button7 = bttn7;
            button8 = bttn8;
            button9 = bttn9;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Shape buttons
        private void clickBttn(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Checks if the game ended
            if (!gameEnded && button.Text == "")
            {
                playerTurn(button);
                checkWin();
            }
        }
        
        // Swaps between Player1 & Player2
        private void playerTurn(Button button)
        {
            turnCount = (turnCount % 2) + 1;

            button.Text = (turnCount == 1) ? "X" : "O";
            textBox1.Text = (turnCount == 1) ? "O" : "X";
        }

        // Win logic
        private void checkWin()
        {
            if (bttn1.Text == "X" && bttn2.Text == "X" && bttn3.Text == "X" ||
                bttn4.Text == "X" && bttn5.Text == "X" && bttn6.Text == "X" ||
                bttn7.Text == "X" && bttn8.Text == "X" && bttn9.Text == "X" ||
                bttn1.Text == "X" && bttn4.Text == "X" && bttn7.Text == "X" ||
                bttn2.Text == "X" && bttn5.Text == "X" && bttn8.Text == "X" ||
                bttn3.Text == "X" && bttn6.Text == "X" && bttn9.Text == "X" ||
                bttn1.Text == "X" && bttn5.Text == "X" && bttn9.Text == "X" ||
                bttn3.Text == "X" && bttn5.Text == "X" && bttn7.Text == "X")
            {
                textBox1.Text = "Player1 wins!";
                gameEnded = true;
                return;

            }
            else if (bttn1.Text == "O" && bttn2.Text == "O" && bttn3.Text == "O" ||
                     bttn4.Text == "O" && bttn5.Text == "O" && bttn6.Text == "O" ||
                     bttn7.Text == "O" && bttn8.Text == "O" && bttn9.Text == "O" ||
                     bttn1.Text == "O" && bttn4.Text == "O" && bttn7.Text == "O" ||
                     bttn2.Text == "O" && bttn5.Text == "O" && bttn8.Text == "O" ||
                     bttn3.Text == "O" && bttn6.Text == "O" && bttn9.Text == "O" ||
                     bttn1.Text == "O" && bttn5.Text == "O" && bttn9.Text == "O" ||
                     bttn3.Text == "O" && bttn5.Text == "O" && bttn7.Text == "O")
            {
                textBox1.Text = "Player2 wins!";
                gameEnded = true;
                return;
            }
        }

        //Restart button
        private void restartBttn(object sender, EventArgs e)
        {
            textBox1.Text = "O";
            bttn1.Text = "";
            bttn2.Text = "";
            bttn3.Text = "";
            bttn4.Text = "";
            bttn5.Text = "";
            bttn6.Text = "";
            bttn7.Text = "";
            bttn8.Text = "";
            bttn9.Text = "";
            gameEnded = false;
            turnCount = 1;
        }
    }
}
