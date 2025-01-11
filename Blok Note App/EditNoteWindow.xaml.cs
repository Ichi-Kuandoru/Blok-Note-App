using System;
using System.Collections.Generic;
using System.Globalization;
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
using Blok_Note_App;

using System.Windows;
using System.Windows.Controls;
using static Blok_Note_App.MainWindow;

namespace Blok_Note_App
{
    public partial class EditNoteWindow : Window
    {
        private Note _note;

        public EditNoteWindow(Note note)
        {
            InitializeComponent();
            _note = note;

            
            RecTextBox.Text = _note.Rec;
            ContTextBox.Text = _note.Cont;
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                
                _note.ButtonColor = clickedButton.Background.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            _note.Rec = RecTextBox.Text;
            _note.Cont = ContTextBox.Text;

            
            DialogResult = true;
            Close();
        }
    }
}

