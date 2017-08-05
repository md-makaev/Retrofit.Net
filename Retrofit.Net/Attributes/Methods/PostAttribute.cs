namespace Retrofit.Net.Attributes.Methods
{
    [RestMethod(RestMethod.POST)]
    public class PostAttribute : ValueAttribute
    {
        public PostAttribute(string path)
        {
            this.Value = path;
        }
    }
}