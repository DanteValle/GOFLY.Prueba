namespace GOFLY.Prueba.Api.Model.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public string CountryOfResidence { get; set; }
        public bool PermissionInformation { get; set; }
        public string Name { get; set; }
    }
}
