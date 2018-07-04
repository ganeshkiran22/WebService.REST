using Newtonsoft.Json.Linq;

namespace WebService.RESTAPI
{
    /// <summary>
    /// Interface to handle REST requests
    /// </summary>
    public interface IRequestHandler
    {

        /// <summary>
        /// Method to get the Largest City and Capital
        /// </summary>
        /// <param name="url"></param>
        /// <returns>JToken</returns>
        JToken GetAllStateResponse(string url);

    }
}
