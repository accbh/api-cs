using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bahrain.API.Models 
{
    [Table("StaffMember")]
    public class StaffMember
    {
        
        // public int Id { get; set; }
        // public string FullName { get; set; }
        // public string StaffCallsign { get; set; }
        // public string NetworkId { get; set; }
        // //public int PermissionPower { get; set; }
        // public string Department { get; set; }
        // public string Email {gs}

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Staff name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Staff callsign is required.")]
        public string StaffCallsign { get; set; }
        
        [Required(ErrorMessage = "Network ID is required.")]
        public string NetworkId { get; set; }
        
        [Required(ErrorMessage = "Permissions Power is required.")]
        public int PermissionPower { get; set; }
        
        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }
        
        [Required(ErrorMessage = "Staff email is required.")]
        public string StaffEmail { get; set; }

    }
}