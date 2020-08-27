using BlobPlatformer.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
   public class Collision2D
    {
        // Collision class credits to: https://www.youtube.com/watch?v=CV8P9aq2gQo&
        private Player player;
        private Rectangle colObject;

        public void Update(Player player, Rectangle colObject)
        {
            this.colObject = colObject;
            this.player = player;
        }

        public bool IsTouchingLeft()
        {
            return player.HitBox.Right + player.Velocity.X > colObject.Left &&
              player.HitBox.Left < colObject.Left &&
              player.HitBox.Bottom > colObject.Top &&
              player.HitBox.Top < colObject.Bottom;
        }

        public bool IsTouchingRight()
        {
            return player.HitBox.Left + player.Velocity.X < colObject.Right &&
              player.HitBox.Right > colObject.Right &&
              player.HitBox.Bottom > colObject.Top &&
              player.HitBox.Top < colObject.Bottom;
        }

        public bool IsTouchingTop()
        {
            return player.HitBox.Bottom + player.Velocity.Y > colObject.Top &&
              player.HitBox.Top < colObject.Top &&
              player.HitBox.Right > colObject.Left &&
              player.HitBox.Left < colObject.Right;
        }

        public bool IsTouchingBottom()
        {
            return player.HitBox.Top + player.Velocity.Y < colObject.Bottom &&
              player.HitBox.Bottom > colObject.Bottom &&
              player.HitBox.Right > colObject.Left &&
              player.HitBox.Left < colObject.Right;
        }
    }
}
