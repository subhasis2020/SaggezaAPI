using RailwayService.DTO;
using RailwayService.Service.Repository;
using System.Threading.Tasks;


namespace RailwayService.Service
{
    public class RailwayService : IRailwayService
    {
        readonly IStationRepository _IStationRepository;
        public RailwayService(IStationRepository IStationRepository)
        {            
            _IStationRepository = IStationRepository;
        }

        /// <summary>
        /// This method is used to search Station Names as per user search criteria
        /// </summary>
        /// <param name="SearchParameter"></param>
        /// <returns></returns>
        public Task<StationNameDTO> GetStationNames(string SearchParameter)
        {
            return _IStationRepository.GetStationNames(SearchParameter);
        }
    }
}
