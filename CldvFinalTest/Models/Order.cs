using System;
using System.ComponentModel.DataAnnotations;

namespace CldvFinalTest.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string? User_Name { get; set; }  

        [Required(ErrorMessage = "Please select a product.")]
        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Please select the date.")]
        public DateTime Order_Date { get; set; }

        [Required(ErrorMessage = "Please enter the location.")]
        public string? Order_Location { get; set; }
    }
    //Digital TechJoint (2022). ASP.NET Identity - User Registration, Login and Log-out. [online] YouTube. Available at: https://www.youtube.com/watch?v=ghzvSROMo_M [Accessed 5 Nov. 2024].
    //Digital TechJoint (2022). ASP.NET MVC - How To Implement Role Based Authorization. YouTube. Available at: https://www.youtube.com/watch?v=qvsWwwq2ynE [Accessed 5 Nov. 2024].
    //Mrzygłód, K., 2022. Azure for Developers. 2nd ed. August: [Meeta Rajani]
}
