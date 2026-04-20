namespace Saper
{
    public partial class Form1 : Form
    {

        const int rows = 8;
        const int cols = 8;
        const int minesCount = 10;

        Button[,] buttons = new Button[rows, cols];
        bool[,] mines = new bool[rows, cols];
        bool[,] opened = new bool[rows, cols];

        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            StartGame();
        }
        private void StartGame()
        {
            this.Controls.Clear();

            CreateField();
            PlaceMines();
        }
        private void CreateField()
        {
            int buttonSize = 40;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Location = new Point(j * buttonSize, i * buttonSize);
                    btn.Font = new Font("Arial", 12, FontStyle.Bold);
                    btn.Tag = new Point(i, j);
                    btn.Click += Cell_Click;

                    buttons[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }
            this.ClientSize = new Size(cols * buttonSize, rows * buttonSize);
        }

        private void PlaceMines()
        {
            int placed = 0;

            while (placed < minesCount)
            {
                int x = random.Next(rows);
                int y = random.Next(cols);

                if (!mines[x, y])
                {
                    mines[x, y] = true;
                    placed++;
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Point point = (Point)btn.Tag;

            int x = point.X;
            int y = point.Y;

            if (opened[x, y])
                return;

            OpenCell(x, y);

            CheckWin();
        }

        private void OpenCell(int x, int y)
        {
            if (x < 0 || y < 0 || x >= rows || y >= cols)
                return;

            if (opened[x, y])
                return;

            opened[x, y] = true;
            buttons[x, y].Enabled = false;

            if (mines[x, y])
            {
                buttons[x, y].Text = "*";
                buttons[x, y].BackColor = Color.Red;
                ShowAllMines();
                MessageBox.Show("Ти програв!");
                return;
            }

            int count = CountMinesAround(x, y);

            if (count > 0)
            {
                buttons[x, y].Text = count.ToString();
            }
            else
            {
                buttons[x, y].Text = "";

                OpenCell(x - 1, y);
                OpenCell(x + 1, y);
                OpenCell(x, y - 1);
                OpenCell(x, y + 1);
                OpenCell(x - 1, y - 1);
                OpenCell(x - 1, y + 1);
                OpenCell(x + 1, y - 1);
                OpenCell(x + 1, y + 1);
            }
        }

        private int CountMinesAround(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < rows && j < cols)
                    {
                        if (mines[i, j])
                            count++;
                    }
                }
            }

            return count;
        }

        private void ShowAllMines()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mines[i, j])
                    {
                        buttons[i, j].Text = "*";
                        buttons[i, j].BackColor = Color.LightPink;
                    }

                    buttons[i, j].Enabled = false;
                }
            }
        }

        private void CheckWin()
        {
            int openedCount = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (opened[i, j] && !mines[i, j])
                        openedCount++;
                }
            }

            if (openedCount == rows * cols - minesCount)
            {
                MessageBox.Show("Ти виграв!");
                ShowAllMines();
            }
        }
    }
}


