﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace _3042
{
    public class Game1 : Game
    {
        //Misc
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle ScreenSize;

        //Music
        SoundEffect BackgroundMusicSong;
        SoundEffectInstance BackgroundMusicSongIns;

        //Menu
        Menu MainMenu;

        //Level1
        Level1 _level1;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Misc
            //Set Screen Size
            graphics.PreferredBackBufferWidth = 700;
            graphics.PreferredBackBufferHeight = 700;

            ScreenSize = new Rectangle(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight,
                graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);


            //Code Above this
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Misc
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Menu
            MainMenu = new Menu(Content, ScreenSize);

            //Music
            BackgroundMusicSong = Content.Load<SoundEffect>("sound/Backgroundmusic");
            BackgroundMusicSongIns = BackgroundMusicSong.CreateInstance();
            BackgroundMusicSongIns.Volume = 0.1f;
            BackgroundMusicSongIns.IsLooped = true;
            BackgroundMusicSongIns.Play();

            _level1 = new Level1(Content, ScreenSize);

        }

        protected override void Update(GameTime gameTime)
        {
            Input.Begin();
            if (Input.KeyboardReleased(Keys.Escape))
                Exit();
            //Code Bellow this

            switch (GameMode.Mode)
            {
                case GameMode.EGameMode.LEVELSELECT:
                    {
                        BackgroundMusicSongIns.Volume = 0.03f;
                        IsMouseVisible = false;
                        _level1.Update(gameTime);
                    }; break;
                case GameMode.EGameMode.MENU:
                    {
                        BackgroundMusicSongIns.Volume = 0.1f;
                        IsMouseVisible = true;
                        MainMenu.Update(this);
                    }; break;
                case GameMode.EGameMode.OPTIONS:
                    {
                        IsMouseVisible = true;
                        //MainMenu.Update(this);
                    }; break;
            }

            //Code Above this
            Input.End();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            //Code Bellow this

            switch (GameMode.Mode)
            {
                case GameMode.EGameMode.LEVELSELECT: _level1.Draw(spriteBatch); break;
                case GameMode.EGameMode.MENU: MainMenu.Draw(spriteBatch); break;
                case GameMode.EGameMode.OPTIONS: ; break;
            }

            //Code Above this
            spriteBatch.End();
            base.Draw(gameTime);
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
