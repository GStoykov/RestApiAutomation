using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using NUnit.Framework;
using RestSharp.Deserializers;

namespace LibraryManagerAutomation
{
    public class Request
    {
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;

        public Request()
        {
            _client = new RestClient();
            _client.BaseUrl = new Uri("http://localhost:9000/api");
            _client.AddHandler("application/json", new JsonDeserializer());
            //_client.AddHandler("text/json", new JsonDeserializer());
            _request = new RestRequest();
        }

        public RestRequest SetMethodType(string requestedMethodType)
        {
            Method currentMethodType;

            if (!Enum.TryParse(requestedMethodType, true, out currentMethodType))
                Assert.Fail("Method '{0}' was not recognized", requestedMethodType);

            _request.Method = currentMethodType;
            return _request;
        }


        public RestRequest AddEndpoint(string endpoint)
        {
            _request.Resource = _request.Resource + endpoint;
            return _request;
        }


        public RestRequest AddContent(object content)
        {
            _request.RequestFormat = DataFormat.Json;
            _request.AddBody(content);
            _request.AddParameter("application/json", content, ParameterType.RequestBody);

            return _request;
        }


        public IRestResponse ExecuteRequest()
        {
            _response = _client.Execute(_request);
            return _response;
        }


        public HttpStatusCode GetResponseCode()
        {
            return _response.StatusCode;
        }


        public string GetResponseMessage()
        {
            return _response.Content;
        }
    }
}
