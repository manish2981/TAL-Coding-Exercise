using System;
using System.Threading.Tasks;
using DevTestAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DevTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        IOccupationRepository occupationRepository;
        public OccupationController(IOccupationRepository _occupationRepository)
        {
            occupationRepository = _occupationRepository;
        }

        [HttpGet]
        [Route("GetOccupations")]
        public async Task<IActionResult> GetOccupations()
        {
            try
            {
                var posts = await occupationRepository.GetOccupations();
                if (posts == null)
                {
                    return NotFound();
                }

                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}