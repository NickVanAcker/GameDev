using BlobPlatformer.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class MovePlayer
    {
        KeyboardState pressedKey;
        public static SpriteEffects flip;

        public void Update(Player player)
        {
            pressedKey = Keyboard.GetState();

            if (pressedKey.IsKeyDown(Keys.Q))
            {
                player.PlayerAnimationKey = "run";
                flip = SpriteEffects.FlipHorizontally;
                player.Velocity.X = -3;
            }

            else if (pressedKey.IsKeyDown(Keys.D))
            {
                player.PlayerAnimationKey = "run";
                flip = SpriteEffects.None;
                player.Velocity.X = 3;
            }

            else
            {
                player.PlayerAnimationKey = "idle";
                player.Velocity.X = 0;
            }

            if (pressedKey.IsKeyDown(Keys.Space))
            {
                player.JumpKeyPressed = true;
            }
        }
    }
}
