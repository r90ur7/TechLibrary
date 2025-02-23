using System.Net;

namespace TechLibrary.Execptions
{
    public abstract class TechLibraryExeptions : SystemException
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
