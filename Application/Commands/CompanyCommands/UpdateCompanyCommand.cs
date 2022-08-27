namespace Application.Commands.CompanyCommands
{
    public class UpdateCompanyCommand : IRequest<Company>
    {
        public UpdateCompanyCommand(Company company)
        {
            Company = company;
        }

        public Company Company { get; }
    }
}
