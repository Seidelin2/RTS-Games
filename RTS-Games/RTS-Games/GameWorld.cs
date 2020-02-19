using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace RTS_Games
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		public static Vector2 myPosition;

		UnitSelection unitSelection = new UnitSelection();

		public static List<GameObject> gameObjects = new List<GameObject>();
		private static List<GameObject> newObjects = new List<GameObject>();

		//Position
		Vector2 position;

		//Texture2D
		Texture2D collisionTexture;

		//Resolution
		private static Vector2 screenSize;
		public static Vector2 ScreenSize
		{
			get { return screenSize; }
		}

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

			Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			// TODO: Add your initialization logic here
			gameObjects = new List<GameObject>();
            this.IsMouseVisible = true;
			myPosition = new Vector2(960, 540);
			//Tilføjer vores workerunit med filens navn, position og laget dybde
			Workers worker = new Workers("medievalUnit_F", myPosition, 0.12f);
			//Tilføjer vores baggrund med filens navn, position og lager dybde
			Background background = new Background("World_Map", new Vector2(GameWorld.screenSize.X / 2, GameWorld.screenSize.Y / 2), 0.05f);
			gameObjects.Add(background);
			gameObjects.Add(worker);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			foreach(GameObject go in gameObjects)
			{
				go.LoadContent(Content);
			}

			//Collision Texture for sprites
			collisionTexture = Content.Load<Texture2D>("Sprites/CollisionTexture");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			unitSelection.Update();

			//Viser musens koordinat position i DEBUG mode
			MouseState state = Mouse.GetState();


			position.X = state.X;
			position.Y = state.Y;
			//Console.WriteLine(position.X.ToString() + "," + position.Y.ToString());

			//Collision Check in GameObjects
			foreach (GameObject gO in gameObjects)
			{
				gO.Update(gameTime);

				foreach (GameObject other in gameObjects)
				{
					gO.CheckCollision(other);
				}
			}

			//Viser musens koordinat position i DEBUG mode
			


			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

			//Udtegner alle objekter ud med collision texture
			foreach(GameObject go in gameObjects)
			{
				go.Draw(spriteBatch);
				#if DEBUG
				DrawCollisionBox(go);
				#endif
			}

			spriteBatch.End();

            base.Draw(gameTime);
        }

		//Tilføjer et nyt Objekt
		public static void Instantiate(GameObject go)
		{
			newObjects.Add(go);
		}

		public static void InstantiateCall()
		{
			gameObjects.AddRange(newObjects);
			newObjects.Clear();
		}

		//Fjerner vores sprite ved at gå ned til CallDestory()
		public static void Destroy(GameObject go)
		{
			//destroyObject.Add(go);
		}

		private void CallDestory()
		{
			//Ny list tmp
			List<GameObject> tmp = new List<GameObject>();

			//tmp er vores gameObjects
			tmp = gameObjects;

			//For enhver GameObject i destroyObject skal der fjernes en objekt
			//foreach (GameObject go in destroyObject)
			//{
			//	tmp.Remove(go);
			//}

			//destroyObject er vores nye List
			//destroyObject = new List<GameObject>();

			//Listen er vores tmp
			gameObjects = tmp;
		}

		//Udtegner Collsion rundt om vores Sprites
		private void DrawCollisionBox(GameObject go)
		{
			Rectangle collsionBox = go.CollisionBox;
			Rectangle topLine = new Rectangle(collsionBox.X, collsionBox.Y, collsionBox.Width, 1);
			Rectangle bottomLine = new Rectangle(collsionBox.X, collsionBox.Y + collsionBox.Height, collsionBox.Width, 1);
			Rectangle rightLine = new Rectangle(collsionBox.X + collsionBox.Width, collsionBox.Y, 1, collsionBox.Height);
			Rectangle leftLine = new Rectangle(collsionBox.X, collsionBox.Y, 1, collsionBox.Height);

			spriteBatch.Draw(collisionTexture, topLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
			spriteBatch.Draw(collisionTexture, bottomLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
			spriteBatch.Draw(collisionTexture, rightLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
			spriteBatch.Draw(collisionTexture, leftLine, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
		}
	}
}
