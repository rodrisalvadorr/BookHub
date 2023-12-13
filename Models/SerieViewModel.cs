namespace LibraryMVC.Models
{
  public class SerieViewModel
  {
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public int NroVolumes { get; set; }
  }
}