namespace Bitci.Portfolio.Application.Common.Models
{

    public class ResultResponse
    {
        internal ResultResponse(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static ResultResponse Success()
        {
            return new ResultResponse(true, Array.Empty<string>());
        }

        public static ResultResponse Error(IEnumerable<string> errors)
        {
            return new ResultResponse(false, errors);
        }
    }
}
