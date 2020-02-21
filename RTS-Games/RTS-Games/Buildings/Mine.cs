using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RTS_Games.Buildings
{
	class Mine : GameObject
	{
        static Semaphore MySemaphore = new Semaphore(3,3);


		//Texture
		Texture2D unactiveBuilding, activeBuilding;
		private string goldMineName;

		//Mouse Input
		MouseState previousMS = Mouse.GetState();
		MouseState newMS = Mouse.GetState();

		//Activated
		private bool activated;

		public Mine(string goldMine, Vector2 position, float layer)
		{
			goldMineName = goldMine;
			this.position = position;
			layerDepth = layer;
		}

		public override void LoadContent(ContentManager content)
		{
			unactiveBuilding = content.Load<Texture2D>($"Sprites/Buildings/{goldMineName}");
			activeBuilding = content.Load<Texture2D>($"Sprites/Buildings/{goldMineName}_Outline");

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

        //public static void WaitingInLine()
        //{
        //    for (int i = 1; i < 5; i++)
        //    {
        //        new Thread(Enter).Start(i);
        //    }

        //    Thread.Sleep(500);
        //    Console.WriteLine("Main Thread Calls release(3)");
        //    MySemaphore.Release(3);
        //    Console.ReadKey();


        //}

        //static void Enter(object id)
        //{
        //    Console.WriteLine(id + " Starts and waits outside to enter");
        //    MySemaphore.WaitOne();
        //    Console.WriteLine(id + " Enters the Gold Mine!");
        //    Thread.Sleep(1000 * (int)id);
        //    Console.WriteLine(id + " Worker is leavign the mine");
        //    MySemaphore.Release();

        //}
    }
}
