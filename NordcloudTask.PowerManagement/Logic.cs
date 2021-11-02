namespace NordcloudTask.PowerManagement
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using NordcloudTask.PowerManagement.Calculators;
    using NordcloudTask.PowerManagement.Models;
    using Newtonsoft.Json;
    using NLog;

    public class Logic
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly List<StationModel> stations;

        /// <summary>
        /// Initializes logic with paths to json files containing points and stations data
        /// </summary>
        /// <param name="stationsFile">Path to file with stations data</param>
        public Logic(string stationsFile)
        {
            Logger.Trace("Logic initialize...");
            stations = this.GetObjectListFromFile<StationModel>(stationsFile);
            Logger.Trace("Logic initialized.");
        }

        /// <summary>
        /// Gets best stations for given points
        /// </summary>
        /// <param name="point">Point data</param>
        /// <returns>Set of point station and power delivered from station to point</returns>
        public BestPointStationSetModel GetPointsBestStation(PointModel point)
        {
            try
            {
                Logger.Trace("Getting best station for point...");

                double bestPower = 0;
                var bestStation = new StationModel();
                foreach (var station in stations)
                {
                    var power = Calculator.CalculatePower(point, station);
                    if (power > bestPower)
                    {
                        bestPower = power;
                        bestStation = station;
                    }
                }

                Logger.Trace($"Best station for point {point.x},{point.y} is station {bestStation.x},{bestStation.y} with power {bestPower}");

                return new BestPointStationSetModel()
                {
                    point = point,
                    station = bestStation,
                    power = bestPower
                };
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error getting best powers stations for point.");
                throw;
            }
        }

        /// <summary>
        /// Gets point model list from json file with points data
        /// </summary>
        /// <param name="pointsFile">Path to file with points data</param>
        /// <returns>List of points</returns>
        public List<PointModel> GetPointsFromFile(string pointsFile)
        {
            return GetObjectListFromFile<PointModel>(pointsFile);
        }

        private List<T> GetObjectListFromFile<T>(string file)
        {
            try
            {
                Logger.Trace($"Getting list of {typeof(T)}...");
                List<T> list;
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    list = JsonConvert.DeserializeObject<List<T>>(json);
                }
                Logger.Trace("Returning list of {typeof(T)}.");
                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error reading file {file}.");
                throw;
            }
        }
    }
}
