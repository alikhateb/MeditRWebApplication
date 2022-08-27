namespace Application.Handlers.Commands.CompanyHandlers
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, int>
    {
        private readonly string connectionStrings;
        public DeleteCompanyHandler(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<int> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = new SqlConnection(connectionStrings);
            string query = @"
                            begin transaction
                            begin try
                            delete from companies
                            where id = @id;
                            commit transaction
                            end try
                            begin catch
                            rollback transaction
                            end catch";
            var numberOfDeletedRows = Task.FromResult(connection.Execute(sql: query, param: new { id = request.Id }));
            return numberOfDeletedRows;
        }
    }
}
