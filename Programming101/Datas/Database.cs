using System.Collections.Generic;

namespace Programming101
{
    // Simulate database
    class Database
    {
        public List<string> PokemonInGame = new List<string>()
        {
            "Raikou",
            "Nidorina",
            "Tortank",
            "Roucool",
            "Alakazam",
            "Staross",
            "Embrochet",
            "Akwakwak",
            "Nidoqueen",
            "Onix",
            "Abra"
        };

        public List<Stats> PokemonStats = new List<Stats>(){
            new Stats(BalanceTypeEnum.AttackSpeed, 5 , 10, 10),
            new Stats(BalanceTypeEnum.LifeAttack, 10, 5, 10),
            new Stats(BalanceTypeEnum.LifeSpeed, 10, 10, 5)
        };

        public Dictionary<string, Skill> Skills = new Dictionary<string, Skill>()
        {
            {"Griffe", new Skill("Griffe", "Lacère l'ennemi avec des griffes acérées pour lui infliger des dégâts.", 40, SkillTypeEnum.Physic)},
            {"Hâte", new Skill("Hâte", "Augmente la Vitesse.", 0, SkillTypeEnum.Statut)},
            {"Lutte", new Skill("Lutte", "Le lanceur s'inflige un quart des dégâts.", 50, SkillTypeEnum.Physic)},
            {"Mur Lumière", new Skill("Mur Lumière", "Réduit de moitié les dégâts causés par une attaque spéciale.", 40, SkillTypeEnum.Statut)},
            {"Tranch'Herbe", new Skill("Tranch'Herbe", "Peut infliger un coup critique.", 55, SkillTypeEnum.Special)}
        };

        public Database()
        {

        }
    }
}
