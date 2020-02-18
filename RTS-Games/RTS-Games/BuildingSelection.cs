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
		List<Buildings> currentlySelectedBuilding = new List<Buildings>();

		public void Update()
		{
			SelectedBuilding();
		}

		public void SelectedBuilding()
		{
			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				currentlySelectedBuilding.Clear();

				int mouseX = Mouse.GetState().X;
				int mouseY = Mouse.GetState().Y;

				Vector2 newPosition = new Vector2(mouseX, mouseY);

				Rectangle mouseRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, 1, 1);

				foreach(GameObject go in GameWorld.gameObjects)
				{
					if(go is Buildings)
					{
						if (mouseRectangle.Intersects((go as Buildings).CollisionBox))
						{
							currentlySelectedBuilding.Add(go as Buildings);
							Console.WriteLine("Building selected");
						}
					}
				}
			}
		}
	}
}
