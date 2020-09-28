namespace Bahrain.API.DTOs
{
    public class StaffReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string StaffCallsign { get; set; }
        public string NetworkId { get; set; }
        public string Department { get; set; }
        // public int PermissionPower { get; set; }
        // public string StaffEmail { get; set; }
    }
}