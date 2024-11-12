using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CldvFinalTest.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Product_Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }  // URL for blob storage image

        [StringLength(100)]
        public string? Location { get; set; }

        public DateTimeOffset? Timestamp { get; set; }  // Optional field for tracking updates
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
    //Digital TechJoint (2022). ASP.NET Identity - User Registration, Login and Log-out. [online] YouTube. Available at: https://www.youtube.com/watch?v=ghzvSROMo_M [Accessed 5 Nov. 2024].
    //Digital TechJoint (2022). ASP.NET MVC - How To Implement Role Based Authorization. YouTube. Available at: https://www.youtube.com/watch?v=qvsWwwq2ynE [Accessed 5 Nov. 2024].
    //Mrzygłód, K., 2022. Azure for Developers. 2nd ed. August: [Meeta Rajani]
}
