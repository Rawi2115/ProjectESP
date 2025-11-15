public class EditProvinceRequest
{
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
   
    public int Population { get; set; }
    public double Area { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}