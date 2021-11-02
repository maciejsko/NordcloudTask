namespace NordcloudTask.PowerManagement.Calculators
{
    using System;
    using NordcloudTask.PowerManagement.Models;
    using NLog;

    public static class Calculator
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Calculate power reaching point from power station
        /// </summary>
        /// <param name="point">PointModel object with point coordinates</param>
        /// <param name="station">StationModel Object with statnion coordinates and it's reach</param>
        /// <returns>Power</returns>
        public static double CalculatePower(PointModel point, StationModel station)
        {
            try
            {
                Logger.Trace("Calculating power...");
                var distance = CalculateDistance(point, station);
                double result;
                if (distance > station.reach)
                {
                    result = 0;
                }
                else
                {
                    result = Math.Pow(station.reach - distance, 2);
                }
                Logger.Trace($"Power for station {station.x},{station.y} with reach {station.reach} and point {point.x},{point.y} = {result}");
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error calculating power for station {station.x},{station.y} with reach {station.reach} and point {point.x},{point.y}");
                throw;
            }
        }

        /// <summary>
        /// Calculates distance between point and power station
        /// </summary>
        /// <param name="point">PointModel object with point coordinates</param>
        /// <param name="station">StationModel Object with statnion coordinates and it's reach</param>
        /// <returns>distance</returns>
        public static double CalculateDistance(PointModel point, StationModel station)
        {
            try
            {
                Logger.Trace("Calculating distance...");
                var result = Math.Sqrt(Math.Pow(station.x - point.x, 2) + Math.Pow(station.y - point.y, 2));
                Logger.Trace($"Distance between station {station.x},{station.y} with reach {station.reach} and point {point.x},{point.y} = {result}");
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error calculating distance between station {station.x},{station.y} with reach {station.reach} and point {point.x},{point.y}");
                throw;
            }
        }
    }
}
