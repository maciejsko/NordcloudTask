namespace NordcloudTask.PowerManagement.Models
{
    using Newtonsoft.Json;

    public class PointModel
    {
        /// <summary>
        /// Point's x coordinate
        /// </summary>
        [JsonProperty("x")]
        public double x;

        /// <summary>
        /// Point's y coordinate
        /// </summary>
        [JsonProperty("y")]
        public double y;
    }
}
