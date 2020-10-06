namespace Bahrain.API.DTOs
{
    public class ATControllerReadDTO
    {

        //Ignore model validation - for up to date validations see the models in the "Models" file.

        //[Key]
        public int Id { get; set; }

        //[Required(ErrorMessage="Controller name is required.")]
        public string FullName { get; set; }

        //[Required(ErrorMessage="Rating is required.")]
        //[MaxLength(2, ErrorMessage="Rating can only be 2 characters. For example, S1 or C3.")]
        public string Rating { get; set; }

        //[Required(ErrorMessage="VATSIM ID is required.")]
        public string NetworkId { get; set; }

        //[Required(ErrorMessage="Sign off state is required.")]
        public bool HasSignOff { get; set; }

        //[Required(ErrorMessage="Solo endorsement state is required.")]
        public bool OnSolo { get; set; }

        //[Required]
        public bool Visitor { get; set; }

        //[Required(ErrorMessage="Approved positions required.")]
        public string ApprovedPositions { get; set; }



    }
}