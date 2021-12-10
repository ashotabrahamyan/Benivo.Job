namespace BenivoJob.Application.DTOs
{
    public class GetAllJobsRequest
    {
        public string SearchText { get;  set; }
        public long? LocationId { get;  set; }
        public int? EmploymentType { get;  set; }
        public long? CategoryId { get;  set; }
        public short Offset { get; set; }
        public short Limit { get; set; }
    }
}
