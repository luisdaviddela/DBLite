using ReactiveUI;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
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
      
        PersonLiteDBService _liteDBService;
        public DeleteViewModel()
        {
            _liteDBService = new PersonLiteDBService();
            cargarLista();
        }
        void cargarLista()
        {
            var todos = _liteDBService.ReadAllItems();

            if (todos.Any())
            {
                Todos = new ReactiveList<PersonModel>(todos) { ChangeTrackingEnabled = true };
            }
            else { Todos = new ReactiveList<PersonModel>() { ChangeTrackingEnabled = true }; }
        }
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(field, value)) { return false; }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void OnTapSelectedCategories()
        {
            try
            {
                var todo = new PersonModel() { Id = SelectedCategories.Id, Nombre = SelectedCategories.Nombre, Edad = SelectedCategories.Edad };
                _liteDBService.DeleteItemAsync(todo);
                await Application.Current.MainPage.DisplayAlert("LiteDB Message", "Eliminado correctamente", "Ok");
                
            }
            catch (System.Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("LiteDB Error",ex.Message,"Ok");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private PersonModel selectedCategories;
        public PersonModel SelectedCategories
        {
            get { return selectedCategories; }
            set
            {
                if (selectedCategories != value)
                {
                    SetProperty(ref selectedCategories, value);
                    OnTapSelectedCategories();
                }
            }
        }
    }
}
