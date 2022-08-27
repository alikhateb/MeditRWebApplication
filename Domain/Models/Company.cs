namespace Domain.Models
{
    public class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Employee> Employees { get; private set; }
    }
}
