namespace Application.Handlers.Queries.CompanyHandlers
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<Company>>
    {
        private readonly string connectionStrings;
        public GetAllCompaniesHandler(IConfiguration configuration)
        {
            connectionStrings = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = new SqlConnection(connectionStrings);
            string query = "select * from companies;";
            var companies = Task.FromResult(connection.Query<Company>(sql: query));
            //var companies = Task.FromResult(connection.Query<Company>(sql: query).ToList());
            return companies;
        }
    }
}
