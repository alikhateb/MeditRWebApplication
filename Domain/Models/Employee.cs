namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
