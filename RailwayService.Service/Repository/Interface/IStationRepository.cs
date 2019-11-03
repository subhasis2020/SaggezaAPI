using RailwayService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayService.Service.Repository
{
    public interface IStationRepository:IDisposable
    {
        /// <summary>
        /// Interface of station repository
        /// </summary>
        /// <param name="SearchParameter"></param>
        /// <returns></returns>
        Task<StationNameDTO> GetStationNames(string SearchParameter);
    }
}
