using BlobPlatformer.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
   public class Water: Blok,IUpdateMapObjects
    {
        SpriteAnimation waterAnim;




        public override Rectangle HitBox
        {
            get
            {
                if (isVisble)
                {
                    return new Rectangle((int)_pos.X - (int)_origin.X, (int)_pos.Y - (int)_origin.Y, 128, 128);
                }
                return Rectangle.Empty;
            }
        }

        public Water(Texture2D tex, Vector2 pos, TypeBlock _type) : base(tex, pos, Blok.TypeBlock.Water)
        {
            _tex = tex;
            _pos = pos;
            _origin = new Vector2(128 / 2, 128 / 2);
            waterAnim = new SpriteAnimation(WorldAnimationFrames.WaterFrameList);
            waterAnim.AantalBewegingenPerSeconde = 10;
        }

        public void Update(GameTime gameTime)
        {
            waterAnim.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tex, _pos, waterAnim.CurrentSourceRect, Color.White, 0f, new Vector2(waterAnim.CurrentSourceRect.Width / 2, waterAnim.CurrentSourceRect.Height / 2), 1f, SpriteEffects.None, 1f);
        }

    }
}
