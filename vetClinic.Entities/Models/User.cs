namespace vetClinic.Entities.Models;

public class User : BaseEntity {
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }  
    public string Email { get; set; } 
    public bool isAdmin { get; set; }
    
    public virtual ICollection<Pet>? Pets { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
}