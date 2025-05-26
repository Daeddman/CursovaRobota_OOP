using System;
using System.Windows;
using System.Windows.Input;

namespace CursovaRobota.Views
{
    public partial class WindowInputDialog : Window
    {

        public string EventTitle => TitleBox.Text;

        public string EventDescription => DescriptionBox.Text;

        private WindowInputDialog(string prompt, string windowTitle)
        {
            InitializeComponent();
            TxtPrompt.Text = prompt;
            Title = windowTitle;
            TitleBox.Focus();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public static (string Title, string Description) Show(string prompt, string windowTitle)
        {
            var dialog = new WindowInputDialog(prompt, windowTitle);
            bool? result = dialog.ShowDialog();
            if (result == true)
                return (dialog.EventTitle, dialog.EventDescription);
            return (null, null);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
