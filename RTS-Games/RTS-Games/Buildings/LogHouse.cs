using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RTS_Games.Buildings
{
	class LogHouse : GameObject
	{
		//Texture
		Texture2D unactiveBuilding, activeBuilding;
		private string logHouseName;

		//Mouse Input
		MouseState previousMS = Mouse.GetState();
		MouseState newMS = Mouse.GetState();

		//Activated
		private bool activated;

		public LogHouse(string logName, Vector2 position, float layer)
		{
			logHouseName = logName;
			this.position = position;
			layerDepth = layer;
		}

		public override void LoadContent(ContentManager content)
		{
			unactiveBuilding = content.Load<Texture2D>($"Sprites/Buildings/{logHouseName}");
			activeBuilding = content.Load<Texture2D>($"Sprites/Buildings/{logHouseName}_Outline");

			if (activated)
			{
				sprite = activeBuilding;
			}
			else
			{
				sprite = unactiveBuilding;
			}

			origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
		}

		public override void Update(GameTime update)
		{
			CheckBuilding();
			base.Update(update);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, size, SpriteEffects.None, 0.1f);
		}

		public override void OnCollision(GameObject other)
		{

		}

		protected void CheckBuilding()
		{
			newMS = Mouse.GetState();
			Rectangle mouseRectangle = new Rectangle(newMS.X, newMS.Y, 1, 1);

			//Hover ved vores bygninger
			if (mouseRectangle.Intersects(CollisionBox))
			{
				//Set sprite til active
				if (sprite != activeBuilding)
				{
					sprite = activeBuilding;
				}
			}
			else
			{
				//Set sprite til unactive
				if (sprite != unactiveBuilding)
				{
					sprite = unactiveBuilding;
				}
			}

			previousMS = newMS;
		}
	}
}
