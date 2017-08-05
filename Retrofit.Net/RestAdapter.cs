using Castle.DynamicProxy;
namespace Retrofit.Net
{
    public class RestAdapter
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();
        private readonly IRequestBuilder builder;

        public RestAdapter(IRequestBuilder builder)
        {
            this.builder = builder;
        }

        public string Server { get; set; }

        public T Create<T>() where T : class
        {
            return Generator.CreateInterfaceProxyWithoutTarget<T>(new RestInterceptor<T>(builder));
        }
    }
}