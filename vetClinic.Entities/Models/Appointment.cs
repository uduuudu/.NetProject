namespace vetClinic.Entities.Models;

public class Appointment : BaseEntity {
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    
    public Guid UserID { get; set; }
    public virtual User? User { get; set; }

    public Guid ServiceID { get; set; }
    public virtual Service? Service { get; set; }

    public Guid PetID { get; set; }
    public virtual Pet? Pet { get; set; }
        
}