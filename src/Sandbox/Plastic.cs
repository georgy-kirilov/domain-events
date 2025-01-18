namespace Sandbox;

public class Plastic
{
    public int Id { get; set; }
        
    public required Card Card { get; init; }

    public string Location { get; init; } = "Customer";
}
