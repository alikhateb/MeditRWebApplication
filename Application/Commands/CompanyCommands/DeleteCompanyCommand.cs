namespace Application.Commands.CompanyCommands
{
    public class DeleteCompanyCommand : IRequest<int>
    {
        public DeleteCompanyCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
