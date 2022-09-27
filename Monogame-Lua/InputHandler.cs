using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Lua
{
    public class InputHandler
    {
        protected KeyboardState CurrKeyboardState;
        protected KeyboardState PrevKeyboardState;
        
        public void Update(GameTime gameTime)
        {
            PrevKeyboardState = CurrKeyboardState;
            CurrKeyboardState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return CurrKeyboardState.IsKeyDown(key);
        } 
        
    }
}