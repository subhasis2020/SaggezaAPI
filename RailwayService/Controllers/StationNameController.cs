using RailwayService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RailwayService.Service;
using RailwayService.Helper;
using RailwayService.Service.Repository;

namespace RailwayService.Controllers
{
    /// <summary>
    /// This Controller is used for station name search
    /// </summary>
    [HandleException]
    public class StationNameController : ApiController
    {
        readonly IRailwayService _IRailWayService;
       
        /// <summary>
        /// Resolve Dependency in Constructor using Unity Container
        /// </summary>
        public StationNameController()
        {
            _IRailWayService = DependencyInjector.Resolve<IRailwayService>();
        }       
        
        /// <summary>
        /// This method is used to search Station Names as per user search criteria
        /// </summary>
        /// <param name="SearchCriteria"></param>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<StationNameDTO>))]       
        [Route("api/StationName/Get/{SearchCriteria}")]  
        [HttpGet]
        public async Task<IHttpActionResult> GetStationNames(string SearchCriteria = null)
        {            
            if (SearchCriteria == null)
            {
                return BadRequest("Please Enter Search Criteria.");
            }

            var _stationNames = await _IRailWayService.GetStationNames(SearchCriteria);
            if (_stationNames == null)
            {
                return NotFound();
            }

            return Ok(_stationNames);
        }
    }
}
