using System;
using Microsoft.Xna.Framework;
using Monogame_Lua.GameObjects;

namespace Monogame_Lua
{
    public class EntityEventArgs : EventArgs
    {
        public Entity Entity { get; set; }
    }

    public class EntityTeleportEventArgs : EntityEventArgs
    {
        public Vector2 From { get; set; }
        public Vector2 To { get; set; }
    }
    
    public class EntityMoveEventArgs : EntityEventArgs
    {
        public Vector2 Direction { get; set; }
    }
}