using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Games
{
	class BuildingSelection
	{
		List<Buildings> currentlySelectedBuilding = new List<Buildings>();

		public void BuildingSelection()
		{
			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				currentlySelectedBuilding
			}
		}
	}
}
