using ReactiveUI;
using System;
namespace DBExample
{
    public class InsertViewModel: ReactiveObject
    {
        PersonLiteDBService _liteDBService;
        public ReactiveCommand AddCommand { get; private set; }
        
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { this.RaiseAndSetIfChanged(ref _nombre, value); }
        }

        private int _edad;
        public int Edad
        {
            get { return _edad; }
            set { this.RaiseAndSetIfChanged(ref _edad, value); }
        }

        public InsertViewModel()
        {
            _liteDBService = new PersonLiteDBService();
            AddCommand = ReactiveCommand.Create(() =>
            {
                var todo = new PersonModel() { Nombre = Nombre, Edad = Edad };

                _liteDBService.CreateItem(todo);

            }, this.WhenAnyValue(x => x.Nombre,
                title =>
                !String.IsNullOrEmpty(title)));
        }
    }
}
