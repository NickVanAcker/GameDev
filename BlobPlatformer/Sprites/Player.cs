using BlobPlatformer.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer.Sprites
{
    public class Player
    {
        #region Animatie variabelen
        public string PlayerAnimationKey;
        SpriteAnimation currentAnimation;
        SpriteAnimation walk;
        SpriteAnimation idle;
        SpriteAnimation jump;
        SpriteAnimation fall;
        #endregion

        #region Physics variabelen
        public bool JumpKeyPressed;
        private bool isTouchingGround = false;
        private bool gravity = true;
        private bool canJump = true;
        private float gravityFactor = 0.25f;

        #endregion


        Collision2D collision;

        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)position.X - (int)origin.X, (int)position.Y - (int)origin.Y, 73, 73);
            }
        }
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private Vector2 origin;
        public Vector2 Velocity = new Vector2(0, 0);

        public Player()
        {
            // Initializatie van animatie van de speler
            walk = new SpriteAnimation(PlayerAnimationFrames.WalkFramesList);
            idle = new SpriteAnimation(PlayerAnimationFrames.IdleFramesList);
            jump = new SpriteAnimation(PlayerAnimationFrames.JumpFramesList);
            fall = new SpriteAnimation(PlayerAnimationFrames.FallFramesList);
            idle.AantalBewegingenPerSeconde = 30;
            currentAnimation = idle;
            PlayerAnimationKey = "idle";

            collision = new Collision2D();
            position = new Vector2(250, 790); // start positie
            origin = new Vector2(73 / 2, 73 / 2); // origin
        }

        public void Update(GameTime gameTime)
        {
            if (PlayerAnimationKey == "run")
            {
                currentAnimation = walk;
            }
            else if (JumpKeyPressed)
            {
                currentAnimation = jump;
            }

            else
            {
                currentAnimation = idle;
            }

            if (Velocity.Y < 0)
            {
                PlayerAnimationKey = "jump";
                currentAnimation = jump;
            }
            else if(Velocity.Y > 0 && !isTouchingGround)
            {
                PlayerAnimationKey = "jump";
                currentAnimation = fall;
            }

            
            currentAnimation.Update(gameTime);
            Position += Velocity;
        }

        public void PhysicsUpdate(GameTime gameTime)
        {
            if (JumpKeyPressed && !canJump)
            {
                position.Y -= 10f; 
                Velocity.Y = -12f; 
                canJump = true;
            }
            if (gravity)
            {
                Velocity.Y += gravityFactor * 1f;
            }
            if (isTouchingGround)
            {
                Velocity.Y = 0;
                canJump = false;
                JumpKeyPressed = false;
                isTouchingGround = false;
            }

        }


        public bool CheckCollision(Rectangle check)
        {
            collision.Update(this,check);
            if (collision.IsTouchingLeft() || collision.IsTouchingRight())
            {
                Velocity.X = 0;
                return true;
            }

            if (collision.IsTouchingTop())
            {
                isTouchingGround = true;
                Velocity.Y = 0;
                return true;
            }

            if (collision.IsTouchingBottom())
            {
                Velocity.Y = 0;
                return true;
            }
            else
                return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PlayerAnimationKey != null)
            {
                spriteBatch.Draw(Resources.Images[PlayerAnimationKey], position, currentAnimation.CurrentSourceRect, Color.White, 0f,new Vector2(currentAnimation.CurrentSourceRect.Width/2,currentAnimation.CurrentSourceRect.Height/2), 1, MovePlayer.flip, 1f);
            }
            
        }
    }
}
