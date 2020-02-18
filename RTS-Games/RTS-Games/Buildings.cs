using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RTS_Games
{
	class Buildings : GameObject
	{
		public string buildingName;
		public Buildings(string building, Vector2 position, float layer)
		{
			buildingName = building;
			this.position = position;
			layerDepth = layer;
		}

		public override void LoadContent(ContentManager content)
		{
			sprite = content.Load<Texture2D>($"Sprites/Buildings/{buildingName}");

			origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, size, SpriteEffects.None, 0.1f);
		}

		public override void OnCollision(GameObject other)
		{

		}
	}
}
