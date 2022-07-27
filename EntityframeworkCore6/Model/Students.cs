using System.ComponentModel.DataAnnotations;

namespace EntityframeworkCore6.Model
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string Standard { get; set; }

    }
}
