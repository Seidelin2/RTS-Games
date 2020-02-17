using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RTS_Games
{
	class Background : GameObject
	{
		private Texture2D backgroundTexture;
		private string backgroundName;

		public override void LoadContent(ContentManager content)
		{
			layerDepth = 0.05f;

			//Baggrunden findes med en string
			backgroundTexture = content.Load<Texture2D>($"Sprites/Background/{backgroundName}");

			origin = new Vector2(backgroundTexture.Width / 2, backgroundTexture.Height / 2);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			//Tegner vores baggrund ud kun en gang
			spriteBatch.Draw(backgroundTexture, position, null, Color.White, 0, origin, size, spriteEffect, layerDepth);
		}

		public override void OnCollision(GameObject other)
		{

		}

		public Background(string background, Vector2 position, float layer)
		{
			backgroundName = background;
			this.position = position;
			layerDepth = layer;
		}
	}
}
