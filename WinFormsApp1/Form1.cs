namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isX = true;

        private void X_Victory()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
            else if (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
            else if (button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
            else if (button1.Text == "X" && button4.Text == "X" && button7.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
            else if (button2.Text == "X" && button5.Text == "X" && button8.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
            else if (button3.Text == "X" && button6.Text == "X" && button9.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
            else if (button1.Text == "X" && button5.Text == "X" && button9.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
            else if (button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                MessageBox.Show("X wins!");
            }
        }

        private void O_Victory()
        {
            if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
            else if (button4.Text == "O" && button5.Text == "O" && button6.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
            else if (button7.Text == "O" && button8.Text == "O" && button9.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
            else if (button1.Text == "O" && button4.Text == "O" && button7.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
            else if (button2.Text == "O" && button5.Text == "O" && button8.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
            else if (button3.Text == "O" && button6.Text == "O" && button9.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
            else if (button1.Text == "O" && button5.Text == "O" && button9.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
            else if (button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                MessageBox.Show("O wins!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button1.Text = "O";
                isX = false;
            }
            else
            {
                button1.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button2.Text = "O";
                isX = false;
            }
            else
            {
                button2.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button3.Text = "O";
                isX = false;
            }
            else
            {
                button3.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button4.Text = "O";
                isX = false;
            }
            else
            {
                button4.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button5.Text = "O";
                isX = false;
            }
            else
            {
                button5.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button6.Text = "O";
                isX = false;
            }
            else
            {
                button6.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button7.Text = "O";
                isX = false;
            }
            else
            {
                button7.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button8.Text = "O";
                isX = false;
            }
            else
            {
                button8.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isX)
            {
                button9.Text = "O";
                isX = false;
            }
            else
            {
                button9.Text = "X";
                isX = true;
            }

            X_Victory();
            O_Victory();
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.Left += 1;
            button10.Top += 1;
        }
    }
}
