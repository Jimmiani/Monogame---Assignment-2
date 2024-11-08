using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Monogame___Assignment_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D textureWood;
        SpriteFont pumpkinFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            textureWood = Content.Load<Texture2D>("woodTile");
            pumpkinFont = Content.Load<SpriteFont>("pumpkinFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(pumpkinFont, "Checkerboard!", new Vector2(100, 0), Color.Black);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                        _spriteBatch.Draw(textureWood, new Rectangle((i * 80) ,(j * 80) ,80, 80), Color.PaleGoldenrod);
                    else
                        _spriteBatch.Draw(textureWood, new Rectangle((i * 80), (j * 80), 80, 80), Color.Brown);
                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
