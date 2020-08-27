using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer.Animation
{
        public class SpriteAnimation
        {
            public bool EndOfAnimation;
            private List<Rectangle> frames;
            private Rectangle CurrentFrame { get; set; }
            public int AantalBewegingenPerSeconde { get; set; }
            public bool IsPlaying = true;

            private int counter = 0;

            private double x = 0;
            private double offset { get; set; }

            private int _totalWidth = 0;


            public Rectangle CurrentSourceRect
            {
                get { return CurrentFrame; }
            }


        public SpriteAnimation(List<Rectangle> frames)
            {
                this.frames = frames;
                AantalBewegingenPerSeconde = 30;
            }

            public void AddFrames(List<Rectangle> rectangles)
            {
                foreach (Rectangle rect in rectangles)
                {
                    frames.Add(rect);
                }

                CurrentFrame = frames[0];
                offset = CurrentFrame.Width;
                foreach (Rectangle f in frames)
                    _totalWidth += f.Width;
            }


            public void Update(GameTime gameTime)
            {
            if (IsPlaying)
            {
                double temp = CurrentFrame.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);
                x += temp;
                if (x >= CurrentFrame.Width / AantalBewegingenPerSeconde)
                {
                    x = 0;
                    counter++;
                    if (counter >= frames.Count)
                    {
                        counter = 0;
                        EndOfAnimation = true;
                    }
                    CurrentFrame = frames[counter];
                    offset += CurrentFrame.Width;
                }
                if (offset >= _totalWidth)
                {
                    offset = 0;                   
                }
                   
            }
            }
        }
    }
