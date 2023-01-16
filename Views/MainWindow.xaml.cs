using System.Windows;
using ReactiveUI;

using Anki.Data;
using Anki.Models;
using Anki.ViewModels;
using System.Collections.ObjectModel;

namespace Anki
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var ankiContext = new AnkiContext();

            var context = new MainWindowViewModel(ankiContext);

            this.DataContext = context;

            InitializeComponent();
        }
    }
}
