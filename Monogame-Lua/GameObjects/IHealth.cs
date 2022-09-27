using System;

namespace Monogame_Lua.GameObjects
{
    public interface IHealth
    {
        protected int _health { get; set; }
        public int Health => _health;

        public event EventHandler<EntityEventArgs> HealthChanged;
        public event EventHandler<EntityEventArgs> Died;
        

        public void Heal(int amount)
        {
            _health += amount;
        }

        public void Damage(int amount)
        {
            Heal(-amount);
            
        }

        public void Kill()
        {
            Damage(Health);
        }
    }
}