﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace _3042
{
    public class Game1 : Game
    {
        //Misc
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle ScreenSize;
        BasicSprite MenuBackground;

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

            MenuBackground = new BasicSprite(Content, "graphics/menubackground", ScreenSize.Width, ScreenSize.Height);

            _level1 = new Level1(Content, ScreenSize);

        }

        protected override void Update(GameTime gameTime)
        {
            Input.Begin();
            if (Input.KeyboardReleased(Keys.Escape))
                Exit();
            //Code Bellow this

            IsMouseVisible = false;
            _level1.Update(gameTime);

            //switch (GameMode.Mode)
            //{
            //    case GameMode.EGameMode.MENU: ; break;
            //    case GameMode.EGameMode.LEVELSELECT: _level1.Update(gameTime); break;
            //}
            

            //Code Above this
            Input.End();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            //Code Bellow this

            _level1.Draw(spriteBatch);

            //switch (GameMode.Mode)
            //{
            //    case GameMode.EGameMode.MENU: MenuBackground.Draw(spriteBatch, new Vector2(ScreenSize.Width / 2 + 75, ScreenSize.Height / 2 - 110)); break;
            //    case GameMode.EGameMode.LEVELSELECT: _level1.Draw(spriteBatch); break;
            //}

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
