namespace Memesbiblioteca
{
    public partial class Form1 : Form
    {
        string[] memes;
        int index = 0;
        public Form1()
        {
            InitializeComponent();
            memes = new string[]
            {
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem1.jpg",
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem2.jpg",
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem3.jpg",
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem4.jpg",
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem5.jpg",
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem6.jpg",
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem7.jpg",
                @"C:\Users\Student\source\repos\agrus52\winformsivan\Memesbiblioteca\Mem8.jpg"
            };

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            ShowMeme();
        }
        private void ShowMeme()
        {
            if (memes.Length > 0)
            {
                pictureBox1.Image = Image.FromFile(memes[index]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index++;

            if (index >= memes.Length)
            {
                index = 0;
            }

            ShowMeme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index--;

            if (index < 0)
            {
                index = memes.Length - 1;
            }

            ShowMeme();
        }
    }
    }

