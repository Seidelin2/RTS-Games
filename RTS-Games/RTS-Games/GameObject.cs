using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RTS_Games
{
	public abstract class GameObject
	{
		//Texture, størrelse, dybde og effekter for Sprite
		protected Texture2D sprite;
		protected int spriteHeight;
		protected int spriteWidth;
		protected float layerDepth = 1;
		protected int size = 1;
		protected SpriteEffects spriteEffect = SpriteEffects.None;

		public static List<GameObject> gameObjects = new List<GameObject>();

		//Position og Origin for sprites
		protected Vector2 origin;
		protected Vector2 position;

		//Speed og Velocity
		protected float speed = 300;
		protected Vector2 velocity;

		public virtual void LoadContent(ContentManager content)
		{
			//spriteWidth = sprite.Width;
			//spriteHeight = sprite.Height;
		}

		public virtual void Update(GameTime update)
		{

		}

		public abstract void Draw(SpriteBatch spriteBatch);

		public virtual void Move(GameTime gameTime)
		{
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			position += ((velocity * speed) * deltaTime);
		}

		public virtual Rectangle CollisionBox
		{
			get { return new Rectangle((int)position.X - (int)origin.X, (int)position.Y - (int)origin.Y, sprite.Width, sprite.Height); }
		}

		public abstract void OnCollision(GameObject other);

		public void CheckCollision(GameObject other)
		{
			if (CollisionBox.Intersects(other.CollisionBox))
			{
				OnCollision(other);
			}
		}
	}
}
