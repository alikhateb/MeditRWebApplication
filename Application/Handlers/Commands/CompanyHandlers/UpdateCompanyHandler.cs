namespace Application.Handlers.Commands.CompanyHandlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Company>
    {
        private readonly string connectionStrings;
        public UpdateCompanyHandler(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = new SqlConnection(connectionStrings);
            string query = @"
                            begin transaction
                            begin try
                            update companies
                            set name = @name, address = @address
                            where id = @id;
                            commit transaction
                            select * from companies
                            where id = @id;
                            end try
                            begin catch
                            rollback transaction
                            end catch";
            var updatedCompany = Task.FromResult(connection.QuerySingle<Company>(sql: query, param: request.Company));
            return updatedCompany;
        }
    }
}
