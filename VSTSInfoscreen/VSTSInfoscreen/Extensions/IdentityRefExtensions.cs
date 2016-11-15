namespace Microsoft.VisualStudio.Services.WebApi
{
    using RestSharp;
    using RestSharp.Authenticators;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    using VSTSInfoscreen;

    /// <summary>
    /// Contains all identity reference extensions.
    /// </summary>
    public static class IdentityRefExtensions
    {
        /// <summary>
        /// Downloads the profile picture and returns the url.
        /// </summary>
        /// <param name="user">The user to extend.</param>
        /// <returns>The path of the image.</returns>
        public static string GetProfilePath(this IdentityRef user)
        {
            var serverPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), $"{user.Id}.png");
            if (File.Exists(serverPath) && new FileInfo(serverPath).LastWriteTime > DateTime.Now - new TimeSpan(24, 0, 0))
            {
                return $"/Images/{user.Id}.png";
            }

            try
            {
                var apiUri = InfoscreenConfiguration.Instance.Uri.ToString();
                var client = new RestClient(apiUri)
                {
                    Authenticator = new HttpBasicAuthenticator(string.Empty, InfoscreenConfiguration.Instance.AccessToken)
                };
                var request = new RestRequest($"{user.ImageUrl.Substring(user.ImageUrl.IndexOf(apiUri) + apiUri.Length) }&size=2");
                var response = client.DownloadData(request);
                using (var memoryStream = new MemoryStream(response))
                using (var image = Image.FromStream(memoryStream))
                {
                    image.Save(serverPath, ImageFormat.Png);
                }
            }
            catch (Exception)
            {
                return $"{user.ImageUrl}&size=2";
            }

            return $"/Images/{user.Id}.png";
        }
    }
}