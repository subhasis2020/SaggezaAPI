using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RailwayService.DTO
{
    public class StationNameDTO
    {
        /// <summary>
        /// The List of stations Name 
        /// </summary>
        [DataMember]
        public HashSet<string> StationNames { get; set; }
        /// <summary>
        /// The List of Next Characters 
        /// </summary>
        [DataMember]
        public HashSet<string> NextCharacters { get; set; }

        /// <summary>
        /// Constructor to initialize value
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="nextChracter"></param>
        public StationNameDTO(List<string> stationNames, string SearchParameter)
        {
            StationNames = new HashSet<string>();
            NextCharacters = new HashSet<string>();

            foreach (string station in stationNames)
            {
                StationNames.Add(station);
                NextCharacters.Add
                (
                    station.Length != SearchParameter.Length ?
                    station.Substring(SearchParameter.Length, 1).Trim()
                    : string.Empty
                );
            }
        }

    }
}
