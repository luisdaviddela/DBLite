using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
namespace DBExample
{
    public class SelectViewModel : ReactiveObject
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
        public SelectViewModel()
        {
            _liteDBService = new PersonLiteDBService();
            var todos = _liteDBService.ReadAllItems();
            if (todos.Any())
            {
                Todos = new ReactiveList<PersonModel>(todos) { ChangeTrackingEnabled = true };
            }
            else { Todos = new ReactiveList<PersonModel>() { ChangeTrackingEnabled = true }; }
        }
        //private void SelectAll()
        //{
        //    foreach (var item in _todos)
        //    {
        //        Application.Current.MainPage.DisplayAlert("das", item.Nombre, "dsa");
        //    }
        //}
        //public Command Comm
        //{
        //    get
        //    {
        //        return new Command((() =>
        //        {
        //            SelectAll();
        //        }));

        //    }
        //}
    }
}
