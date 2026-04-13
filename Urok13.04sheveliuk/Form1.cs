namespace Urok13._04sheveliuk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Random rand = new Random();

            int x = rand.Next(0, this.ClientSize.Width - button1.Width);
            int y = rand.Next(0, this.ClientSize.Height - button1.Height);

            button1.Location = new Point(x, y);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                if (button8.Text == "")
                    button8.Text = "X";
                else if (button8.Text == "X")
                    button8.Text = "O";
                else
                    button8.Text = "X";

                CheckWinner();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (button3.Text == "")
                    button3.Text = "X";
                else if (button3.Text == "X")
                    button3.Text = "O";
                else
                    button3.Text = "X";

                CheckWinner();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                if (button7.Text == "")
                    button7.Text = "X";
                else if (button7.Text == "X")
                    button7.Text = "O";
                else
                    button7.Text = "X";

                CheckWinner();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (button2.Text == "")
                    button2.Text = "X";
                else if (button2.Text == "X")
                    button2.Text = "O";
                else
                    button2.Text = "X";

                CheckWinner();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (button4.Text == "")
                    button4.Text = "X";
                else if (button4.Text == "X")
                    button4.Text = "O";
                else
                    button4.Text = "X";

                CheckWinner();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                if (button5.Text == "")
                    button5.Text = "X";
                else if (button2.Text == "X")
                    button5.Text = "O";
                else
                    button5.Text = "X";

                CheckWinner();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                if (button6.Text == "")
                    button6.Text = "X";
                else if (button6.Text == "X")
                    button6.Text = "O";
                else
                    button6.Text = "X";

                CheckWinner();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            {
                if (button10.Text == "")
                    button10.Text = "X";
                else if (button10.Text == "X")
                    button10.Text = "O";
                else
                    button10.Text = "X";

                CheckWinner();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            {
                if (button9.Text == "")
                    button9.Text = "X";
                else if (button9.Text == "X")
                    button9.Text = "O";
                else
                    button9.Text = "X";

                CheckWinner();
            }
        }
        private void CheckWinner()
        {
            
            if (button2.Text != "" && button2.Text == button3.Text && button3.Text == button4.Text)
            {
                MessageBox.Show("Виграв " + button2.Text);
                ResetGame();
                return;
            }

            
            if (button5.Text != "" && button5.Text == button6.Text && button6.Text == button7.Text)
            {
                MessageBox.Show("Виграв " + button5.Text);
                ResetGame();
                return;
            }

            
            if (button8.Text != "" && button8.Text == button9.Text && button9.Text == button10.Text)
            {
                MessageBox.Show("Виграв " + button8.Text);
                ResetGame();
                return;
            }

           
            if (button2.Text != "" && button2.Text == button5.Text && button5.Text == button8.Text)
            {
                MessageBox.Show("Виграв " + button2.Text);
                ResetGame();
                return;
            }

            
            if (button3.Text != "" && button3.Text == button6.Text && button6.Text == button9.Text)
            {
                MessageBox.Show("Виграв " + button3.Text);
                ResetGame();
                return;
            }

            
            if (button4.Text != "" && button4.Text == button7.Text && button7.Text == button10.Text)
            {
                MessageBox.Show("Виграв " + button4.Text);
                ResetGame();
                return;
            }

            
            if (button2.Text != "" && button2.Text == button6.Text && button6.Text == button10.Text)
            {
                MessageBox.Show("Виграв " + button2.Text);
                ResetGame();
                return;
            }

            
            if (button4.Text != "" && button4.Text == button6.Text && button6.Text == button8.Text)
            {
                MessageBox.Show("Виграв " + button4.Text);
                ResetGame();
                return;
            }
        }
         private void ResetGame()
        {
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
        }





    } 
}
