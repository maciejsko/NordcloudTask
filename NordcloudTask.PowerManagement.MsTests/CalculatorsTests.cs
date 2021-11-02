namespace NordcloudTask.PowerManagement.MsTests
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using NordcloudTask.PowerManagement.Calculators;
    using NordcloudTask.PowerManagement.Models;

    [TestClass]
    public class CalculatorsTests
    {
        private List<StationModel> stations;
        private List<PointModel> points;

        [TestMethod]
        public void CalculateDistance_Test()
        {
            List<double> expectedValues = new List<double>()
            {
                9.4339811320566032,
                0,
                5,
                5.8309518948453007,
                5,
                12.806248474865697
            };
            List<double> distances = new List<double>();
            foreach (var point in points)
            {
                foreach (var station in stations)
                {
                    distances.Add(Calculator.CalculateDistance(point, station));
                }
            }

            Assert.AreEqual(6, distances.Count);
            for (int i = 0; i < distances.Count; i++)
            {
                Assert.AreEqual(expectedValues[i], distances[i]);
            }
        }

        [TestMethod]
        public void CalculatePower_Test()
        {
            List<double> expectedValues = new List<double>()
            {
                0,
                100,
                4,
                17.380962103093989,
                4,
                0
            };
            List<double> powers = new List<double>();
            foreach (var point in points)
            {
                foreach (var station in stations)
                {
                    powers.Add(Calculator.CalculatePower(point, station));
                }
            }

            Assert.AreEqual(6, powers.Count);
            for (int i = 0; i < powers.Count; i++)
            {
                Assert.AreEqual(expectedValues[i], powers[i]);
            }
        }

		[TestInitialize]
		[DeploymentItem("Resources/TestPoints.json", "Resources")]
        [DeploymentItem("Resources/TestStations.json", "Resources")]
        public void Init()
		{
            using (StreamReader r = new StreamReader("Resources/TestPoints.json"))
            {
                string json = r.ReadToEnd();
                points = JsonConvert.DeserializeObject<List<PointModel>>(json);
            }
            using (StreamReader r = new StreamReader("Resources/TestStations.json"))
            {
                string json = r.ReadToEnd();
                stations = JsonConvert.DeserializeObject<List<StationModel>>(json);
            }
        }
	}
}
