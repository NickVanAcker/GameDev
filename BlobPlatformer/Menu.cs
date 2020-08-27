using BlobPlatformer.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class Menu
    {
        public bool _enableMenu = true;
        private List<Button> _component;
        private Game1 _game;
        private Level _level;

        public Menu(Game1 game, GraphicsDevice graphicsDevice,Level level)
        {
            _level = level;
            _game = game;
            var buttonTexture = Resources.Images["UI"];

            var buttonFont = Resources.Fonts["Font"];

            int showPositionButtonX = (game.GraphicsDevice.Viewport.Width / 2) - (258 / 2);
            int showPositionButtonY = game.GraphicsDevice.Viewport.Height; ;

            if (_enableMenu)
            {
                game.IsMouseVisible = false;
                showPositionButtonY = 0;
            }

            var nextLevelButton = new Button(buttonTexture, buttonFont,WorldAnimationFrames.UIFrameList[0])
            {
                Position = new Vector2(showPositionButtonX, showPositionButtonY + 300),
                Text = "Next Level",
            };
            nextLevelButton.Click += nextLevelButton_Click;

            var SpawnButton = new Button(buttonTexture, buttonFont, WorldAnimationFrames.UIFrameList[1])
            {
                Position = new Vector2(showPositionButtonX, showPositionButtonY + 375),
                Text = "Spawn",
            };
            SpawnButton.Click += SpawnButton_Click; ;

            var quitGameButton = new Button(buttonTexture, buttonFont, WorldAnimationFrames.UIFrameList[2])
            {
                Position = new Vector2(showPositionButtonX, showPositionButtonY + 450),
                Text = "Quit game",
            };
            quitGameButton.Click += QuitGameButton_Click; ;

            _component = new List<Button>()
            {
                nextLevelButton,
                SpawnButton,
                quitGameButton,

            };
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void SpawnButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Spawn");
        }

        private void nextLevelButton_Click(object sender, EventArgs e)
        {
            _level.CreateWorld(_level.Level2);
            _level.Snow = true;
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var component in _component)
                component.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }


        public void Update(GameTime gameTime)
        {
            foreach (var component in _component)
                component.Update(gameTime);
        }

        public void Enable(bool state)
        {
            foreach (var component in _component)
                component.Enable(state);

        }
    }
}
