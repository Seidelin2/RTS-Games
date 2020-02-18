using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Games
{
	class StrokeSprite : GameObject
	{
		private float scale = 1.1f;
		private Rectangle ownerCB;

		//Overrides so sprite/owner Collision Box/position and Origin becomes the parent 
		//of strokeSprite, currentCB, position and origin
		public StrokeSprite(Texture2D strokeSprite, Rectangle currentCB, Vector2 position, Vector2 origin)
		{
			this.sprite = strokeSprite;
			ownerCB = currentCB;
			this.position = position;
			this.origin = origin;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(sprite, position, null, Color.HotPink, 0, origin, scale, spriteEffect, 0.08f);
		}

		public override void OnCollision(GameObject other)
		{
		}
		//GameWorld.Destroy(this);
	}
}
