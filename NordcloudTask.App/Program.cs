namespace NordcloudTask.App
{
    using System;
    using NLog;
    using NordcloudTask.PowerManagement;

    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Logger.Debug("Application start.");
            try
            {
                var logic = new Logic("Resources/Stations.json");
                var points = logic.GetPointsFromFile("Resources/Points.json");

                foreach (var point in points)
                {
                    var set = logic.GetPointsBestStation(point);

                    if (set.power > 0)
                    {
                        Console.WriteLine($"Best link station for point {set.point.x},{set.point.y} is {set.station.x},{set.station.y} with power {set.power}");
                    }
                    else
                    {
                        Console.WriteLine($"No link station within reach for point {set.point.x},{set.point.y}");
                    }
                }

                Logger.Debug("Application finished.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error runing the application.");
            }
        }
    }
}
