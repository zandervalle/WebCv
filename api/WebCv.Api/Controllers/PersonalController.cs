using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;
using WebCv.Api.Data.Services.Interfaces;

namespace WebCv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalInformationDataService _personalInformationDataService;

        public PersonalController(IPersonalInformationDataService personalInformationDataService)
        {
            _personalInformationDataService = personalInformationDataService;
        }

        [HttpGet]
        public async Task<ActionResult<PersonalInformation>> Get()
        {
            var information = await _personalInformationDataService.GetAsync();
            return Ok(information.FirstOrDefault());
        }
    }
}
