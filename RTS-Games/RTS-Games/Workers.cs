using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Games
{
    class Workers : GameObject
    {
		//Texture
		private Texture2D activeWorker, unactiveWorker;
        private string workerName;
        Rectangle workerRectangle;

		//Mouse Input
		MouseState previousMS = Mouse.GetState();
		MouseState newMS = Mouse.GetState();
        Vector2 goToThisNewPosition;

		//Available
		private bool activated;


        public Workers(string worker, Vector2 position, float layer)
        {
            workerName = worker;
            this.position = position;
            layerDepth = layer;
        }

        public void Movement(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


                    
        }

        public void GetNewPosition(Vector2 whatever)
        {

            goToThisNewPosition = whatever;


        }
        public override void Update(GameTime update)
        {
            //MovementMethod();

			CheckWorker();

            Movement(update);
            base.Update(update);
        }

        public override void LoadContent(ContentManager content)
        {
            unactiveWorker = content.Load<Texture2D>($"Sprites/NPC/{workerName}");
            activeWorker = content.Load<Texture2D>($"Sprites/NPC/{workerName}_Outline");

			if(activated)
			{
				sprite = activeWorker;
			}
			else
			{
				sprite = unactiveWorker;
			}

            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

        }


        public Rectangle workerBox
        {
            get
            {
                return new Rectangle((int)(position.X - origin.X), (int)(position.Y - origin.Y), sprite.Width, sprite.Height);
            }
        }

        public override void OnCollision(GameObject other)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null , Color.White, 0, origin, size, spriteEffect, layerDepth);
        }

		protected void CheckWorker()
		{
			newMS = Mouse.GetState();
			Rectangle mouseRectangle = new Rectangle(newMS.X, newMS.Y, 1, 1);

			if(mouseRectangle.Intersects(CollisionBox))
			{
				if(sprite != activeWorker)
				{
					sprite = activeWorker;
				}
			}
			else
			{
				if(sprite != unactiveWorker)
				{
					sprite = unactiveWorker;
				}
			}
		}
    }
    
}
