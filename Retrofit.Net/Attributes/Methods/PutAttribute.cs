namespace Retrofit.Net.Attributes.Methods
{
    [RestMethod(RestMethod.PUT)]
    public class PutAttribute : ValueAttribute
    {
        public PutAttribute(string path)
        {
            this.Value = path;
        }
    }
}