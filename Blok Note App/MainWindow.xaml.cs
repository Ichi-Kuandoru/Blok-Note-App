using System.Collections.ObjectModel;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.EntityFrameworkCore; 
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static Blok_Note_App.MainWindow;

namespace Blok_Note_App
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Note> Notes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        public class Note
        {
            public int Id { get; set; }
            public string Rec { get; set; }
            public string Cont { get; set; }
            public string ButtonColor { get; set; }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new AppDbContext())
            {
                Notes = new ObservableCollection<Note>(context.Notes.ToList());
            }
            Bas.ItemsSource = Notes; 
        }

        private void NoteButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Note selectedNote = clickedButton.DataContext as Note;
                if (selectedNote != null)
                {
                    EditNoteWindow editWindow = new EditNoteWindow(selectedNote);
                    if (editWindow.ShowDialog() == true)
                    {
                        Bas.Items.Refresh();
                    }
                }
            }
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=your_ip_address;Database=database_name;User ID=username;Password=password;Port=3306;",
                new MySqlServerVersion(new Version(8, 0, 21))); 
        }
    }
}