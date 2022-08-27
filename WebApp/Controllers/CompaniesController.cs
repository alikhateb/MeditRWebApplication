namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var companies = await mediator.Send(new GetAllCompaniesQuery());
            if (companies == null)
            {
                throw new NullReferenceException();
            }
            var companiesDTOs = companies.Select(c => new GetCompanyDTO
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
            }).ToList();
            return Ok(companiesDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await mediator.Send(new GetCompanyQuery(id));

            if (company == null)
            {
                throw new NullReferenceException();
            }

            var companyDTO = new GetCompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
            };
            return Ok(companyDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Insert(InsertCompanyDTO insertCompanyDTO)
        {
            var insertedCompany = await mediator.Send(new InsertCompanyCommand(new Company
            {
                Id = 0,
                Name = insertCompanyDTO.Name,
                Address = insertCompanyDTO.Address,
            }));
            if (insertedCompany == null)
            {
                throw new NullReferenceException();
            }
            var companyDTO = new UpdateCompanyDTO
            {
                Id = insertedCompany.Id,
                Name = insertedCompany.Name,
                Address = insertedCompany.Address,
            };
            return Ok(companyDTO);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UpdateCompanyDTO updateCompanyDTO)
        {
            var updatedCompany = await mediator.Send(new UpdateCompanyCommand(new Company
            {
                Id = updateCompanyDTO.Id,
                Name = updateCompanyDTO.Name,
                Address = updateCompanyDTO.Address,
            }));
            if (updatedCompany == null)
            {
                throw new NullReferenceException();
            }
            var companyDTO = new UpdateCompanyDTO
            {
                Id = updatedCompany.Id,
                Name = updatedCompany.Name,
                Address = updatedCompany.Address,
            };
            return Ok(companyDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int numberOfDeletedRows = await mediator.Send(new DeleteCompanyCommand(id));
            if (numberOfDeletedRows == 0)
            {
                return NotFound();
            }
            return Ok(id);
        }
    }
}
