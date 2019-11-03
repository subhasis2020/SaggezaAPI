using RailwayService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayService.Service.ConversionService
{
    public class ConvertToStationNameDTO
    {
        public StationNameDTO stationNamesDTO { get; set; }

        /// <summary>
        /// conversion from repository object to DTO
        /// </summary>
        /// <param name="StationNames"></param>
        public ConvertToStationNameDTO(List<string> StationNames, string SearchParameter)
        {
            stationNamesDTO = new StationNameDTO(StationNames, SearchParameter);
        }
    }
}
