namespace Retrofit.Net.Attributes.Methods
{
    [RestMethod(RestMethod.HEAD)]
    public class HeadAttribute : ValueAttribute
    {
        public HeadAttribute(string path)
        {
            this.Value = path;
        }
    }
}