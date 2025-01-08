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

namespace Blok_Note_App
{
    public class Note
    {
        public string Rec { get; set; } // Название заметки
        public string Cont { get; set; } // Содержимое заметки
    }

    public partial class EditNoteWindow : Window
    {
        private Note _note;

        public EditNoteWindow(Note note)
        {
            InitializeComponent();
            _note = note;
            NameTextBox.Text = _note.Rec; // Предполагается, что Rec — это имя заметки
            ContentTextBox.Text = _note.Cont; // Cont — это содержание заметки
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохраняем изменения в заметку
            _note.Rec = NameTextBox.Text;
            _note.Cont = ContentTextBox.Text;

            // Возвращаем результат
            DialogResult = true; // Это будет использоваться, чтобы сигнализировать об успешном сохранении
            Close(); // Закрывает окно
        }

        private void ContentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
