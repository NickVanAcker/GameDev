using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer.Sprites
{
    public class EnemySpike : Blok, IUpdateMapObjects
    {
        private readonly Player player;
        public override Rectangle HitBox
        {
            get
            {
                if (isVisble)
                {
                    return new Rectangle((int)_pos.X - (int)_origin.X, (int)_pos.Y - (int)_origin.Y, _tex.Width, _tex.Height);
                }
                return Rectangle.Empty;
            }
        }

        public EnemySpike(Texture2D tex, Vector2 pos, Player player, TypeBlock _type) : base(tex, pos, Blok.TypeBlock.Enemy)
        {
            this.player = player;
            _tex = tex;
            _pos = pos;
        }

        public void Update(GameTime gameTime)
        {
            if (Vector2.Distance(player.Position,_pos) < 100)
            {

            }
        }
    }
}
