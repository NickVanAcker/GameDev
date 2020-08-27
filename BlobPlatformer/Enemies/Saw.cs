using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlobPlatformer.Enemies
{
    public class Saw : Blok, IUpdateMapObjects
    {

        public Saw(Texture2D tex, Vector2 pos, TypeBlock _type) : base(tex, pos, Blok.TypeBlock.Enemy)
        {

        }


        public void Update(GameTime gameTime)
        {
            _rotation += 5;
        }
    }
}
