using System.Collections.Generic;
using RestSharp;

namespace Retrofit.Net.RestClient
{
    public static class RestMethodExtender
    {
        private static readonly Dictionary<RestMethod, Method> convert = new Dictionary<RestMethod, Method>
        {
            {RestMethod.DELETE, Method.DELETE},
            {RestMethod.GET, Method.GET},
            {RestMethod.HEAD, Method.HEAD},
            {RestMethod.OPTIONS, Method.OPTIONS},
            {RestMethod.PATCH, Method.PATCH},
            {RestMethod.POST, Method.POST},
            {RestMethod.PUT, Method.PUT},
        };

        public static Method ToRestClient(this RestMethod method)
        {
            return convert[method];
        }
    }
}