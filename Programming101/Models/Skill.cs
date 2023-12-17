using System;

namespace Programming101
{
    enum SkillTypeEnum
    {
        Physic,
        Special,
        Statut
    }
    class Skill
    {
        ////////////////////////
        // Constructor
        ////////////////////////
        public Skill(string skillName, string description, int damage, SkillTypeEnum type)
        {
            _skillName = skillName;
            _skillType = type;
            _description = description;
            _damage = damage;
        }

        ////////////////////////
        // Getter
        ////////////////////////
        public string GetSkillName()
        {
            return _skillName;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetDamage()
        {
            return _damage;
        }

        public SkillTypeEnum GetSkillType()
        {
            return _skillType;
        }

        ////////////////////////
        // Methods
        ////////////////////////
        public void DisplayInfo()
        {
            Console.WriteLine("Skills: ");
            Console.WriteLine("     Skill name = " + _skillName);
            Console.WriteLine("     Description = " + _description);
            Console.WriteLine("     Damage = " + _damage);
        }

        ////////////////////////
        // Members
        ////////////////////////
        private string _skillName;
        private SkillTypeEnum _skillType;
        private string _description;
        private int _damage;
    }
}
