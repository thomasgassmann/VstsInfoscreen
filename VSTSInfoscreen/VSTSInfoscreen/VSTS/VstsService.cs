namespace VSTSInfoscreen.VSTS
{
    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.TeamFoundation.SourceControl.WebApi;
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Authenticators;
    using System;
    
    /// <summary>
    /// Defines the base class for all Vsts services.
    /// </summary>
    public class VstsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VstsService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public VstsService(InfoscreenConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public InfoscreenConfiguration Configuration { get; }

        /// <summary>
        /// Gets JSON from a web service.
        /// </summary>
        /// <param name="mainUri">The main url for the REST API.</param>
        /// <param name="relativeUri">The relative uri.</param>
        /// <returns>Returns the JSON string.</returns>
        protected string GetJsonContent(string mainUri, string relativeUri)
        {
            var restClient = new RestClient(new Uri(mainUri))
            {
                Authenticator = new HttpBasicAuthenticator(string.Empty, this.Configuration.AccessToken)
            };
            var request = new RestRequest(relativeUri, Method.GET);
            var response = restClient.Execute(request);
            return response.Content;
        }

        /// <summary>
        /// Executes a REST request and deserializes the JSON to the given object.
        /// </summary>
        /// <typeparam name="TModel">The model.</typeparam>
        /// <param name="uri">The uri to make the request to.</param>
        /// <returns></returns>
        protected TModel ExecuteRestRequest<TModel>(string uri)
        {
            const string api = "/_apis/";
            var restClient = uri.IndexOf(api) != -1 ?
                new RestClient(uri.Substring(0, uri.IndexOf(api) + api.Length)) : 
                new RestClient($"{this.Configuration.BaseUri.ToString().TrimEnd('/')}/{this.Configuration.TeamProject}/_apis");
            restClient.Authenticator = new HttpBasicAuthenticator(string.Empty, this.Configuration.AccessToken);
            var request = new RestRequest(uri.IndexOf(api) != -1 ? uri.Substring(uri.IndexOf(api) + api.Length) : uri, Method.GET);
            var result = restClient.Execute(request);
            return JsonConvert.DeserializeObject<TModel>(result.Content);
        }

        /// <summary>
        /// Gets the JSON from a web service.
        /// </summary>
        /// <param name="relativeUri">The relative uri.</param>
        /// <returns>Returns the JSON string.</returns>
        protected string GetJson(string relativeUri) =>
            this.GetJsonContent(
                $"{this.Configuration.BaseUri.ToString().TrimEnd('/')}/{this.Configuration.TeamProject}/_apis",
                relativeUri);

        /// <summary>
        /// Gets the bulld client.
        /// </summary>
        /// <returns>The build client.</returns>
        protected BuildHttpClient GetBuildClient() =>
            new BuildHttpClient(this.Configuration.BaseUri, this.Configuration.Credential);

        /// <summary>
        /// Gets the git client.
        /// </summary>
        /// <returns>The git client.</returns>
        protected GitHttpClient GetGitClient() =>
            new GitHttpClient(this.Configuration.BaseUri, this.Configuration.Credential);
    }
}