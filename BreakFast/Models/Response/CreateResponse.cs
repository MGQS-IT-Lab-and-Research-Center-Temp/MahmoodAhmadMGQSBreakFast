namespace BreakFast.Models.Response
{
    public class CreateResponse : BaseResponse
    {
        public static readonly CreateResponse NotPermitted = new CreateResponse(
            false,
           "",
            "You don't have sufficient permissions to perform this action.");



        public CreateResponse(bool status,
                                  string code,
                                  string message,
                                  Guid? id = (Guid?)null,
                                  string field = "",
                                  int count = 0) : base(status,
                                                           code,
                                                           message,
                                                           field,
                                                           count)
        {
            Id = id;
        }

        public Guid? Id { get; }
    }
}
