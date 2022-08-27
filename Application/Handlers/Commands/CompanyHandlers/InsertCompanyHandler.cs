namespace Application.Handlers.Commands.CompanyHandlers
{
    public class InsertCompanyHandler : IRequestHandler<InsertCompanyCommand, Company>
    {
        private readonly string connectionStrings;
        public InsertCompanyHandler(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<Company> Handle(InsertCompanyCommand request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = new SqlConnection(connectionStrings);
            string query = @"
                            begin transaction
                            begin try
                            insert into companies (name, address)
                            values (@name, @address);
                            commit transaction
                            select * from companies 
                            where id = (select cast(scope_identity() as int));
                            end try
                            begin catch
                            rollback transaction
                            end catch";
            var insertedCompany = Task.FromResult(connection.QuerySingle<Company>(sql: query, param: request.Company));
            return insertedCompany;
        }
    }
}
