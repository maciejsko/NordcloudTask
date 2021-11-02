namespace NordcloudTask.PowerManagement.Models
{
    using Newtonsoft.Json;

    public class BestPointStationSetModel
    {
        /// <summary>
        /// Point data
        /// </summary>
        public PointModel point;

        /// <summary>
        /// Station data
        /// </summary>
        public StationModel station;

        /// <summary>
        /// Power for point
        /// </summary>
        public double power;
    }
}
