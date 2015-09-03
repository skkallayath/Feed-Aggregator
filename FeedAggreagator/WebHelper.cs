namespace Suyati.FeedAggreagator
{
    using RestSharp;
    using System.Net;

    /// <summary>
    /// The webhelper
    /// </summary>
    internal static class WebHelper
    {
        /// <summary>
        /// To download content
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string DownloadContent(string url, Method method = Method.GET)
        {
            // Using RestSharp
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(method);
            var response = client.Execute(request);

            // Checking for Exception
            if (response.ErrorException != null)
            {
                throw new WebException(response.ErrorMessage, response.ErrorException);
            }

            return response.Content;
        }
    }
}
