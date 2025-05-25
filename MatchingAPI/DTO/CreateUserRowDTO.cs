using System.ComponentModel.Design;

namespace MatchingAPI.DTO
{
    public class CreateUser1RowDTO
    {
        public long UserId { get; set; }
        public string Section { get; set; }
        public string HobbiesName { get; set; }
        public bool Active { get; set; }
        public DateTime LastActionDate { get; set; }



    }
}
