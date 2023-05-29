using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>();
        }

        [HttpPost]
        public bool Add()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        [HttpPut]
        public bool Update()
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        [HttpDelete]
        public bool Delete()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
