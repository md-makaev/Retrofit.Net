using Castle.DynamicProxy;

namespace Retrofit.Net
{
    class RestInterceptor<T> : IInterceptor
    {
        private readonly InterfaceMethods imethods;
        private readonly IRequestBuilder builder;

        public RestInterceptor(IRequestBuilder builder)
        {
            this.builder = builder;
            imethods = InterfaceMethodsFactory.Create<T>();
        }

        public void Intercept(IInvocation invocation)
        {
            // Build Request
            var methodInfo = imethods.Get(invocation.Method);
            var request = builder.Build(methodInfo, invocation.Arguments);
            // Execute request
            request.Execute();
            invocation.ReturnValue = request.ReturnValue;
        }
    }
}