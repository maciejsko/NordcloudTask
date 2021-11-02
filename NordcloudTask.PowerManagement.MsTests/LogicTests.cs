namespace NordcloudTask.PowerManagement.MsTests
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using NordcloudTask.PowerManagement;
    using NordcloudTask.PowerManagement.Models;

    [TestClass]
    public class LogicTests
    {
        private Logic logic;
        private List<PointModel> points;
        
        [TestMethod]
        [DeploymentItem("Resources/TestPoints.json", "Resources")]
        public void GetPointsBestStation_StationInReach_Test()
        {
            var expectedPower = 4;
            var point = new PointModel()
            {
                x = 8,
                y = 10
            };

            var set = this.logic.GetPointsBestStation(point);

            Assert.AreEqual(expectedPower, set.power);
        }

        [TestMethod]
        [DeploymentItem("Resources/TestPoints.json", "Resources")]
        public void GetPointsBestStation_StationOutOfReach_Test()
        {
            var expectedPower = 0;
            var point = new PointModel()
            {
                x = 100,
                y = 100
            };

            var set = this.logic.GetPointsBestStation(point);

            Assert.AreEqual(expectedPower, set.power);
        }

        [TestMethod]
        [DeploymentItem("Resources/TestPoints.json", "Resources")]
        public void GetPointsFromFile_Test()
        {
            var expectedPointNumber = 3;
            List<PointModel> expectedPoints = new List<PointModel>()
            {
                new PointModel()
                {
                    x = 0,
                    y = 0
                },
                new PointModel()
                {
                    x = 3,
                    y = 5
                },
                new PointModel()
                {
                    x = 8,
                    y = 10
                }
            };

            var points = this.logic.GetPointsFromFile("Resources/TestPoints.json");

            Assert.AreEqual(expectedPointNumber, points.Count);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expectedPoints[i].x, points[i].x);
                Assert.AreEqual(expectedPoints[i].y, points[i].y);
            }
        }

        [TestInitialize]
        [DeploymentItem("Resources/TestPoints.json", "Resources")]
        [DeploymentItem("Resources/TestStations.json", "Resources")]
        public void Init()
        {
            this.logic = new Logic("Resources/TestStations.json");
            using (StreamReader r = new StreamReader("Resources/TestPoints.json"))
            {
                string json = r.ReadToEnd();
                points = JsonConvert.DeserializeObject<List<PointModel>>(json);
            }
        }
    }
}
