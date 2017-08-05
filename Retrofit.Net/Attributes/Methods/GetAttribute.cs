namespace Retrofit.Net.Attributes.Methods
{
    [RestMethod(RestMethod.GET)]
    public class GetAttribute : ValueAttribute
    {
        public GetAttribute(string path)
        {
            this.Value = path;
        }
    }
}