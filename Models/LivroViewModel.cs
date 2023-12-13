namespace LibraryMVC.Models
{
  public class LivroViewModel
  {
    public int Id { get; set; }
		public string Titulo { get; set; } = string.Empty;
		public string Capa { get; set; } = string.Empty;
		public string Autor { get; set; } = string.Empty;
		public string Editora { get; set; } = string.Empty;
		public string Idioma { get; set; } = string.Empty;
		public string Categoria { get; set; } = string.Empty;
		public SerieViewModel? Serie { get; set; }
		public int? SerieId { get; set; }
		public string Status { get; set; } = string.Empty;
  }
}