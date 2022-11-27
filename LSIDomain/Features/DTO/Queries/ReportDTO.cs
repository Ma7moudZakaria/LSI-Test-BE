namespace LSIDomain.Features.DTO.Queries
{
    public class ReportDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfExport { get; set; }
        public string UserName { get; set; }
        public string PremiseName { get; set; }
    }
}
