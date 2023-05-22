
namespace MedApp.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
    }
}
