using BlobPlatformer.Animation;
using BlobPlatformer.Enemies;
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
    public class Level
    {
        public Blok[,] blokArray;
        private List<IUpdateMapObjects> mapObjects;
        private readonly Player player;
        public bool Snow;

        public Level(Player player)
        {
            this.player = player;
            mapObjects = new List<IUpdateMapObjects>();
            blokArray = new Blok[Level1.GetUpperBound(0) + 1, Level1.GetUpperBound(1) + 1];
        }

        public byte[,] Level1 = new byte[,]
        {
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,1,1,1,1,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,6,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,2,2,0,2,2,2,2,0,2,0,0,0,8,0,0,0,0,0,0,0,0},
            {1,1,4,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };

        public byte[,] Level2 = new byte[,]
{
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,1,1,1,1,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,6,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,0,2,2,0,2,2,2,2,0,2,0,0,0,8,0,0,0,0,0,0,0,10},
            {1,1,9,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
};

        public void CreateWorld(byte[,] level)
        {
            for (int i = 0; i < level.GetUpperBound(0) +1; i++)
            {
                for (int j = 0; j < level.GetUpperBound(1) +1; j++)
                {
                    // j is x cord en i is y cord
                    switch (level[i, j])
                    {
                        case 1:
                            blokArray[i, j] = new Blok(Resources.Images["Dirt"], new Vector2(j * 128, i * 128), Blok.TypeBlock.Nothing);
                            break;
                        case 2:
                            blokArray[i, j] = new Coin(Resources.Images["Coin"], new Vector2(j * 128, i * 128), Blok.TypeBlock.Coin);
                            break;
                        case 3:
                            blokArray[i, j] = new Water(Resources.Images["water"], new Vector2(j * 128, i * 128), Blok.TypeBlock.Water);
                            break;
                        case 4:
                            blokArray[i, j] = new Blok(Resources.Images["Grass"], new Vector2(j * 128, i * 128), Blok.TypeBlock.Nothing);
                            break;
                        case 5:
                            blokArray[i, j] = new EnemySpike(Resources.Images["Spike_Up"], new Vector2(j * 128, i * 128), player, Blok.TypeBlock.Enemy);
                            break;
                        case 6:
                            blokArray[i, j] = new EnemySpike(Resources.Images["Spike_down"], new Vector2(j * 128, i * 128), player, Blok.TypeBlock.Enemy);
                            break;
                        case 7:
                            blokArray[i, j] = new Saw(Resources.Images["Saw"], new Vector2(j * 128, i * 128), Blok.TypeBlock.Enemy);
                            break;
                        case 8:
                            blokArray[i, j] = new Chest(Resources.Images["Chest"],player, new Vector2(j * 128, i * 128), Blok.TypeBlock.Chest);
                            break;
                        case 9:
                            blokArray[i, j] = new Blok(Resources.Images["WinterGrass"], new Vector2(j * 128, i * 128), Blok.TypeBlock.Nothing);
                            break;
                        case 10:
                            blokArray[i, j] = new Door(Resources.Images["Elements"],WorldAnimationFrames.Door[0], new Vector2(j * 128, i * 128), Blok.TypeBlock.Exit);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < blokArray.GetUpperBound(0) + 1 ; i++)
            {
                for (int j = 0; j < blokArray.GetUpperBound(1) + 1 ; j++)
                {
                    if (blokArray[i,j] !=null)
                    {
                        blokArray[i, j].Draw(spriteBatch);
                    }
                }
            }
        }



        public void UpdateWorld(GameTime gameTime)
        {
            foreach (Blok item in blokArray)
            {
                if (item is IUpdateMapObjects)
                {
                    IUpdateMapObjects updateobject = (IUpdateMapObjects)item;
                    updateobject.Update(gameTime);
                }
            }
        }
    }
}
