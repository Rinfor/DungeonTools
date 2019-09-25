using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DungeonMaker.Models
{
  public class Abilities
  {
    [ForeignKey("Monster")]
    public int ID { get; set; }
    [Required]
    public string Strength { get; set; }
    [Required]
    public string Dexterity { get; set; }
    [Required]
    public string Constitution { get; set; }
    [Required]
    public string Intelligence { get; set; }
    [Required]
    public string Wisdom { get; set; }
    [Required]
    public string Charisma { get; set; }

    public virtual Monster Monster { get; set; }
  }
}