using System.Xml.Linq;

namespace WinFormssheveliuk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))

            {
                MessageBox.Show("Усі поля є обов'язковими!");
                return; // Зупиняємо виконання
            }
                MessageBox.Show(
                    "Дані успішно збережені!" + "\n" +
                    "Ім'я: " + textBox1.Text + "\n" +
                    "Прізвище: " + textBox2.Text + "\n" +
                    "Вік: " + textBox3.Text + "\n" +
                    "Назва команди: " + textBox4.Text



                        
                    );
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int min = 1;
            int max = 100;
            int value = Convert.ToInt32(textBox3.Text);


            if (!int.TryParse(textBox3.Text, out value))
            {

                MessageBox.Show("Будь ласка, введіть коректне число.");
                
            }

            else if (value < min || value > max)
            {
                MessageBox.Show($"Число має бути в діапазоні від {min} до {max}.");
                
            }


        }
            private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
            }
        }

    }


