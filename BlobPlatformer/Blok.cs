using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class Blok
    {
        protected Texture2D _tex;
        protected Vector2 _pos;
        private TypeBlock _typeBlock;
        public enum TypeBlock { Nothing, Enemy, Water,Coin,Chest,Exit }
        public bool isVisble = true;
        protected Vector2 _origin;
        protected float _rotation;

        public virtual Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)_pos.X - (int)_origin.X, (int)_pos.Y - (int)_origin.Y, _tex.Width, _tex.Height);
            }
        }

        public TypeBlock getTypeBlock
        {
            get
            {
                return _typeBlock;
            }
        }


        public Blok(Texture2D tex, Vector2 pos, TypeBlock typeblock)
        {
            _tex = tex;
            _pos = pos;
            _typeBlock = typeblock;
            _origin = new Vector2(_tex.Width / 2, _tex.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isVisble )
            {
                spriteBatch.Draw(_tex, _pos, null, Color.White, _rotation, _origin, 1f, SpriteEffects.None, 1f);
            }
        }
    }
}
