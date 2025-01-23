using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace carpark_info_assignment
{
    [ApiController]
    [Route("api/carparks")]
    //[Route("[controller]")]
    public class CarparkInfoController : ControllerBase
    {
        private readonly CarparkInfoService carparkInfoService;
        public CarparkInfoController(CarparkInfoService _carparkInfoService)
        {
            carparkInfoService = _carparkInfoService;
        }
        
        
        [HttpGet("filter")]
        public ActionResult<IEnumerable<CarparkInfoModel>> GetFilteredCarparkList(
                                [FromQuery]CarparkInfoFilters filter)
        {
            List<CarparkInfoModel> info = carparkInfoService.GetFilteredCarparkList(filter);
            return info.ToArray();
        }
        
    }
}