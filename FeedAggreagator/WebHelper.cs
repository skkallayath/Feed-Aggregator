namespace Suyati.FeedAggreagator
{
    using RestSharp;
    using System.Net;
    using System.Text;

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

            string content = response.Content;
            if (content == null)
            {
                return null;
            }
            var byteOrderMark = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            // Removing Byte Order Mark from Content
            if (content.StartsWith(byteOrderMark))
            {
                content = content.Replace(byteOrderMark, string.Empty);
            }
            return content;
        }
    }
}
