namespace BreakFast.Models.Response
{
    public class UpdateResponse : BaseResponse
    {
        public static readonly UpdateResponse NotPermitted = new UpdateResponse(
            false,
           "",
            "You don't have sufficient permissions to perform this action.");



        public UpdateResponse(bool status,
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
