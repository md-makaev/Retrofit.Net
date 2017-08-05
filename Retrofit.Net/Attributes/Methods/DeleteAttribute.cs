
namespace Retrofit.Net.Attributes.Methods
{
    [RestMethod(RestMethod.DELETE)]
    public class DeleteAttribute : ValueAttribute
    {
        public DeleteAttribute(string path)
        {
            this.Value = path;
        }
    }
}