using CitiesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        CitiesContext context;

        public CitiesController(CitiesContext context)
        {
            this.context=context;
        }

        [HttpGet("parse")]
        public ActionResult<City> Post()
        {
            string URL = "https://raw.githubusercontent.com/pensnarik/russian-cities/master/russian-cities.json";
            WebRequest request = WebRequest.Create(URL);
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = @reader.ReadToEnd();
                
                List<City> city = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(responseFromServer);
                context.AddRange(city);
                context.SaveChanges();
            }

            // Close the response.
            response.Close();
            return Ok();
        }
        [HttpGet()]
        public List<City> GetAll()
        {
            return context.Cities.Include(x => x.Coords).ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            City user = await context.Cities.Include(x => x.Coords).FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }
    }
}
