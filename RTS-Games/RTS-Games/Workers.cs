using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTS_Games
{



    class Workers : GameObject
    {
        public enum workerBehavivor
        {
            moving,
            mining
        }
        public workerBehavivor workerState;
        Thread workerThread;
        //Texture
        private Texture2D activeWorker, unactiveWorker;
        private string workerName;

        //Mouse Input
        MouseState previousMS = Mouse.GetState();
        MouseState newMS = Mouse.GetState();
        Vector2 goToThisNewPosition = new Vector2(955, 540);

        //Activated
        private bool activated = false;
        bool isAlive = true;

        //Mine Resources
        static decimal balance = 1000;
        public int maxInventory = 50;
        public int currentInventory;
        static Object thisLock = new Object();

        public Workers(string worker, Vector2 position, float layer)
        {
            workerName = worker;
            this.position = position;
            layerDepth = layer;
            workerThread = new Thread(workerBehaviorStates);
            this.workerState = workerBehavivor.moving;
            workerThread.Start();
        }

        public void workerBehaviorStates()
        {
            while (true)
            {
                //Console.WriteLine("I am a thread and i am running");


                switch (workerState)
                {
                    case workerBehavivor.moving:
                        //Moving aroung the map
                        Movement();
                        break;

                    case workerBehavivor.mining:
                        //Mining
                        //Buildings.Mine.WaitingInLine();
                        break;
                    default:
                        Console.WriteLine("Default in the switch statement");
                        break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, size, spriteEffect, layerDepth);
        }

        public void Move(Vector2 newPosition)
        {
            goToThisNewPosition = newPosition;
        }

        public void Movement()
        {
            Vector2 tmpDirection = new Vector2(0, 0);

            if (position.X < goToThisNewPosition.X)
            {
                tmpDirection += new Vector2(1, 0);
            }

            if (position.X > goToThisNewPosition.X)
            {
                tmpDirection += new Vector2(-1, 0);
            }

            if (position.Y < goToThisNewPosition.Y)
            {
                tmpDirection += new Vector2(0, 1);
            }

            if (position.Y > goToThisNewPosition.Y)
            {
                tmpDirection += new Vector2(0, -1);
            }

            tmpDirection.Normalize();

            velocity = tmpDirection;
        }



        public override void Update(GameTime update)
        {

            CheckWorker();
            Movement();
            Move(update);
            base.Update(update);
        }

        public override void LoadContent(ContentManager content)
        {
            unactiveWorker = content.Load<Texture2D>($"Sprites/NPC/{workerName}");
            activeWorker = content.Load<Texture2D>($"Sprites/NPC/{workerName}_Outline");

            if (activated)
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
            if (other is Guild)
            {

                Console.WriteLine("I used to be an adventurer like you, but then I took an arrow to the knee");
            }

            if (other is Buildings.Mine)
            {
                if (workerState != workerBehavivor.mining)
                {
                    workerState = workerBehavivor.mining;
                    MiningsWithdraw(10);
                    //Console.WriteLine("Worker State changed to mining");
                }
                //Console.WriteLine("Diglet dig diglet dig, Dugtrio trio trio");
            }

            if (other is Buildings.Farm)
            {
                Console.WriteLine("Farming cabbages");
            }
        }

        //public void miningOperations()
        //{

        //}

        public void MiningsWithdraw(object obj)
        {
            int amount = (int)obj;
            Monitor.Enter(thisLock);

            try
            {
                if (amount < balance)
                {
                    while (currentInventory < maxInventory)
                    {
                        currentInventory += amount;
                        Thread.Sleep(500);
                        if (currentInventory > maxInventory)
                        {
                            currentInventory = maxInventory;
                        }
                    }

                }
                else
                {
                    balance -= amount;
                    Console.WriteLine(balance);
                }
            }
            finally
            {

                Monitor.Exit(thisLock);

            }

        }

        protected void CheckWorker()
        {
            newMS = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(newMS.X, newMS.Y, 1, 1);

            if (mouseRectangle.Intersects(CollisionBox))
            {
                if (sprite != activeWorker)
                {
                    sprite = activeWorker;
                }
            }
            else
            {
                if (sprite != unactiveWorker)
                {
                    sprite = unactiveWorker;
                }
            }
        }
    }

}
