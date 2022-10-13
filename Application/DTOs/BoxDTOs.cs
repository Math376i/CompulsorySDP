namespace Application.DTOs;

public class BoxDTOs
{
    public string Name { get; set; }
    public int Height { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
}

public class PartialUpdateBoxDTO
{
    public int? Price { get; set; }
    public string? Name { get; set; }
    public int Id { get; set; }
}