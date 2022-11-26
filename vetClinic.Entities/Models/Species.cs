namespace vetClinic.Entities.Models;

public class Species : BaseEntity {
    public string Name { get; set; }
    
    
    public virtual ICollection<Pet>? Pets { get; set; }
    
    public virtual ICollection<Breed>? Breeds { get; set; }

}