namespace PROShoping.Models
{
    public class ApiResponse
    {
        /// <summary>
        /// The data returned by the API
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// The errors returned by the API
        /// </summary>
        public object Errors { get; set; }
        /// <summary>
        /// The status code of the API response
        /// </summary>
        public string StatusCode { get; set; }
    }
}
