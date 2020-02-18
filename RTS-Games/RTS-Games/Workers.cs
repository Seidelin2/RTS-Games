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
        string workerName;
        Rectangle workerRectangle;


        bool isHovered = false;
        bool isClicked = false;


        public Workers(string worker, Vector2 position, float layer)
        {
            workerName = worker;
            this.position = position;
            layerDepth = layer;
        }

        public void MovementMethod() //Placeholder name. (because i done goofed)
        {
            

        }


        public override void Update(GameTime update)
        {
            MovementMethod();

            base.Update(update);
        }
        public override void LoadContent(ContentManager content)
        {
            layerDepth = 0.12f;

            sprite = content.Load<Texture2D>($"Sprites/NPC/{workerName}");

            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

        }

        public override void OnCollision(GameObject other)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //workerRectangle = new Rectangle(base.sprite.Width, base.sprite.Height);

            spriteBatch.Draw(sprite, position, null , Color.White, 0, origin, size, spriteEffect, layerDepth);

        }
    }
    
}
