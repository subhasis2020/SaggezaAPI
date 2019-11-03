using RailwayService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayService.Service
{
    public interface IRailwayService
    {
        /// <summary>
        /// This method is used to search Station Names as per user search criteria
        /// </summary>
        /// <param name="SearchParameter"></param>
        /// <returns></returns>
        Task<StationNameDTO> GetStationNames(string SearchParameter);
    }
}
