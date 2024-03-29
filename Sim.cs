﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Physics_Sim.Graphics;
using Physics_Sim.Equations;

namespace Physics_Sim
{
    public class Sim : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        CoordinateSystem system;

        public Sim()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            system = new CoordinateSystem(graphics);

            //Vector a = new Vector(5, 35);
            //Vector b = new Vector(5, 57, a.Components());

            //system.AddVector(a);
            //system.AddVector(b);
            //system.AddVector(a + b);
            Line line = new Line(new LinearEquation(1, 0));
            line.AddEquation(new LinearEquation(1, 0));
            //system.AddLine(line);

            float[] constants = new float[4];
            constants[0] = 0;
            constants[1] = 1;
            constants[2] = 1;
            constants[3] = 1;
            line = new Line(new QuadraticEquation(constants));
            system.AddLine(line);

            // This part is just for testing, getting prepped to set up the vector class.

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            system.render();

            base.Draw(gameTime);
        }
    }
}