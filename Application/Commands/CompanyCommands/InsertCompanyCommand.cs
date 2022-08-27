namespace Application.Commands.CompanyCommands
{
    public class InsertCompanyCommand : IRequest<Company>
    {
        public InsertCompanyCommand(Company company)
        {
            Company = company;
        }
        public Company Company { get; }
    }
}
