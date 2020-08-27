using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BlobPlatformer
{
    public class Background
    {
        public Vector2 Position;

        private Vector2 position;

        private Texture2D _texture;

        private float _layer;

        public float Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }


        public Background(Texture2D texture)
        {
            _texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public Vector2 Postion
        {
            get { return position; }
            set { position = value; }
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, Layer);

        }

    }
}
