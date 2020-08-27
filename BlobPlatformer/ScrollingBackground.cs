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
   public class ScrollingBackground
    {
        private bool _constantSpeed;
        private float layer;
        private float _scrollingSpeed;
        private float _speed;
        private float _layer;
        private readonly Player _player;
        private List<Texture2D> _textures;
        private List<Background> _backgrounds;

        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;

                foreach (var back in _backgrounds)
                    back.Layer = _layer;
            }
        }


        public ScrollingBackground(Texture2D texture, Player player, float scrollingSpeed, bool constantSpeed = false)
  : this(new List<Texture2D>() { texture, texture }, player, scrollingSpeed, constantSpeed)
        {

        }

        public ScrollingBackground(List<Texture2D> textures , Player player, float scrollingspeed, bool constantspeed = false)
        {
            _backgrounds = new List<Background>();
            _textures = textures;
            _player = player;
            _scrollingSpeed = scrollingspeed;
            _constantSpeed = constantspeed;

            for (int i = 0; i < _textures.Count; i++)
            {
                var tex = _textures[i];

                _backgrounds.Add(new Background(tex)
                {
                    Position = new Vector2((i * tex.Width) - 1, Game1.ScreenHeight - tex.Height)
                });
            }

        }

        public void Update(GameTime gameTime)
        {
            ApplySpeed(gameTime);
            CheckPosition();
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var back in _backgrounds)
            {
                back.Draw(spriteBatch);
            }
        }

        void ApplySpeed(GameTime gameTime)
        {
            _speed = (float)(_scrollingSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            if (!_constantSpeed || _player.Velocity.X != 0)
                _speed *= _player.Velocity.X;

            foreach (var back in _backgrounds)
            {
                back.Position.X -= _speed;
            }
        }


    private void CheckPosition()
        {
            for (int i = 0; i < _backgrounds.Count; i++)
            {
                var back = _backgrounds[i];

                if (back.Rectangle.Right <= 0)
                {
                    var index = i - 1;

                    if (index < 0)
                        index = _backgrounds.Count - 1;

                    back.Position.X = _backgrounds[index].Rectangle.Right - (_speed * 2);
                }
            }
        }

    }
}
