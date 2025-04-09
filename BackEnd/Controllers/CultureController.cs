using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CultureController : ControllerBase
    {
        ICultureService _cultureService;

        public CultureController(ICultureService cultureService)
        {
            _cultureService = cultureService;
        }

        // GET: api/<CultureController>
        [HttpGet]
       
        public IEnumerable<CultureDTO> Get()
        {
            return _cultureService.GetCultures();
        }

        // GET api/<CultureController>/5
        [HttpGet("{id}")]
        public CultureDTO Get(string id)
        {
            return _cultureService.GetCultureById(id);
        }

        // POST api/<CultureController>
        [HttpPost]
        public void Post([FromBody] CultureDTO culture)
        {
            _cultureService.AddCulture(culture); 

        }

        // PUT api/<CultureController>/5
        [HttpPut]
        public void Put( [FromBody] CultureDTO culture)
        {
            try
            {
                _cultureService.UpdateCulture(culture);
            }
            catch (Exception e)
            {
            }
            

        }

        // DELETE api/<CultureController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _cultureService.DeleteCulture(id);
        }
    }
}
