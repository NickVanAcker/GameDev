using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class Door: Blok
    {
        private Rectangle dest;

        public override Rectangle HitBox
        {
            get
            {
                if (isVisble)
                {
                    return new Rectangle((int)_pos.X - (int)_origin.X, (int)_pos.Y - (int)_origin.Y, dest.Width, dest.Height);
                }
                return Rectangle.Empty;
            }
        }

        public Door(Texture2D tex,Rectangle dest, Vector2 pos, TypeBlock typeblock) : base(tex,pos,typeblock)
        {
            _origin = new Vector2(dest.X / 2, dest.Y / 2);
            this.dest = dest;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tex, _pos, dest, Color.White, _rotation, _origin, 1f, SpriteEffects.None, 1f);
        }
    }
}
