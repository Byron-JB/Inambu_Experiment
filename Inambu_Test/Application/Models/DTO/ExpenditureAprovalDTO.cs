namespace Application.Models.DTO
{
    public class ExpenditureAprovalDTO
    {
        public int requestId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public int userID { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public List<ExpenditureApprovalRecordsDTO>? ApprovalRecords { get; set; } = new List<ExpenditureApprovalRecordsDTO>();
    }

    public class ExpenditureApprovalRecordsDTO
    {
        public string CreatedBy { get; set; } = string.Empty;
        public int ApprovalUserId { get; set; }
        public string ApprovalUserName { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
    }
}
