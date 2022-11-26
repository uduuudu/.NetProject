namespace vetClinic.Entities.Models;

public class Pet : BaseEntity {
    public string name { get; set; }
    public int weight { get; set; }
    public int age { get; set; }
    public string description { get; set; }

    public Guid UserID { get; set; } 
     public virtual User? User { get; set; }
    
    public Guid SpeciesID { get; set; }
    public virtual Species? Species { get; set; }
    
     public Guid BreedID { get; set; }
    public virtual Breed? Breed { get; set; }

    public virtual ICollection<Appointment>? Appointments { get; set; }
}