using System;
using System.Collections.Generic;

namespace Programming101
{
    class Team
    {
        ////////////////////////
        // Constructor
        ////////////////////////
        public Team(string teamName)
        {
            _teamName = teamName;
        }

        ////////////////////////
        // Getter
        ////////////////////////
        public string GetTeamName()
        {
            return _teamName;
        }
        public List<Pokemon> GetPokemon()
        {
            return _pokemonTeam;
        }

        ////////////////////////
        // Methods
        ////////////////////////
        public bool AddPokemon(Pokemon pokemon)
        {
            if(_pokemonTeam.Count >= 6)
            {
                // Team is full
                return false;
            }

            _pokemonTeam.Add(pokemon);

            return true;
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Team name = " + _teamName);
            for(int i = 0; i < _pokemonTeam.Count; ++i)
            {
                _pokemonTeam[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        ////////////////////////
        // Members
        ////////////////////////
        private string _teamName;
        private List<Pokemon> _pokemonTeam = new List<Pokemon>();
    }
}
