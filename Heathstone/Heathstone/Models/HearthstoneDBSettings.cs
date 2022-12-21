namespace Heathstone.Models;

public class HearthstoneDBSettings
{

    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string  CardsCollectionName { get; set; } = null!;

    public string ClassesCollectionName { get; set; } = null!;

    public string RaritiesCollectionName { get; set; } = null!;

    public string SetsCollectionName { get; set; } = null!;

    public string TypesCollectionName { get; set; } = null!;
}