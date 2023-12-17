using System;
using System.Collections.Generic;

namespace Programming101
{
    class Pokemon
    {
        public Pokemon(string pokemonName, Stats stats)
        {
            _pokemonName = pokemonName;
            _stats = stats;
            _currentLife = stats.GetLife();
        }

        ////////////////////////
        // Getter
        ////////////////////////
        public string GetPokemonName()
        {
            return _pokemonName;
        }

        public Stats GetStats()
        {
            return _stats;
        }

        public List<Skill> GetPokemonSkills()
        {
            return _pokemonSkills;
        }
        public int GetCurrentLife()
        {
            return _currentLife;
        }

        ////////////////////////
        // Methods
        ////////////////////////
        public void TakeDamage(int amountDamage)
        {
            _currentLife -= amountDamage;
        }

        public bool AddSkill(Skill skill)
        {
            if (_pokemonSkills.Count > 4)
            {
                // Pokemon cannot have more than four skill
                return false;
            }

            _pokemonSkills.Add(skill);

            return true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("PokemonName name = " + _pokemonName);
            _stats.DisplayInfo();
            for(int i = 0; i < _pokemonSkills.Count; ++i)
            {
                _pokemonSkills[i].DisplayInfo();
            }
        }

        public void DisplayFightInfo()
        {
            Console.WriteLine("PokemonName name = " + _pokemonName);
            Console.WriteLine($"    Remaning life {_currentLife}");
            _stats.DisplayInfo();
        }

        ////////////////////////
        // Members
        ////////////////////////
        private string _pokemonName;
        private Stats _stats;
        private List<Skill> _pokemonSkills = new List<Skill>();
        private int _currentLife;
    }
}
