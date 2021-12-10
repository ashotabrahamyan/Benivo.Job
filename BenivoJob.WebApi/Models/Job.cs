namespace BenivoJob.WebApi.Models
{
    public class GetAllJobsRequest
    {  
        public string SearchText { get; private set; }
        public long? LocationId { get; private set; }
        public int? EmploymentType { get; private set; } 
        public long? CategoryId { get; private set; }
        public short Offset  { get; set; }
        public short Limit { get; set; }
    }
}
 