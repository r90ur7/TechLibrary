using System.Net;

namespace TechLibrary.Exception
{
    public abstract class TechLibraryExeptions : SystemException
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
