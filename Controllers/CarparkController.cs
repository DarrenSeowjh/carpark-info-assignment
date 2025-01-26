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
        public ActionResult<IEnumerable<CarparkInfo>> GetFilteredCarparkList(
                                [FromQuery]CarparkFilters filter)
        {
            List<CarparkInfo> info = carparkInfoService.GetFilteredCarparkList(filter);
            return info.ToArray();
        }
        
    }
}