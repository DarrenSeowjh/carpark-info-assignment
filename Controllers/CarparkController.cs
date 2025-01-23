using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace carpark_info_assignment
{
    [ApiController]
    [Route("api/carparks")]
    //[Route("[controller]")]
    public class CarparkController : ControllerBase
    {
        private readonly CarparkActionService carparkInfoService;
        public CarparkController(CarparkActionService _carparkInfoService)
        {
            carparkInfoService = _carparkInfoService;
        }
        
        
        [HttpGet("filter")]
        public ActionResult<IEnumerable<CarparkModel>> GetFilteredCarparkList(
                                [FromQuery]CarparkFilters filter)
        {
            List<CarparkModel> info = carparkInfoService.GetFilteredCarparkList(filter);
            return info.ToArray();
        }
        
    }
}