using System.ComponentModel.DataAnnotations;

namespace Wijitha_Book_Store.Models
{
    public class Book
    {
        public int Id { get; set; }

      
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }


        [MaxLength(100)]
        public string Description { get; set; }
        public string Author { get; set; }

        [Required,MaxLength(length:13)]
        public string ISBN { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        [Required,DataType(DataType.Date),Display(Name="Date Published")]
        public DateTime DatePublished { get; set; }

        [Required,DataType(DataType.Currency)]
        public int Price { get; set; }

        [Display(Name ="Image URL")]
        public string ImageUrl { get; set; }


    }
}
