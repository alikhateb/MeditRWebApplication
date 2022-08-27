namespace Application.Handlers.Queries.CompanyHandlers
{
    public class GetCompanyHandler : IRequestHandler<GetCompanyQuery, Company>
    {
        private readonly string connectionStrings;
        public GetCompanyHandler(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<Company> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = new SqlConnection(connectionStrings);
            string query = "select * from companies where id = @id;";
            var company = Task.FromResult(connection.QuerySingle<Company>(sql: query, param: new { id = request.Id }));
            return company;
        }
    }
}
