using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RailwayService.Helper;
using RailwayService.Service;
using RailwayService.Service.Repository;

namespace RailwayService.Tests.Controllers
{
    [TestClass]
    public class RailwayServiceControllerTest
    {
        readonly IRailwayService _IRailWayService;
        

        /// <summary>
        ///  Resolve Dependency in Constructor using Unity Container
        /// </summary>       
        public RailwayServiceControllerTest()
        {
            DependencyInjector.Register<IRailwayService, Service.RailwayService>();
            DependencyInjector.Register<IStationRepository, StationRepository>();
            _IRailWayService = DependencyInjector.Resolve<IRailwayService>();            
        }
       
        [TestMethod]
        public void Object_Not_Null()
        {           
            // Act
            var result = _IRailWayService.GetStationNames("dart");

            // Assert
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void Station_Name_Count_Should_Be_Two_By_Search_Keyword_Dart()
        {
            // Act
            var result = _IRailWayService.GetStationNames("Dart");
            
            // Assert           
            Assert.AreEqual(2, result.Result.StationNames.Count());            
        }

        [TestMethod]
        public void Next_Character_Count_Should_Be_Two_By_Search_Keyword_DART()
        {
            // Act
            var result = _IRailWayService.GetStationNames("Dart");

            // Assert           
            Assert.AreEqual(2, result.Result.NextCharacters.Count());
        }

        [TestMethod]
        public void Station_Name_Count_Should_Be_Two_By_Search_Keyword_LIVERPOOL()
        {
            // Act
            var result = _IRailWayService.GetStationNames("LIVERPOOL");

            // Assert           
            Assert.AreEqual(2, result.Result.StationNames.Count());
        }

        [TestMethod]
        public void Next_Character_Should_Be_Blank_By_Search_Keyword_LIVERPOOL()
        {
            // Act
            var result = _IRailWayService.GetStationNames("LIVERPOOL");

            // Assert           
            Assert.AreEqual("", result.Result.NextCharacters.First());
        }

        [TestMethod]
        public void Station_Name_Count_Should_Be_Zero_By_Search_Keyword_KINGS_CROSS()
        {
            // Act
            var result = _IRailWayService.GetStationNames("KINGS CROSS");

            // Assert           
            Assert.AreEqual(0, result.Result.StationNames.Count());
        }

        [TestMethod]
        public void Next_Character_Count_Should_Be_Zero_By_Search_Keyword_KINGS_CROSS()
        {
            // Act
            var result = _IRailWayService.GetStationNames("KINGS CROSS");

            // Assert           
            Assert.AreEqual(0, result.Result.NextCharacters.Count());
        }


    }
}
