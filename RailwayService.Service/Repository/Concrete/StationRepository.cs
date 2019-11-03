using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwayService.DTO;
using RailwayService.Service.ConversionService;
using System.Runtime.Caching;

namespace RailwayService.Service.Repository
{
    public class StationRepository : IStationRepository
    {
        private static List<string> StationNames;        
        /// <summary>
        /// Constructor to initialize the master Data
        /// </summary>
        public StationRepository()
        {
            if (StationNames == null)
                StationNames = GetStationMasterData();
        }

        /// <summary>
        /// Creating Master Data
        /// </summary>
        /// <returns></returns>
        private List<string> GetStationMasterData()
        {
            return new List<string>(new string[]
            {
                "DARTFORD",
                "DARTMOUTH",
                "TOWER HILL",
                "DERBY",
                "LIVERPOOL",
                "LIVERPOOL LIME STREET",
                "PADDINGTON",
                "EUSTON",
                "LONDON BRIDGE",
                "VICTORIA"
            });
        }
        /// <summary>
        /// This method is used to dispose object. 
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Repository of stations
        /// </summary>
        /// <param name="SearchParameter"></param>
        /// <returns></returns>
        public async Task<StationNameDTO> GetStationNames(string SearchParameter)
        {
            List<string> filterData;           
            try
            {
                ObjectCache cacheData = MemoryCache.Default;
                ObjectCache cacheSearchParameter = MemoryCache.Default;
                var stationsBasedOnFirstSearch = cacheData.Get("StationsBasedOnFirstSearch") as List<string>;
                var SearchParameterCached = cacheData.Get("SearchParameter") as string;
               
                // check cache value exists and search parameter is matching or not
                if (stationsBasedOnFirstSearch != null && SearchParameter.Contains(SearchParameterCached.ToUpper()))
                {
                    filterData = stationsBasedOnFirstSearch.Where(x => x.StartsWith(SearchParameter.ToUpper())).ToList();
                }
                else
                {
                    filterData = StationNames.Where(x => x.StartsWith(SearchParameter.ToUpper())).ToList();
                    CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2) };
                    cacheData.Add("StationsBasedOnFirstSearch", filterData, policy);
                    cacheData.Add("SearchParameter", SearchParameter, policy);
                }
            }
            catch (Exception ex)
            {               
                throw ex;
            }
            
            return new ConvertToStationNameDTO(filterData, SearchParameter).stationNamesDTO;
        }
    }
}
