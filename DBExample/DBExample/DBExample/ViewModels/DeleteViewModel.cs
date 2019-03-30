using ReactiveUI;
using System.ComponentModel;
using System.Linq;
namespace DBExample
{
    internal class DeleteViewModel:ReactiveObject, INotifyPropertyChanged
    {
        ReactiveList<PersonModel> _todos;
        public ReactiveList<PersonModel> Todos
        {
            get => _todos;
            set => this.RaiseAndSetIfChanged(ref _todos, value);
        }
        private PersonModel _selectedTodo;
        public PersonModel SelectedTodo
        {
            get => _selectedTodo;
            set => this.RaiseAndSetIfChanged(ref _selectedTodo, value);
        }

        PersonLiteDBService _liteDBService;
        public DeleteViewModel()
        {
            _liteDBService = new PersonLiteDBService();
            var todos = _liteDBService.ReadAllItems();
            //var sg = todos.Count();
            //Application.Current.MainPage.DisplayAlert("dsa", sg.ToString(), "da");
            if (todos.Any())
            {
                Todos = new ReactiveList<PersonModel>(todos) { ChangeTrackingEnabled = true };
            }
            else { Todos = new ReactiveList<PersonModel>() { ChangeTrackingEnabled = true }; }
        }
        PersonModel _yourSelectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public PersonModel YourSelectedItem
        {
            get
            {
                return _yourSelectedItem;
            }

            set
            {
                _yourSelectedItem = value;
                //OnPropertyChanged("YourSelectedItem");

            }
        }

    }
}
