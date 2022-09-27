using System;

namespace Monogame_Lua.GameObjects
{
    public class LivingSprite : Sprite
    {
        private int _health;
        public int Health => _health;

        public event EventHandler<EntityEventArgs> HealthChanged;
        public event EventHandler<EntityEventArgs> Died;

        protected virtual void OnHealthChange(EntityEventArgs args)
        {
            var handler = HealthChanged;
            handler?.Invoke(this, args);
        }

        protected virtual void OnDeath(EntityEventArgs args)
        {
            var handler = Died;
            handler?.Invoke(this, args);
        }

        public void Heal(int amount)
        {
            _health += amount;
            if (amount != 0)
            {
                OnHealthChange(new EntityEventArgs
                {
                    Entity = this
                });
            }
        }

        public void Damage(int amount)
        {
            Heal(-amount);
            if (Health <= 0)
            {
                OnDeath(new EntityEventArgs
                {
                    Entity = this
                });
            }
        }

        public void Kill()
        {
            Damage(Health);
        }
    }
}