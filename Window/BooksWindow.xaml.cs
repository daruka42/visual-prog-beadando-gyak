using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using VisualProgBeadandoGyak.Data;
using VisualProgBeadandoGyak.Models;

namespace VisualProgBeadandoGyak.Windows
{
    public partial class BooksWindow : System.Windows.Window
    {
        private readonly AppDbContext _context = new AppDbContext();

        public BooksWindow()
        {
            InitializeComponent();
            LoadAuthors();
            LoadBooks();
        }

        private void LoadAuthors()
        {
            AuthorSelector.ItemsSource = _context.Authors.ToList();
        }

        private void LoadBooks()
        {
            BooksGrid.ItemsSource = _context.Books
                                         .Include(b => b.Author)
                                         .ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(TitleInput.Text) && TitleInput.Text != "Book Title")
                && AuthorSelector.SelectedItem is Author auth)
            {
                var book = new Book
                {
                    Title = TitleInput.Text.Trim(),
                    AuthorId = auth.AuthorId
                };
                _context.Books.Add(book);
                _context.SaveChanges();
                LoadBooks();
                TitleInput.Clear();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book book &&
                !string.IsNullOrWhiteSpace(TitleInput.Text) &&
                AuthorSelector.SelectedItem is Author author)
            {
                book.Title = TitleInput.Text.Trim();
                book.AuthorId = author.AuthorId;
                _context.SaveChanges();
                LoadBooks();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book book)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                LoadBooks();
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }
    }
}