using System.ComponentModel.DataAnnotations;

namespace LibraryA_01.Dtos
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El Autor es obligatorio")] 
        public string Author { get; set; }

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El año debe ser un valor positivo")]
        public int Year { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El número de páginas debe ser un valor positivo")]
        public int NumberOfPages { get; set; } = 0;

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Available { get; set; } = false;
    }
}
