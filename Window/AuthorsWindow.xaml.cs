using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VisualProgBeadandoGyak.Data;
using VisualProgBeadandoGyak.Models;

namespace VisualProgBeadandoGyak
{
    /// <summary>
    /// Interaction logic for AuthorsWindow.xaml
    /// </summary>
    public partial class AuthorsWindow : System.Windows.Window
    {
        private AppDbContext _context = new AppDbContext();

        public AuthorsWindow()
        {
            InitializeComponent();
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            AuthorsGrid.ItemsSource = _context.Authors.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameInput.Text))
            {
                var author = new Author { Name = NameInput.Text };
                _context.Authors.Add(author);
                _context.SaveChanges();
                LoadAuthors();
                NameInput.Clear();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsGrid.SelectedItem is Author selected && !string.IsNullOrWhiteSpace(NameInput.Text))
            {
                selected.Name = NameInput.Text;
                _context.SaveChanges();
                LoadAuthors();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsGrid.SelectedItem is Author selected)
            {
                _context.Authors.Remove(selected);
                _context.SaveChanges();
                LoadAuthors();
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadAuthors();
        }
    }
}
