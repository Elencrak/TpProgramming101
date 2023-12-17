using Programming101.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming101.Managers
{
    class TurnBaseSystem
    {
        public TurnBaseSystem(GameManager manager)
        {
            _manager = manager;

            Skill claw = new Skill("claw", "", 1, SkillTypeEnum.Physic);

            Stats statsOppenentLeft = new Stats(BalanceTypeEnum.Custom, 10, 5, 2);
            _opponentLeft = new Pokemon("Roucool", statsOppenentLeft);
            _opponentLeft.AddSkill(claw);

            Stats statsOppenentRight = new Stats(BalanceTypeEnum.Custom, 10, 2, 6);
            _opponentRight = new Pokemon("Pikachu", statsOppenentRight);
            _opponentRight.AddSkill(claw);
        }

        public bool Isfinished()
        {
            return _fightEnd;
        }

        public void Refresh()
        {
            Battle();
        }


        private void Battle()
        {
            Console.WriteLine("Let's Battle begin");
            int turn = 0;

            while (_fightEnd == false)
            {
                Pokemon firstAttacker = null;
                Pokemon secondAttacker = null;
                if (_opponentLeft.GetStats().GetSpeed() > _opponentRight.GetStats().GetSpeed())
                {
                    firstAttacker = _opponentLeft;
                    secondAttacker = _opponentRight;
                }
                else
                {
                    firstAttacker = _opponentRight;
                    secondAttacker = _opponentLeft;
                }

                Console.WriteLine("DEBUG First Attakcer is " + firstAttacker.GetPokemonName());
                Console.WriteLine("DEBUG Second Attakcer is " + secondAttacker.GetPokemonName());

                Skill firstAttackerSkill = ChooseAttack(firstAttacker);
                Skill secondAttackerSkill = ChooseAttack(secondAttacker);

                Console.WriteLine($"Turn {turn}");
                ResolveAttack(firstAttacker, firstAttackerSkill, secondAttacker);
                ResolveAttack(secondAttacker, secondAttackerSkill, firstAttacker);

                EndTurn();
                turn++;
            }
        }
        private Skill ChooseAttack(Pokemon pokemon)
        {
            Console.WriteLine($"{pokemon.GetPokemonName()} chose skill to use");
            _manager.WriteSkillInConsole(pokemon.GetPokemonSkills());
            string chosenSkill = Console.ReadLine();

            // Here add security to avoid convert characters to int and check if the skills exist
            int skillIntResult = int.MaxValue;
            while (skillIntResult > pokemon.GetPokemonSkills().Count)
            {                
                try
                {
                    skillIntResult = Int32.Parse(chosenSkill);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{chosenSkill}'");
                }
            }

            switch (chosenSkill)
            {
                case "0":
                {
                    return pokemon.GetPokemonSkills()[0];
                }
                case "1":
                {
                    return pokemon.GetPokemonSkills()[1];
                }
                case "2":
                {
                    return pokemon.GetPokemonSkills()[2];
                }
                case "3":
                {
                    return pokemon.GetPokemonSkills()[3];
                }
            }

            // If player didn't choose skill i choose for him the first skill.
            return pokemon.GetPokemonSkills()[0];
        }
        private void ResolveAttack(Pokemon attacker, Skill skillAttacker, Pokemon defender)
        {
            Console.WriteLine($"{attacker.GetPokemonName()} use {skillAttacker.GetSkillName()} on {defender.GetPokemonName()}");
            Console.WriteLine($"{attacker.GetPokemonName()} make {skillAttacker.GetDamage() + attacker.GetStats().GetAttack()} damage");    
            defender.TakeDamage(skillAttacker.GetDamage() + attacker.GetStats().GetAttack());   
        }

        private void EndTurn()
        {
            _opponentLeft.DisplayFightInfo();
            _opponentRight.DisplayFightInfo();

            if(_opponentLeft.GetCurrentLife() <= 0)
            {
                Console.WriteLine($"Pokemon {_opponentRight.GetPokemonName()} win");
                _fightEnd = true;
            } 
            else if (_opponentRight.GetCurrentLife() <= 0)
            {
                Console.WriteLine($"Pokemon {_opponentLeft.GetPokemonName()} win");
                _fightEnd = true;
            }
            Console.WriteLine("End turn go to next turn");
        }

        GameManager _manager;

        private bool _fightEnd;
        private Pokemon _opponentLeft = null;
        private Pokemon _opponentRight = null;
    }
}
