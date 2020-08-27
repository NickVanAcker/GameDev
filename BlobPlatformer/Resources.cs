using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class Resources
    {
        public static Dictionary<string, Texture2D> Images;
        public static Dictionary<string, SoundEffect> Sounds;
        public static Dictionary<string, SpriteFont> Fonts;

        public static void LoadImages(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();
            List<string> graphics = new List<string>()
            {
                "Grass",
                "idle",
                "run",
                "Dirt",
                "jump",
                "Coin",
                "water",
                "Elements",
                "Hills1",
                "Hills2",
                "Mountain1",
                "Mountain2",
                "Mountain3",
                "Mountain4",
                "Cloud1",
                "Cloud2",
                "Sky",
                "Spike_down",
                "Spike_Up",
                "Saw",
                "Chest",
                "buttonLB2",
                "UI",
                "WinterGrass",
                "Snow"
            };


            foreach (string img in graphics)
            {
                Images.Add(img, content.Load<Texture2D>("graphics/" + img));
            }
        }

        public static void LoadSounds(ContentManager content)
        {
            Sounds = new Dictionary<string, SoundEffect>();
            List<string> sounds = new List<string>()
            {
                "coin",
                "hurt"
            };


            foreach (string sfx in sounds)
            {
                Sounds.Add(sfx, content.Load<SoundEffect>("sounds/" + sfx));
            }
        }

        public static void LoadFonts(ContentManager content)
        {
            Fonts = new Dictionary<string, SpriteFont>();
            List<string> fonts = new List<string>()
            {
                "Score",
                "Font"
            };


            foreach (string font in fonts)
            {
                Fonts.Add(font, content.Load<SpriteFont>("fonts/" + font));
            }
        }
    }
}
