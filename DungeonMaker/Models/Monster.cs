using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DungeonMaker.Models
{
  public class Monster
  {
    [Key]
    public int MonsterID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int ArmorClass { get; set; }
    [Required]
    public short HitPoints { get; set; }
    [Required]
    public string Speed { get; set; }
    public string SavingThrows { get; set; }
    public string SKills { get; set; }
    public string DamageVulnerabilities { get; set; }
    public string DamageResistances { get; set; }
    public string DamageImmunities { get; set; }
    public string ConditionImmunities { get; set; }
    public string Senses { get; set; }
    [Required]
    public string Languages { get; set; }
    [Required]
    public string Challenge { get; set; }
    public string Traits { get; set; }
    public string Actions { get; set; }

    public virtual Abilities MonsterAbilities { get; set; }



    //public string[] TraitsData
    //{
    //  get
    //  {
    //    return Traits.Split(';');
    //  }
    //  set
    //  {
    //    Traits = string.Join(";", value.Select(p => p.ToString()).ToArray());
    //  }
    //}

    //public string[] ActionsData
    //{
    //  get
    //  {
    //    return Actions.Split(';');
    //  }
    //  set
    //  {
    //    Actions = string.Join(";", value.Select(p => p.ToString()).ToArray());
    //  }
    //}
  }
}