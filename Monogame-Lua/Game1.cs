using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Lua.GameObjects;

namespace Monogame_Lua
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private InputHandler _inputHandler;

        private Texture2D _texture000;
        private LivingSprite _sprite000;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _inputHandler = new InputHandler();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _sprite000 = new LivingSprite();
            _sprite000.Heal(10);

            _sprite000.PositionChanged += (s, args) =>
            {
                if (args.Entity.Position.X >= 10)
                {
                    args.Entity.Teleport(0, 0);
                }
            };

            _sprite000.Teleported += (s, args) =>
            {
                var livingEntity = args.Entity as LivingSprite;
                livingEntity?.Damage(1);
            };
            
            _sprite000.HealthChanged += (s, args) =>
            {
                var livingEntity = args.Entity as LivingSprite;
                Console.WriteLine(livingEntity?.Health);
            };
            
            _sprite000.Died += (s, args) =>
            {
                MessageBox.Show("Du bist Tot", "Better Luck Next Time BITCH", new[] { "Fuck U" });
                Exit();
            };
            
            base.Initialize();
        }

        private void Exit(object? sender, EventArgs args)
        {
            Exit();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture000 = Content.Load<Texture2D>("images/dirt");
            _sprite000.Texture = _texture000;
        }

        protected override void Update(GameTime gameTime)
        {
            _inputHandler.Update(gameTime);

            if (_inputHandler.IsKeyDown(Keys.Up))
            {
                _sprite000.Move(0, -1);
            }
            
            if (_inputHandler.IsKeyDown(Keys.Down))
            {
                _sprite000.Move(0, 1);
            }
            
            if (_inputHandler.IsKeyDown(Keys.Right))
            {
                _sprite000.Move(1, 0);
            }
            
            if (_inputHandler.IsKeyDown(Keys.Left))
            {
                _sprite000.Move(-1, 0);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_sprite000.Texture, _sprite000.Position, Color.White);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}