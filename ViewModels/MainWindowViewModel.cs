using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;

using Anki.Data;
using System.Collections.ObjectModel;
using Anki.Models;

namespace Anki.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private AnkiContext _ankiContext;

        private ObservableCollection<Deck> _decks;

        public ObservableCollection<Deck> Decks 
        { 
            get => _decks; 
            set => this.RaiseAndSetIfChanged(ref _decks, value); 
        }

        [Reactive] public string FirstName { get; set; }

        public ReactiveCommand<Unit, Unit> AddNewDeckCommand { get; }
        
        public MainWindowViewModel(AnkiContext ankiContext) 
        {
            _ankiContext = ankiContext;

            Decks = new ObservableCollection<Deck>(_ankiContext.Decks);

            AddNewDeckCommand = ReactiveCommand.Create(() => { FirstName = "Deck Added"; });
        }


    }
}
