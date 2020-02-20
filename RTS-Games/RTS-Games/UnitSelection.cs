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
        //List for currently selected workers
        List<Workers> currentlySelectedWorker = new List<Workers>();

        //Update method we call over in game world
        public void Update()
        {
            SelectedWorker();
            MoveSelectedWorker();
        }

        public void SelectedWorker()
        {
            //Left click to select a worker
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
                        if (mouseRectangle.Intersects((x as Workers).workerBox))
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
            //When a Worker is selected 
            //Press Right Click to move it to the mouse position
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                int mouseX = Mouse.GetState().X;
                int mouseY = Mouse.GetState().Y;

                Vector2 newPosition = new Vector2(mouseX, mouseY);

                Rectangle mouseRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, 1, 1);

                foreach (Workers workwork in currentlySelectedWorker)
                {
                    workwork.Move(newPosition);
                    Console.WriteLine("Moving Worker to mouse position");
                }
            }
        }
    }
}
