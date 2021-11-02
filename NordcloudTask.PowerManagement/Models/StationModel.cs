namespace NordcloudTask.PowerManagement.Models
{
    using Newtonsoft.Json;

    public class StationModel
    {
        /// <summary>
        /// Power station's x coordinate
        /// </summary>
        [JsonProperty("x")]
        public double x;

        /// <summary>
        /// Power station's y coordinate
        /// </summary>
        [JsonProperty("y")]
        public double y;

        /// <summary>
        /// Power station's reach
        /// </summary>
        [JsonProperty("reach")]
        public double reach;
    }
}
