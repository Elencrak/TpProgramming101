using System;

namespace Programming101
{
    enum BalanceTypeEnum
    {
        AttackSpeed,
        LifeAttack,
        LifeSpeed,
        Custom
    }
    class Stats
    {
        ////////////////////////
        // Constructor
        ////////////////////////
        public Stats(BalanceTypeEnum balanceType, int life, int attack, int speed)
        {
            _balanceType = balanceType;
            _life = life;
            _attack = attack;
            _speed = speed;
        }

        ////////////////////////
        // Getter
        ////////////////////////
        public BalanceTypeEnum GetBalanceType()
        {
            return _balanceType;
        }

        public int GetLife()
        {
            return _life;
        }

        public int GetAttack()
        {
            return _attack;
        }

        public int GetSpeed()
        {
            return _speed;
        }

        ////////////////////////
        // Display info
        ////////////////////////
        public void DisplayInfo()
        {
            Console.WriteLine("Stats");
            Console.WriteLine("     Life = " + _life);
            Console.WriteLine("     Attack = " + _attack);
            Console.WriteLine("     Speed = " + _speed);
        }

        ////////////////////////
        // Members
        ////////////////////////
        private BalanceTypeEnum _balanceType;
        private int _life;
        private int _attack;
        private int _speed;
    }
}
