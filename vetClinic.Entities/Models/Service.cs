namespace vetClinic.Entities.Models;

public class Service : BaseEntity {
    public string Name { get; set; }
    public int Price { get; set; }
    public int ExecutionTime { get; set; }
    
    public virtual ICollection<Appointment>? Appointments { get; set; }
}   