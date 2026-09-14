namespace GameDirectoryService.Domain.Entities;

public class Game
{
    public int Id { get; set; }
    public int SteamAppId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Genres { get; set; }
    public string Tags { get; set; }
    public int EstimatedOwners { get; set; }
    public float ReviewScore { get; set; }
    public DateTime ReleaseDate { get; set; }

    public void ValidatePrice()
    {
        if (Price <= 0) throw new ArgumentException("Price must be positive");
    }
}