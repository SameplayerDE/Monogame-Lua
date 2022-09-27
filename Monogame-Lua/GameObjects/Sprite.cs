using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Lua.GameObjects
{
    public class Sprite : Entity
    {
        private Texture2D _texture;
        public Texture2D Texture
        {
            get => _texture;
            set
            {
                _texture = value;
                OnTextureChangeEvent?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler OnTextureChangeEvent;
    }
}