using System;
using System.ComponentModel.DataAnnotations;


namespace Amazon.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        [Required(ErrorMessage = "Porfavor ingresa un ISBN")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Porfavor ingresa un titulo")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Porfavor ingresa un Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Porfavor ingresa un Precio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Porfavor ingresar un precio positivo")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Porfavor ingresa un Nro de Paginas")]
        public int? NroPages { get; set; }
        public LevelStock LevelStock { get; set; } = LevelStock.InStock;
        public string Category { get; set; }
    }
}

