using Programming101.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming101.Manager
{
    class GameManager
    {
        public GameManager()
        {

        }

        public void Run()
        {
            Console.WriteLine("Please select a team name.");
            string teamName = Console.ReadLine();
            myTeam = new Team(teamName);

            bool exit = false;
            string command = "";
            while (exit == false)
            {
                Console.WriteLine("\nMenu chose one");
                Console.WriteLine("1. ListInGame");
                Console.WriteLine("2. ListCaptured");
                Console.WriteLine("3. Search in game and is captured");
                Console.WriteLine("4. AddInTeam");
                Console.WriteLine("5. Display");
                Console.WriteLine("6. Fight");
                Console.WriteLine("7. Exit");

                command = Console.ReadLine();
                command = command.ToLower();
                switch (command)
                {
                    case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Pokemon in Game is");
                        WriteListInConsole(database.PokemonInGame);
                        break;
                    }
                    case "2":
                    {
                        Console.Clear();
                        Console.WriteLine("Pokemon in captured is");
                        WriteListInConsole(playerSave.CapturedPokemon);
                        break;
                    }
                    case "3":
                    {
                        Console.WriteLine("Which pokemon to search");
                        string pokemonToSearch = Console.ReadLine();
                        if (!IsPokemonExistInGame(pokemonToSearch))
                        {
                            Console.WriteLine("Not found in game");
                        }
                        else
                        {
                            Console.WriteLine("Found in game");
                        }
                        if (!IsPokemonExistInSave(pokemonToSearch))
                        {
                            Console.WriteLine("Not found in save");
                        }
                        else
                        {
                            Console.WriteLine("Found in save");
                        }
                        break;
                    }
                    case "4":
                    {
                        Console.Clear();
                        string pokemonChose = ChosePokemon();
                        Stats statsChose = ChoseStat();
                        Pokemon pokemon = new Pokemon(pokemonChose, statsChose);
                        AddSkillsToPokemon(pokemon);
                        myTeam.AddPokemon(pokemon);
                        break;
                    }
                    case "5":
                    {
                        Console.Clear();
                        Console.WriteLine("Team informations :");
                        myTeam.DisplayInfo();
                        break;
                    }
                    case "6":
                    {
                        TurnBaseSystem fight = new TurnBaseSystem(this);
                        while (fight.Isfinished() == false)
                        {
                            fight.Refresh();
                        }
                        break;
                    }
                    case "7":
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.Clear();
                        Console.WriteLine("Command not found");
                        Console.WriteLine(command);
                        break;
                    }
                }
            }
        }
        public bool SearchPokemon(List<string> inSearch, string searchedString)
        {
            for (int i = 0; i < inSearch.Count; ++i)
            {
                if (inSearch[i] == searchedString)
                {
                    //Console.WriteLine(inSearch[i]);
                    return true;
                }
            }

            return false;
        }
        public bool IsPokemonExistInGame(string pokemon)
        {
            if (!SearchPokemon(database.PokemonInGame, pokemon))
            {
                return false;
            }
            return true;
        }
        public bool IsPokemonExistInSave(string pokemon)
        {
            if (!SearchPokemon(playerSave.CapturedPokemon, pokemon))
            {
                return false;
            }
            return true;
        }
        public void WriteSkillInConsole(List<Skill> toDisplay)
        {
            for (int i = 0; i < toDisplay.Count; ++i)
            {
                Console.WriteLine($"{i}. {toDisplay[i].GetSkillName()} ({toDisplay[i].GetDamage()})");
            }
        }
        private Stats SearchStats(List<Stats> inSearch, BalanceTypeEnum searchedType)
        {
            for (int i = 0; i < inSearch.Count; ++i)
            {
                if (inSearch[i].GetBalanceType() == searchedType)
                {
                    return inSearch[i];
                }
            }

            return null;
        }
        private Skill SearchSkill(Dictionary<string, Skill> inSearch, string toSearch)
        {
            foreach (KeyValuePair<string, Skill> keyValue in inSearch)
            {
                if (keyValue.Key == toSearch)
                {
                    return keyValue.Value;
                }
            }

            return null;
        }
        private void WriteListInConsole(List<string> toDisplay)
        {
            for (int i = 0; i < toDisplay.Count; ++i)
            {
                Console.WriteLine(toDisplay[i]);
            }
        }
        private void WriteSkillDictionnaryInConsole(Dictionary<string, Skill> toDisplay)
        {
            foreach (KeyValuePair<string, Skill> keyValue in toDisplay)
            {
                Console.WriteLine(keyValue.Key);
            }
        }
        private string ChosePokemon()
        {
            Console.Clear();
            Console.WriteLine("Chose pokemon from your captured pokemon.");
            Console.WriteLine("Reminder Pokemon captured are ");
            WriteListInConsole(playerSave.CapturedPokemon);
            Console.WriteLine("\n Chose pokemon: ");
            string pokemon = "";

            bool found = false;
            while (found == false)
            {
                pokemon = Console.ReadLine();
                if (SearchPokemon(playerSave.CapturedPokemon, pokemon))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("I didn't found pokemon in your save please try again");
                }
            }
            return pokemon;
        }
        private Stats ChoseStat()
        {
            //Set default stats instance before player chose one
            Stats selectedStat = database.PokemonStats[0];

            bool found = false;
            while (found == false)
            {
                Console.Clear();
                Console.WriteLine("Chose stat balance");
                Console.WriteLine("AttackSpeed");
                Console.WriteLine("LifeAttack");
                Console.WriteLine("LifeSpeed");

                string statsBalance = Console.ReadLine();
                // You can put switch or elseif
                if (statsBalance == "AttackSpeed")
                {
                    selectedStat = SearchStats(database.PokemonStats, BalanceTypeEnum.AttackSpeed);
                    found = true;
                }
                else if (statsBalance == "LifeAttack")
                {
                    selectedStat = SearchStats(database.PokemonStats, BalanceTypeEnum.LifeAttack);
                    found = true;
                }
                else if (statsBalance == "LifeSpeed")
                {
                    selectedStat = SearchStats(database.PokemonStats, BalanceTypeEnum.LifeSpeed);
                    found = true;
                }
                else
                {
                    Console.WriteLine("Sorry i didn't found stat balance");
                }
            }

            return selectedStat;
        }
        private Skill ChoseSkill()
        {
            //Set skill to null
            Skill selectedSkill = null;

            bool found = false;
            while (found == false)
            {
                WriteSkillDictionnaryInConsole(database.Skills);
                Console.WriteLine("\nChose Skill");

                string skillSearched = Console.ReadLine();
                selectedSkill = SearchSkill(database.Skills, skillSearched);

                if (selectedSkill != null)
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Sorry i didn't found selected skill");
                    Console.WriteLine(skillSearched);
                }
            }

            return selectedSkill;
        }
        private void AddSkillsToPokemon(Pokemon pokemon)
        {                   
            // A pokemon cannot have more or less than 4 skills
            int nbSkill = 1;
            while (pokemon.GetPokemonSkills().Count < 4)
            {
                Console.Clear();
                Console.WriteLine("Chose skill " + nbSkill);
                Skill skill = ChoseSkill();
                pokemon.AddSkill(skill);

                nbSkill++;
            }
        }

        Database database = new Database();
        PlayerSave1 playerSave = new PlayerSave1();
        Team myTeam;
    }
}
