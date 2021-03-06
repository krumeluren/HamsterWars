using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class Battle : BaseEntity
{
    public DateTime TimeOfPost { get; set; }
    public int? WinnerHamsterId { get; set; }
    
    [ForeignKey("WinnerHamsterId")]
    public virtual Hamster? WinnerHamster { get; set; }
    public int? LoserHamsterId { get; set; }
    [ForeignKey("LoserHamsterId")]
    public virtual Hamster? LoserHamster { get; set; }
    
    public Battle()
    {
        TimeOfPost = DateTime.Now;
    }
}
