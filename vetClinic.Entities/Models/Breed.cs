namespace vetClinic.Entities.Models;

public class Breed : BaseEntity {
    public string Name { get; set; }
    
    public Guid SpeciesID { get; set; }
    public virtual Species? Species { get; set; }
    

    public virtual ICollection<Pet>? Pets { get; set; }
}