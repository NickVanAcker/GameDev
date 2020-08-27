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
   public class Coin : Blok,IUpdateMapObjects
    {
        SpriteAnimation coinAnim;
        Texture2D tex;
        Vector2 pos,origin;
        


        public override Rectangle HitBox
        {
            get
            {
                if (isVisble)
                {
                    return new Rectangle((int)_pos.X - (int)origin.X, (int)_pos.Y - (int)origin.Y, 50, 74);
                }
                return Rectangle.Empty;
            }
        }

        public Coin(Texture2D tex, Vector2 pos, TypeBlock _type) : base(tex,pos,Blok.TypeBlock.Coin)
        {
            _tex = tex;
            _pos = pos;
            origin = new Vector2(50 / 2, 74 / 2);
            coinAnim = new SpriteAnimation(WorldAnimationFrames.CoinFrameList);
        }

        public void Update(GameTime gameTime)
        {
            if (isVisble)
            {
                coinAnim.Update(gameTime);
            }         
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isVisble)
            {
                spriteBatch.Draw(_tex, _pos, coinAnim.CurrentSourceRect, Color.White, 0f, new Vector2(coinAnim.CurrentSourceRect.Width / 2, coinAnim.CurrentSourceRect.Height / 2), 1f, SpriteEffects.None, 1f);
            }
        }
    }
}
