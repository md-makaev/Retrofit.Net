using System;

namespace Retrofit.Net.Attributes.Methods
{
    public class RestMethodAttribute : Attribute
    {
        public RestMethod Method { get; private set; }

        public RestMethodAttribute(RestMethod method)
        {
            this.Method = method;
        }
    }
}