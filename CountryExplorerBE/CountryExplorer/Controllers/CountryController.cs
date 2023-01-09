using CountryExplorer.ApplicationServices.Interfaces;
using CountryExplorer.Mapping;
using CountryExplorer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryExplorer.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryModel>>> Get()
        {
            return Ok((await _countryService.GetAll()).Select(x => x.ToModel()));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CountryDetailsModel>> Get(string name)
        {
            var country = (await _countryService.Get(name)).FirstOrDefault()?.ToDetailsModel();

            if (country is null)
            {
                return NotFound();
            }

            return Ok(country);
        }
    }
}