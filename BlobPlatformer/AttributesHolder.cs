using BlobPlatformer.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer
{
    public class AttributesHolder
    {

        private int coins;
        private int lives = 100;

        private readonly Player player;
        public AttributesHolder(Player player)
        {
            this.player = player;
        }

        public int GetLives
        {
            get
            {
                return lives;
            }
        }

        public int GetCoins
        {
            get
            {
                return coins;
            }
        }

        public void DecreasLife(int damage = 1)
        {
            lives -= damage;
        }
        public void AddCoins(int amount = 1)
        {
            coins += amount;
        }

        public void Update()
        {
            if (lives <=0)
            {
                // Do something
            
            }
        }
    }
}
