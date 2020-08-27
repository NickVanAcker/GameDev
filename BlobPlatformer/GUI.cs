using BlobPlatformer.Animation;
using BlobPlatformer.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class GUI
    {
        private AttributesHolder _stats;
        private readonly Player _player;

        public GUI(AttributesHolder stats, Player player)
        {
            _player = player;
            _stats = stats;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Tekenen van GUI
            spriteBatch.Draw(Resources.Images["Elements"], new Vector2(_player.Position.X - (Game1.ScreenWidth - 1000), _player.Position.Y - 450), WorldAnimationFrames.StarGUI[0], Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Resources.Fonts["Score"], _stats.GetCoins.ToString(), new Vector2(_player.Position.X - (Game1.ScreenWidth-1200), _player.Position.Y - 450), Color.Black, 0f, new Vector2(0, 0), 1f,SpriteEffects.None,1f);
            spriteBatch.DrawString(Resources.Fonts["Score"], "Health: " + _stats.GetLives.ToString(), new Vector2(_player.Position.X - (Game1.ScreenWidth - 2200), _player.Position.Y - 450), Color.Black, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);

        }
    }
}
