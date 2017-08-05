using System;
using System.Linq;
using System.Reflection;
using RestSharp;

namespace Retrofit.Net.RestClient
{
    public class RestClientRequestBuilder : IRequestBuilder
    {
        class Request : IRequest
        {
            private readonly MethodInfo mi;
            private readonly IRestRequest request;
            private readonly IRestClient restClient;

            public Request(IRestRequest request, MethodInfo mi, IRestClient restClient)
            {
                this.request = request;
                this.mi = mi;
                this.restClient = restClient;
            }

            public void Execute()
            {
                ReturnValue = mi.Invoke(restClient, new object[] { request });
            }

            public object ReturnValue { get; private set; }
        }

        private readonly IRestClient restClient;

        public RestClientRequestBuilder(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public IRequest Build(RestMethodInfo methodInfo, object[] arguments)
        {
            var request = CreateRequest(methodInfo, arguments);
            var generic = GetMethod(methodInfo);

            return new Request(request, generic, restClient);
        }

        private MethodInfo GetMethod(RestMethodInfo methodInfo)
        {
            var responseType = methodInfo.ResultType;
            var genericTypeArgument = responseType.GenericTypeArguments[0];
            // We have to find the method manually due to limitations of GetMethod()
            var methods = restClient.GetType().GetMethods();
            MethodInfo method = methods.Where(m => m.Name == "Execute").First(m => m.IsGenericMethod);
            MethodInfo generic = method.MakeGenericMethod(genericTypeArgument);
            return generic;
        }

        private IRestRequest CreateRequest(RestMethodInfo methodInfo, object[] arguments)
        {
            var request = new RestRequest(methodInfo.Path, methodInfo.Method.ToRestClient());
            request.RequestFormat = DataFormat.Json; // TODO: Allow XML requests?
            for (int i = 0; i < arguments.Count(); i++)
            {
                Object argument = arguments[i];
                var usage = methodInfo.ParameterUsage[i];

                switch (usage)
                {
                    case RestMethodInfo.ParamUsage.Query:
                        request.AddParameter(methodInfo.ParameterNames[i], argument);
                        break;
                    case RestMethodInfo.ParamUsage.Path:
                        request.AddUrlSegment(methodInfo.ParameterNames[i], argument.ToString());
                        break;
                    case RestMethodInfo.ParamUsage.Body:
                        request.AddBody(argument);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return request;
        }
    }
}