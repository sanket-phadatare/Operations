using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst1.Models
{
    public class Student
    {
        [Key]


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [StringLength(10)]

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Gender { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]

        [Required]
        public string City { get; set; }

        [Range(0, 150)]
        [Required]
        public int? Age { get; set; }


        [Required]
        //[Phone]
        public string MobileNumber { get; set; }



    }
}
