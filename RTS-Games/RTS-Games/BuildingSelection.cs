using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Games
{
	public class BuildingSelection
	{

		List<Guild> currentlySelectedGuild = new List<Guild>();
		List<Buildings.Mine> currentlySelectedMine = new List<Buildings.Mine>();
		List<Buildings.Farm> currentlySelectedFarm = new List<Buildings.Farm>();
		List<Buildings.LogHouse> currentlySelectedLog = new List<Buildings.LogHouse>();

		public void Update()
		{
			SelectedBuilding();
		}

		public void SelectedBuilding()
		{
			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				currentlySelectedGuild.Clear();

				int mouseX = Mouse.GetState().X;
				int mouseY = Mouse.GetState().Y;

				Vector2 newPosition = new Vector2(mouseX, mouseY);

				Rectangle mouseRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, 1, 1);

				foreach(GameObject go in GameWorld.gameObjects)
				{
					if(go is Guild)
					{
						if (mouseRectangle.Intersects((go as Guild).CollisionBox))
						{
							currentlySelectedGuild.Add(go as Guild);
							Console.WriteLine("Guild selected");
						}
					}

					if (go is Buildings.Mine)
					{
						if (mouseRectangle.Intersects((go as Buildings.Mine).CollisionBox))
						{
							currentlySelectedMine.Add(go as Buildings.Mine);
							Console.WriteLine("Mine selected");
						}
					}

					if (go is Buildings.Farm)
					{
						if (mouseRectangle.Intersects((go as Buildings.Farm).CollisionBox))
						{
							currentlySelectedFarm.Add(go as Buildings.Farm);
							Console.WriteLine("Farm selected");
						}
					}

					if (go is Buildings.LogHouse)
					{
						if (mouseRectangle.Intersects((go as Buildings.LogHouse).CollisionBox))
						{
							currentlySelectedLog.Add(go as Buildings.LogHouse);
							Console.WriteLine("Log selected");
						}
					}
				}
			}
		}
	}
}
