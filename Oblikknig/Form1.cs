
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Oblikknig
{
    public partial class Form1 : Form
    {
        private List<Book> books = new List<Book>();

        private DataGridView dgvBooks;

        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtYear;
        private TextBox txtGenre;
        private TextBox txtReader;
        private TextBox txtSearch;

        private ComboBox cmbStatus;

        private Button btnAdd;
        private Button btnIssue;
        private Button btnReturn;
        private Button btnShowAll;
        private Button btnShowAvailable;
        private Button btnShowIssued;
        private Button btnSearch;
        private Button btnClear;

        private readonly string booksFile = "books.txt";
        private readonly string historyFile = "history.txt";

        public Form1()
        {
            InitializeComponent();
            CreateInterface();
            LoadBooksFromFile();
            RefreshTable(books);
        }

        private void CreateInterface()
        {
            this.Text = "Бібліотечний каталог";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label();
            lblTitle.Text = "Назва книги:";
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(120, 25);
            this.Controls.Add(lblTitle);

            txtTitle = new TextBox();
            txtTitle.Location = new Point(150, 20);
            txtTitle.Size = new Size(220, 25);
            this.Controls.Add(txtTitle);

            Label lblAuthor = new Label();
            lblAuthor.Text = "Автор:";
            lblAuthor.Location = new Point(20, 60);
            lblAuthor.Size = new Size(120, 25);
            this.Controls.Add(lblAuthor);

            txtAuthor = new TextBox();
            txtAuthor.Location = new Point(150, 60);
            txtAuthor.Size = new Size(220, 25);
            this.Controls.Add(txtAuthor);

            Label lblYear = new Label();
            lblYear.Text = "Рік видання:";
            lblYear.Location = new Point(20, 100);
            lblYear.Size = new Size(120, 25);
            this.Controls.Add(lblYear);

            txtYear = new TextBox();
            txtYear.Location = new Point(150, 100);
            txtYear.Size = new Size(220, 25);
            this.Controls.Add(txtYear);

            Label lblGenre = new Label();
            lblGenre.Text = "Жанр:";
            lblGenre.Location = new Point(20, 140);
            lblGenre.Size = new Size(120, 25);
            this.Controls.Add(lblGenre);

            txtGenre = new TextBox();
            txtGenre.Location = new Point(150, 140);
            txtGenre.Size = new Size(220, 25);
            this.Controls.Add(txtGenre);

            Label lblStatus = new Label();
            lblStatus.Text = "Статус:";
            lblStatus.Location = new Point(20, 180);
            lblStatus.Size = new Size(120, 25);
            this.Controls.Add(lblStatus);

            cmbStatus = new ComboBox();
            cmbStatus.Location = new Point(150, 180);
            cmbStatus.Size = new Size(220, 25);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.Add("доступна");
            cmbStatus.Items.Add("видана");
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);

            Label lblReader = new Label();
            lblReader.Text = "Читач:";
            lblReader.Location = new Point(20, 220);
            lblReader.Size = new Size(120, 25);
            this.Controls.Add(lblReader);

            txtReader = new TextBox();
            txtReader.Location = new Point(150, 220);
            txtReader.Size = new Size(220, 25);
            this.Controls.Add(txtReader);

            btnAdd = new Button();
            btnAdd.Text = "Додати книгу";
            btnAdd.Location = new Point(20, 270);
            btnAdd.Size = new Size(160, 35);
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            btnIssue = new Button();
            btnIssue.Text = "Видати книгу";
            btnIssue.Location = new Point(210, 270);
            btnIssue.Size = new Size(160, 35);
            btnIssue.Click += BtnIssue_Click;
            this.Controls.Add(btnIssue);

            btnReturn = new Button();
            btnReturn.Text = "Повернути книгу";
            btnReturn.Location = new Point(20, 320);
            btnReturn.Size = new Size(160, 35);
            btnReturn.Click += BtnReturn_Click;
            this.Controls.Add(btnReturn);

            btnClear = new Button();
            btnClear.Text = "Очистити поля";
            btnClear.Location = new Point(210, 320);
            btnClear.Size = new Size(160, 35);
            btnClear.Click += BtnClear_Click;
            this.Controls.Add(btnClear);

            Label lblSearch = new Label();
            lblSearch.Text = "Пошук:";
            lblSearch.Location = new Point(20, 390);
            lblSearch.Size = new Size(120, 25);
            this.Controls.Add(lblSearch);

            txtSearch = new TextBox();
            txtSearch.Location = new Point(150, 390);
            txtSearch.Size = new Size(220, 25);
            this.Controls.Add(txtSearch);

            btnSearch = new Button();
            btnSearch.Text = "Шукати";
            btnSearch.Location = new Point(20, 430);
            btnSearch.Size = new Size(160, 35);
            btnSearch.Click += BtnSearch_Click;
            this.Controls.Add(btnSearch);

            btnShowAll = new Button();
            btnShowAll.Text = "Усі книги";
            btnShowAll.Location = new Point(210, 430);
            btnShowAll.Size = new Size(160, 35);
            btnShowAll.Click += BtnShowAll_Click;
            this.Controls.Add(btnShowAll);

            btnShowAvailable = new Button();
            btnShowAvailable.Text = "Доступні";
            btnShowAvailable.Location = new Point(20, 480);
            btnShowAvailable.Size = new Size(160, 35);
            btnShowAvailable.Click += BtnShowAvailable_Click;
            this.Controls.Add(btnShowAvailable);

            btnShowIssued = new Button();
            btnShowIssued.Text = "Видані";
            btnShowIssued.Location = new Point(210, 480);
            btnShowIssued.Size = new Size(160, 35);
            btnShowIssued.Click += BtnShowIssued_Click;
            this.Controls.Add(btnShowIssued);

            dgvBooks = new DataGridView();
            dgvBooks.Location = new Point(400, 20);
            dgvBooks.Size = new Size(660, 550);
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AutoGenerateColumns = false;

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Назва",
                DataPropertyName = "Title",
                Width = 150
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Автор",
                DataPropertyName = "Author",
                Width = 120
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Рік",
                DataPropertyName = "Year",
                Width = 60
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Жанр",
                DataPropertyName = "Genre",
                Width = 100
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Статус",
                DataPropertyName = "Status",
                Width = 90
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Читач",
                DataPropertyName = "Reader",
                Width = 100
            });

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Дата видачі",
                DataPropertyName = "IssueDate",
                Width = 120
            });

            this.Controls.Add(dgvBooks);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string genre = txtGenre.Text.Trim();
            string status = cmbStatus.SelectedItem.ToString();
            string reader = txtReader.Text.Trim();

            if (title == "" || author == "" || txtYear.Text.Trim() == "" || genre == "")
            {
                MessageBox.Show("Заповніть усі обов'язкові поля.");
                return;
            }

            int year;

            if (!int.TryParse(txtYear.Text.Trim(), out year))
            {
                MessageBox.Show("Рік видання має бути числом.");
                return;
            }

            if (year <= 0 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Рік видання має бути більшим за 0 і не більшим за поточний рік.");
                return;
            }

            if (status == "видана" && reader == "")
            {
                MessageBox.Show("Якщо книга видана, потрібно вказати читача.");
                return;
            }

            Book book = new Book();
            book.Title = title;
            book.Author = author;
            book.Year = year;
            book.Genre = genre;
            book.Status = status;

            if (status == "видана")
            {
                book.Reader = reader;
                book.IssueDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            }
            else
            {
                book.Reader = "";
                book.IssueDate = "";
            }

            books.Add(book);

            AddHistory("Додано книгу: \"" + book.Title + "\" — " + book.Author);

            SaveBooksToFile();
            RefreshTable(books);
            ClearInputFields();

            MessageBox.Show("Книгу успішно додано.");
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {
            Book selectedBook = GetSelectedBook();

            if (selectedBook == null)
            {
                MessageBox.Show("Оберіть книгу в таблиці.");
                return;
            }

            if (selectedBook.Status == "видана")
            {
                MessageBox.Show("Ця книга вже видана.");
                return;
            }

            string reader = txtReader.Text.Trim();

            if (reader == "")
            {
                MessageBox.Show("Введіть ім'я читача у поле 'Читач'.");
                return;
            }

            selectedBook.Status = "видана";
            selectedBook.Reader = reader;
            selectedBook.IssueDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            AddHistory("Видано книгу: \"" + selectedBook.Title + "\" читачу: " + reader);

            SaveBooksToFile();
            RefreshTable(books);

            MessageBox.Show("Книгу видано читачу.");
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Book selectedBook = GetSelectedBook();

            if (selectedBook == null)
            {
                MessageBox.Show("Оберіть книгу в таблиці.");
                return;
            }

            if (selectedBook.Status == "доступна")
            {
                MessageBox.Show("Ця книга вже доступна.");
                return;
            }

            string oldReader = selectedBook.Reader;

            selectedBook.Status = "доступна";
            selectedBook.Reader = "";
            selectedBook.IssueDate = "";

            AddHistory("Повернуто книгу: \"" + selectedBook.Title + "\" від читача: " + oldReader);

            SaveBooksToFile();
            RefreshTable(books);

            MessageBox.Show("Книгу повернуто.");
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (searchText == "")
            {
                RefreshTable(books);
                return;
            }

            List<Book> foundBooks = books
                .Where(book =>
                    book.Title.ToLower().Contains(searchText) ||
                    book.Author.ToLower().Contains(searchText))
                .ToList();

            RefreshTable(foundBooks);
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            RefreshTable(books);
        }

        private void BtnShowAvailable_Click(object sender, EventArgs e)
        {
            List<Book> availableBooks = books
                .Where(book => book.Status == "доступна")
                .ToList();

            RefreshTable(availableBooks);
        }

        private void BtnShowIssued_Click(object sender, EventArgs e)
        {
            List<Book> issuedBooks = books
                .Where(book => book.Status == "видана")
                .ToList();

            RefreshTable(issuedBooks);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private Book GetSelectedBook()
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                return null;
            }

            return dgvBooks.SelectedRows[0].DataBoundItem as Book;
        }

        private void RefreshTable(List<Book> list)
        {
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = list;
        }

        private void ClearInputFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            txtGenre.Clear();
            txtReader.Clear();
            txtSearch.Clear();
            cmbStatus.SelectedIndex = 0;
        }

        private void SaveBooksToFile()
        {
            List<string> lines = new List<string>();

            foreach (Book book in books)
            {
                string line =
                    book.Title + "|" +
                    book.Author + "|" +
                    book.Year + "|" +
                    book.Genre + "|" +
                    book.Status + "|" +
                    book.Reader + "|" +
                    book.IssueDate;

                lines.Add(line);
            }

            File.WriteAllLines(booksFile, lines, Encoding.UTF8);
        }

        private void LoadBooksFromFile()
        {
            if (!File.Exists(booksFile))
            {
                return;
            }

            string[] lines = File.ReadAllLines(booksFile, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length >= 7)
                {
                    Book book = new Book();

                    book.Title = parts[0];
                    book.Author = parts[1];

                    int year;
                    if (int.TryParse(parts[2], out year))
                    {
                        book.Year = year;
                    }

                    book.Genre = parts[3];
                    book.Status = parts[4];
                    book.Reader = parts[5];
                    book.IssueDate = parts[6];

                    books.Add(book);
                }
            }
        }

        private void AddHistory(string text)
        {
            string line = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " — " + text;
            File.AppendAllText(historyFile, line + Environment.NewLine, Encoding.UTF8);
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public string Reader { get; set; }
        public string IssueDate { get; set; }
    }
}