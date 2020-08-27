using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobPlatformer.Animation;
using BlobPlatformer.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlobPlatformer
{
    class Chest : Blok, IUpdateMapObjects
    {
        SpriteAnimation chestAnim;
        private readonly Player player;
        public bool chestOpened;

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


        public Chest(Texture2D tex, Player player, Vector2 pos, TypeBlock _type) : base(tex, pos, Blok.TypeBlock.Chest)
        {
            this.player = player;
            _tex = tex;
            _pos = pos;
            _origin = new Vector2(128 / 2, 128 / 2);
            chestAnim = new SpriteAnimation(WorldAnimationFrames.ChestFrameList);
            chestAnim.AantalBewegingenPerSeconde = 5;
            chestAnim.IsPlaying = false;
        }

        public void Update(GameTime gameTime)
        {

            if (Vector2.Distance(player.Position,this._pos) < 200)
            {
                chestAnim.IsPlaying = true;

                if (!chestAnim.EndOfAnimation)
                {                 
                    chestAnim.Update(gameTime);
                    chestOpened = true;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (chestAnim.IsPlaying)
            {
                spriteBatch.Draw(_tex, _pos, chestAnim.CurrentSourceRect, Color.White, 0f, new Vector2(chestAnim.CurrentSourceRect.Width / 2, chestAnim.CurrentSourceRect.Height / 2), 1f, SpriteEffects.None, 1f);
            }
            else
            {
                spriteBatch.Draw(_tex, _pos, WorldAnimationFrames.ChestFrameList[0], Color.White, 0f, new Vector2(128/2, 128 / 2), 1f, SpriteEffects.None, 1f);
            }
            if (chestOpened)
            {
                spriteBatch.Draw(_tex, _pos, WorldAnimationFrames.ChestFrameList[5], Color.White, 0f, new Vector2(128 / 2, 128 / 2), 1f, SpriteEffects.None, 1f);
            }
        }
    }
}
