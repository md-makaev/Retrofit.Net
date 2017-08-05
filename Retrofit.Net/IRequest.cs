namespace Retrofit.Net
{
    public interface IRequest
    {
        void Execute();
        object ReturnValue { get; }
    }
}