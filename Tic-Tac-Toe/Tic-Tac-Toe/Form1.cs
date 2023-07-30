using System;
using System.Windows.Forms;


/*
- Create 1. window
    'Start Game' button = opens 2. window
    'Exit' button = closes the app
- Create 2. window
    create a grid
    create two shapes
    place shapes on the white spaces of the grid
    shapes alternates
    Show whos turn it is
- Win-Lose logic
- Game ends
    Winner is...
    Play again
    Exit





*/

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
