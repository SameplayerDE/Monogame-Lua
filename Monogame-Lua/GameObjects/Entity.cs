using System;
using Microsoft.Xna.Framework;

namespace Monogame_Lua.GameObjects
{
    
    public class Entity
    {
        private Vector2 _position;
        public Vector2 Position => _position;
        
        public event EventHandler<EntityEventArgs> PositionChanged;
        public event EventHandler<EntityTeleportEventArgs> Teleported;
        public event EventHandler<EntityMoveEventArgs> Moved;

        protected virtual void OnPositionChange(EntityEventArgs args)
        {
            var handler = PositionChanged;
            handler?.Invoke(this, args);
        }
        
        protected virtual void OnTeleport(EntityTeleportEventArgs args)
        {
            var handler = Teleported;
            handler?.Invoke(this, args);
        }
        
        protected virtual void OnMove(EntityMoveEventArgs args)
        {
            var handler = Moved;
            handler?.Invoke(this, args);
        }
        
        public void Teleport(int x, int y)
        {
            var from = _position;
            var to = new Vector2(x, y);
            
            _position.X = x;
            _position.Y = y;
            
            OnPositionChange(new EntityEventArgs
            {
                Entity = this
            });
            OnTeleport(new EntityTeleportEventArgs
            {
                Entity = this,
                From = from,
                To = to
            });
        }
        public void Move(int x, int y)
        {
            var direction = new Vector2(x, y);
            
            _position.X += x;
            _position.Y += y;
            
            OnPositionChange(new EntityEventArgs
            {
                Entity = this
            });
            OnMove(new EntityMoveEventArgs
            {
                Entity = this,
                Direction = direction
            });
        }
    }
}