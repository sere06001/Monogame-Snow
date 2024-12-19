using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snow
{
    public class Particle
    {
        private int size;
        private Color color;
        private float minFallSpeed = 60;
        private float maxFallSpeed = 180;
        private float fallSpeed = 0;
        private Vector2 position;
        private Texture2D texture;
        private float time = 0;
        private Vector2 velocity = new Vector2();
        public Vector2 Position{
            get {return position;}
        }
        public Vector2 Velocity{
            set {velocity = value;}
        }

        public Particle(int size, Color color, Vector2 position, Texture2D texture){
            this.size = size;
            this.color = color;
            this.position = position;
            this.texture = texture;
            Random rand = new Random();
            time = (float)rand.NextDouble() * MathF.Tau;

            float fallSpeedDifference = maxFallSpeed-minFallSpeed;
            float sizePercent = (float)size / 20;
            fallSpeed = minFallSpeed + (fallSpeedDifference*sizePercent);
        }

        public void Update(){
            float dt = 1f / 60f; //hur lång tid en frame är, 60fps så 1s/60fps
            time += dt;
            velocity.Y = fallSpeed*dt;
            velocity.X += MathF.Sin(time*2);

            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch){
            Rectangle r = new Rectangle((int)position.X,(int)position.Y,size,size);
            spriteBatch.Draw(texture,r,color);
        }
    }
}