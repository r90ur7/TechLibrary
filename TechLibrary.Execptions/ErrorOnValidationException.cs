using System.Net;

namespace TechLibrary.Execptions
{
    public class ErrorOnValidationException : TechLibraryExeptions
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> erromessages)
        {
            _errors = erromessages;
        }
        public override List<string> GetErrorMessages() => _errors;
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
