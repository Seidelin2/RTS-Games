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
	class Guild : GameObject
	{
		public string guildName;
		public Guild(string guild, Vector2 position, float layer)
		{
			guildName = guild;
			this.position = position;
			layerDepth = layer;
		}

		public override void LoadContent(ContentManager content)
		{
			sprite = content.Load<Texture2D>($"Sprites/Buildings/{guildName}");

			origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
		}

		public override void Update(GameTime update)
		{
			CheckAddStroke();

			base.Update(update);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, size, SpriteEffects.None, 0.1f);
		}

		public override void OnCollision(GameObject other)
		{

		}

		private void CheckAddStroke()
		{
			//Gets the mouse's state
			MouseState mouseState = Mouse.GetState();

			//If the position of the mouse is hovering over the Guild, instantiate a strokeSprite
			if(CollisionBox.Contains(mouseState.Position))
			{
				GameWorld.Instantiate(new StrokeSprite(sprite, CollisionBox, position, origin));
			}
		}
	}
}
