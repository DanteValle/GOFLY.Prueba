namespace GOFLY.Prueba.Api.Model.Entities
{
    public class Activity
    {
        public int? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ActivityName { get; set; }
        public int? IdUser { get; set; }
        public User? User { get; set; }
    }
}
