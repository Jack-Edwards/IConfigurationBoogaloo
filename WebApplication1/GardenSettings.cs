namespace WebApplication1;

public class GardenSettings
{
    public short Staff { get; init; }
    public List<Flower> Flowers { get; init; }

    public GardenSettings(short staff, List<Flower> flowers)
    {
        Staff = staff;
        Flowers = flowers;
    }
}

public class Flower
{
    public bool Perennial { get; init; }
    public string Color { get; init; }

    public Flower(bool perennial, string color)
    {
        Perennial = perennial;
        Color = color;
    }
}