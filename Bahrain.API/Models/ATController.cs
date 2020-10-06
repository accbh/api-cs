using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bahrain.API.Models 
{
    [Table("atcontrollers")]
    public class ATController 
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Controller name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage="Rating is required.")]
        [MaxLength(2, ErrorMessage="Rating can only be 2 characters. For example, S1 or C3.")]
        public string Rating { get; set; }

        [Required(ErrorMessage="VATSIM ID is required.")]
        public string NetworkId { get; set; }

        [Required(ErrorMessage="Sign off state is required.")]
        public bool HasSignOff { get; set; }

        [Required(ErrorMessage="Solo endorsement state is required.")]
        public bool OnSolo { get; set; }

        [Required(ErrorMessage="Approved positions required.")]
        //[RegularExpression(@"\d{1,2}[\,]{1}\d{1,2}", ErrorMessage="Positions must be separated by '&'.")]
        //TODO fix above regex to allow "twr&app&ctr" to pass.
        public string ApprovedPositions { get; set; }

        [Required(ErrorMessage="Home vACC required.")]
        public string HomeVacc { get; set; }

        [Required(ErrorMessage="Visiting status required.")]
        public bool Visitor { get; set; }

        [RegularExpression(@"/^\S{1,}@\S{2,}\.\S{2,}$", ErrorMessage="An invalid email address was entered.")]
        public string Email { get; set; }

        public string Comments { get; set; }


    }
}