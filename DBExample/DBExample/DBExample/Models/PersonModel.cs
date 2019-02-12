using ReactiveUI;
namespace DBExample
{
    public class PersonModel: ReactiveObject
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
