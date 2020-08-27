using BlobPlatformer.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class Camera2D
    {
        public Matrix Transform { get; private set; }

        public void Follow(Player target)
        {
            Transform = Matrix.CreateTranslation(-target.Position.X - (target.HitBox.Width / 2), -target.Position.Y - (target.HitBox.Height / 2), 0) * Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);
        }
    }
}
