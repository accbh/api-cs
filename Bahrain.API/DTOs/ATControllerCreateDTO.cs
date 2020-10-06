using System.ComponentModel.DataAnnotations;

namespace Bahrain.API.DTOs
{
    public class ATControllerCreateDTO
    {


        //ID is supplied by the database.
        // //[Key]
        // public int id { get; set; }

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

        [Required(ErrorMessage="Visiting status required.")]
        public bool Visitor { get; set; }

        [Required(ErrorMessage="Home vACC required.")]
        public string HomeVacc { get; set; }

        [Required(ErrorMessage="Approved positions required.")]
        public string ApprovedPositions { get; set; }



    }
}