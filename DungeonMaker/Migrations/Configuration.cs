namespace DungeonMaker.Migrations
{
  using System.Data.Entity.Migrations;
  using Models;

  internal sealed class Configuration : DbMigrationsConfiguration<DungeonMaker.Models.MonsterContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(DungeonMaker.Models.MonsterContext context)
    {
      context.Monsters.AddOrUpdate(x => x.MonsterID,
      new Monster
      {
        MonsterID = 1,
        Name = "Goblin",
        ArmorClass = 15,
        HitPoints = 7,
        Speed = "30 ft",
        SKills = "Stealth +6",
        Senses = "darkvision 60 ft, passive Perception 9",
        Languages = " Common, Goblin",
        Challenge = "1/4 (50 xp)",
        Traits = "Nimble Escape: The goblin can take the Disengage or Hide action as a bonus action on each of its turns.",
        Actions = "Scimitar: Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 5 (1d6 + 2) slashing damage. ;Shortbow: Ranged Weapon Attack: +4 to hit, range 80/320 ft., one target. Hit: 5 (1d6 + 2) piercing damage."
      });

       context.Abilities.AddOrUpdate(x => x.ID,
       new Abilities { ID = 1, Strength = "8(-1)", Dexterity = "14(+2)", Constitution = "10(+0)", Intelligence = "10(+0)", Wisdom = "8(-1)", Charisma = "8(-1)" });

      context.Monsters.AddOrUpdate(x => x.MonsterID,
        new Monster
        {
          MonsterID = 2,
          Name = "Skeleton",
          ArmorClass = 13,
          HitPoints = 13,
          Speed = "30 ft",
          DamageVulnerabilities = "Bludgeoning",
          DamageImmunities = "Poison",
          ConditionImmunities = "Exhaustion, Poisoned",
          Senses = "darkvision 60 ft, passive Perception 9",
          Languages = "understands all languages it knew in life but can’t speak",
          Challenge = "1/4 (50 xp)",
          Actions = "Shortsword: Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 5 (1d6 + 2) piercing damage. ;Shortbow: Ranged Weapon Attack: +4 to hit, range 80/320 ft., one target. Hit: 5 (1d6 + 2) piercing damage."
        });

      context.Abilities.AddOrUpdate(x => x.ID,
      new Abilities { ID = 2, Strength = "10 (+0)", Dexterity = "14 (+2)", Constitution = "15 (+2)", Intelligence = "6 (-2)", Wisdom = "8 (-1)", Charisma = "5 (-3)" });

      context.Monsters.AddOrUpdate(x => x.MonsterID,
      new Monster
      {
        MonsterID = 3,
        Name = "Zombie",
        ArmorClass = 8,
        HitPoints = 22,
        Speed = "20 ft",
        SavingThrows = "Wis +0",
        DamageVulnerabilities = "Bludgeoning",
        DamageImmunities = "Poison",
        ConditionImmunities = "Poisoned",
        Senses = "darkvision 60 ft, passive Perception 8",
        Languages = "understands all languages it knew in life but can’t speak",
        Challenge = "1/4 (50 xp)",
        Traits = "Undead Fortitude: If damage reduces the zombie to 0 hit points, it must make a Constitution saving throw with a DC of 5 + the damage taken, unless the damage is radiant or from a critical hit. On a success, the zombie drops to 1 hit point instead.",
        Actions = "Slam: Melee Weapon Attack: +3 to hit, reach 5 ft., one target. Hit: 4 (1d6 + 1) bludgeoning damage."
      });

      context.Abilities.AddOrUpdate(x => x.ID,
      new Abilities { ID = 3, Strength = "13 (+1)", Dexterity = "6 (-2)", Constitution = "16(+3)", Intelligence = "3 (-4)", Wisdom = "6 (-2)", Charisma = "5 (-3)" });

      context.Monsters.AddOrUpdate(x => x.MonsterID,
      new Monster
      {
        MonsterID = 4,
        Name = "Kobold",
        ArmorClass = 12,
        HitPoints = 5,
        Speed = "30 ft",
        Senses = "darkvision 60 ft, passive Perception 8",
        Languages = "Common, Draconic",
        Challenge = "1/8 (25 xp)",
        Traits = "Pack Tactics: The kobold has advantage on an attack roll against a creature if at least one of the kobold’s allies is within 5 feet of the creature and the ally isn’t Incapacitated. " +
        ";Sunlight Sensitivity: While in sunlight, the kobold has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
        Actions = "Dagger: Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 4 (1d4 + 2) piercing damage. ;Sling: Ranged Weapon Attack: +4 to hit, range 30/120 ft., one target. Hit: 4 (1d4 + 2) bludgeoning damage."
      });

      context.Abilities.AddOrUpdate(x => x.ID,
      new Abilities { ID = 4, Strength = "7 (-2)", Dexterity = "15 (+2)", Constitution = "9 (-1)", Intelligence = "8 (-1)", Wisdom = "7 (-2)", Charisma = "8 (-1)" });

      context.Monsters.AddOrUpdate(x => x.MonsterID,
      new Monster
      {
        MonsterID = 5,
        Name = "Gray Ooze",
        ArmorClass = 8,
        HitPoints = 22,
        Speed = "10 ft., climb 10 ft",
        SKills = "Stealth +2",
        DamageResistances = "acid, cold, fire",
        ConditionImmunities = "Blinded, Charmed, Deafened, Exhaustion, Frightened, Prone",
        Senses = "blindsight 60 ft. (blind beyond this radius), passive Perception 8",
        Languages = "-",
        Challenge = "1/2 (100 xp)",
        Traits = "Amorphous: The ooze can move through a space as narrow as 1 inch wide without squeezing. " +
        ";Corrode Metal: Any nonmagical weapon made of metal that hits the ooze corrodes. After dealing damage, the weapon takes a permanent and cumulative -1 penalty to damage rolls. If its penalty drops to -5, the weapon is destroyed. Nonmagical ammunition made of metal that hits the ooze is destroyed after dealing damage. The ooze can eat through 2-inch-thick, nonmagical metal in 1 round. " +
        ";False Appearance: While the ooze remains motionless, it is indistinguishable from an oily pool or wet rock.",
        Actions = "Pseudopod: Melee Weapon Attack: +3 to hit, reach 5 ft., one target. Hit: 4 (1d6 + 1) bludgeoning damage plus 7 (2d6) acid damage, and if the target is wearing nonmagical metal armor, its armor is partly corroded and takes a permanent and cumulative -1 penalty to the AC it offers. The armor is destroyed if the penalty reduces its AC to 10."
      });

      context.Abilities.AddOrUpdate(x => x.ID,
      new Abilities { ID = 5, Strength = "12 (+1)", Dexterity = "6 (-2)", Constitution = "16 (+3)", Intelligence = "1 (-5)", Wisdom = "6 (-2)", Charisma = "2 (-4)" });

      context.Monsters.AddOrUpdate(x => x.MonsterID,
      new Monster
      {
        MonsterID = 6,
        Name = "Ogre",
        ArmorClass = 11,
        HitPoints = 59,
        Speed = "40 ft",
        Senses = "darkvision 60 ft, passive Perception 8",
        Languages = "Common, Giant",
        Challenge = "2 (450 xp)",
        Actions = "Greatclub: Melee Weapon Attack: +6 to hit, reach 5 ft., one target. Hit: 13 (2d8 + 4) bludgeoning damage. ;Javelin: Melee or Ranged Weapon Attack: +6 to hit, reach 5 ft. or range 30/120 ft., one target. Hit: 11 (2d6 + 4) piercing damage."
      });

      context.Abilities.AddOrUpdate(x => x.ID,
      new Abilities { ID = 6, Strength = "19 (+4)", Dexterity = "8 (-1)", Constitution = "16 (+3)", Intelligence = "5 (-3)", Wisdom = "7 (-2)", Charisma = "7 (-2)" });

      context.Monsters.AddOrUpdate(x => x.MonsterID,
      new Monster
      {
        MonsterID = 7,
        Name = "Bugbear",
        ArmorClass = 16,
        HitPoints = 27,
        Speed = "30 ft",
        SKills = "Stealth +6, Survival +2",
        Senses = "darkvision 60 ft., passive Perception 10",
        Languages = "Common, Goblin",
        Challenge = "1 (200 xp)",
        Traits = "Brute: A melee weapon deals one extra die of its damage when the bugbear hits with it (included in the attack). " +
        ";Surprise Attack: If the bugbear surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 7 (2d6) damage from the attack.",
        Actions = "Morningstar: Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 11 (2d8 + 2) piercing damage. ;Javelin: Melee or Ranged Weapon Attack: +4 to hit, reach 5 ft. or range 30/120 ft., one target. Hit: 9 (2d6 + 2) piercing damage in melee or 5 (1d6 + 2) piercing damage at range."
      });

      context.Abilities.AddOrUpdate(x => x.ID,
      new Abilities { ID = 7, Strength = "15 (+2)", Dexterity = "14 (+2)", Constitution = "13 (+1)", Intelligence = "8 (-1)", Wisdom = "11 (+0)", Charisma = "9 (-1)" });

    }
  }
}
