using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public DateTime CommentDate { get; set; }

        public string? CommentText { get; set; }

        public bool CommentStatus { get; set; }

        public int DestinationID { get; set; }

        public Destination? Destination { get; set; }

        public int AppUserID { get; set; }

        public AppUser? AppUser { get; set; }


    }
}
