namespace Application.Queries.CompanyQueries
{
    public class GetCompanyQuery : IRequest<Company>
    {
        public GetCompanyQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
