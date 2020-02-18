using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Games
{
    public class UnitSelection
    {
        List<Workers> currentlySelectedWorker = new List<Workers>();

        public void Update()
        {
            SelectedWorker();
        }

        public void SelectedWorker()
        {

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                currentlySelectedWorker.Clear();

                int mouseX = Mouse.GetState().X;
                int mouseY = Mouse.GetState().Y;

                Vector2 newPosition = new Vector2(mouseX, mouseY);

                Rectangle mouseRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, 1 , 1 );

                foreach  (GameObject x in GameWorld.gameObjects)
                {
                    if (x is Workers)
                    {
                        if (mouseRectangle.Intersects((x as Workers).CollisionBox))
                        {
                            currentlySelectedWorker.Add(x as Workers);
                            //Console.WriteLine("Hello there Mr Kanobi");
                        }
                    }
                }
            }
        }

        public void MoveSelectedWorker()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {

                int mouseX = Mouse.GetState().X;
                int mouseY = Mouse.GetState().Y;

                Vector2 newPosition = new Vector2(mouseX, mouseY);

                Rectangle mouseRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, 1, 1);

                foreach (Workers workwork in currentlySelectedWorker)
                {
                    //workwork.move(newPosition)
                }
            }
        }


    }
}
