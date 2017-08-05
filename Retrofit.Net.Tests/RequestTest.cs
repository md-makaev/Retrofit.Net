namespace Retrofit.Net.Tests
{
    public class RequestTest : IRequest
    {
        public RequestTest(object result)
        {
            ReturnValue = result;
        }

        public void Execute()
        {
        }

        public object ReturnValue { get; private set; }
    }
}