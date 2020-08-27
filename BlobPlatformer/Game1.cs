using BlobPlatformer.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using BlobPlatformer.Snow;

namespace BlobPlatformer
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MovePlayer move;
        Player player;
        Level level;
        Camera2D camera;
        AttributesHolder attributes;
        GUI gui;
        List<ScrollingBackground> _scrollingBackgrounds;
        Song music;
        Menu menu;
        SnowEmitter _snowEmitter;


        public static int ScreenHeight = 1024;
        public static int ScreenWidth = 1920;

        public static Random Random;

        bool _escState = false;
        bool _escWaarde = false;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();
            player = new Player();
            camera = new Camera2D();
            move = new MovePlayer();
            level = new Level(player);
            attributes = new AttributesHolder(player);
            gui = new GUI(attributes,player);
            Random = new Random();


            base.Initialize();
        }


        protected override void LoadContent()
        { 
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Resources.LoadImages(Content);
            Resources.LoadFonts(Content);
            Resources.LoadSounds(Content);

            menu = new Menu(this, GraphicsDevice,level);

            music = Content.Load<Song>("sounds\\Grassland");
            MediaPlayer.IsRepeating = true;

           // MediaPlayer.Play(music);

            level.CreateWorld(level.Level1);

            _scrollingBackgrounds = new List<ScrollingBackground>()
            {
                new ScrollingBackground(Resources.Images["Hills1"],player,60f)
                {
                    Layer = 0.99f,
                },
                new ScrollingBackground(Resources.Images["Mountain1"],player,60f)
                {
                    Layer = 0.9f,
                },
                new ScrollingBackground(Resources.Images["Hills2"],player,40f)
                {
                    Layer = 0.8f,
                },
                new ScrollingBackground(Resources.Images["Cloud1"],player,25f,true)
                {
                    Layer = 0.97f,
                },
                new ScrollingBackground(Resources.Images["Mountain2"],player,30f)
                {
                    Layer = 0.89f,
                },
                new ScrollingBackground(Resources.Images["Mountain3"],player,20f)
                {
                    Layer = 0.88f,
                },
                new ScrollingBackground(Resources.Images["Cloud2"],player,10f,true)
                {
                    Layer = 0.70f, 
                },
                new ScrollingBackground(Resources.Images["Mountain4"],player,45f)
                {
                    Layer = 0.87f,
                },
                new ScrollingBackground(Resources.Images["Sky"],player,0f)
                {
                    Layer = 0.1f,
                },

            };
            _snowEmitter = new SnowEmitter(new Snow.Snow(Resources.Images["Snow"]));

        }


        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && _escState)
            {
                _escState = false;
                _escWaarde = !_escWaarde;
                menu.Enable(_escWaarde);
                IsMouseVisible = _escWaarde;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Escape) && !_escState)
                _escState = true;
          
            move.Update(player);
            player.PhysicsUpdate(gameTime);

            menu.Update(gameTime);

            foreach (Blok item in level.blokArray)
            {
                if (item != null)
                {
                    bool colCheck = player.CheckCollision(item.HitBox);
                    if (colCheck)
                    {
                        if (item.getTypeBlock == Blok.TypeBlock.Coin)
                        {
                            Resources.Sounds["coin"].Play();
                            item.isVisble = false;
                            attributes.AddCoins();
                        }
                        if (item.getTypeBlock == Blok.TypeBlock.Water)
                        {
                            if (player.Velocity.X>0)
                            {
                                player.Velocity.X = 0.1f;
                            }
                            else if(player.Velocity.X < 0)
                            {
                                player.Velocity.X = -0.1f;
                            }
                        }

                        if (item.getTypeBlock == Blok.TypeBlock.Enemy)
                        {
                            attributes.DecreasLife();                            
                        }

                        if (item.getTypeBlock == Blok.TypeBlock.Chest)
                        {
                            attributes.AddCoins(10);
                        }

                        if (item.getTypeBlock == Blok.TypeBlock.Exit)
                        {
                            player.Position = new Vector2(250, 200);
                            level.CreateWorld(level.Level1);
                            level.Snow = true;
                        }
                    }
                }
            }

            attributes.Update();
            player.Update(gameTime);

            
            camera.Follow(player);
            foreach (var sb in _scrollingBackgrounds)
            {
                sb.Update(gameTime);
            }
            if (level.Snow)
            {
                _snowEmitter.Update(gameTime);
            }
            level.UpdateWorld(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MidnightBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: camera.Transform);
            player.Draw(spriteBatch);
            foreach (var sb in _scrollingBackgrounds)
            {
                sb.Draw(spriteBatch);
            }
            level.DrawWorld(spriteBatch);
            level.UpdateWorld(gameTime);
            gui.Draw(spriteBatch);
            spriteBatch.End();
            menu.Draw(gameTime, spriteBatch);

            if (level.Snow)
            {
                spriteBatch.Begin();
                _snowEmitter.Draw(gameTime, spriteBatch);
                spriteBatch.End();
            }



            base.Draw(gameTime);
        }
    }
}
