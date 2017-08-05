using System;

namespace Retrofit.Net
{
    public interface IRequestBuilder
    {
        IRequest Build(RestMethodInfo rmi, object[] args);
    }
}