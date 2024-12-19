using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snow
{
    public class ParticleSystem
    {
        List<Particle> particles = new List<Particle>();
        Texture2D texture;
        Random random = new Random();
        float windPower = 100;
        public ParticleSystem(Texture2D texture){
            this.texture = texture;
        }

        private void SpawnParticle(){
            if(random.Next(1,101) < 50){
                particles.Add(CreateParticle());
            }
        }
 
        private Particle CreateParticle(){
            int size = random.Next(1,20);
            float x = random.Next(-400,700);
            Vector2 position = new Vector2(x,-20);

            return new Particle(size,Color.GhostWhite,
            position,texture);
        }

        private void RemoveParticles(){
            for(int i = 0; i<particles.Count; i++)
            {
                if (particles[i].Position.Y > 500)
                {
                    particles.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Update(){
            foreach(Particle particle in particles){
                particle.Velocity = new Vector2(windPower*(1f/60f), 0);
                particle.Update();
            }
            SpawnParticle();
            RemoveParticles();
        }

        public void Draw(SpriteBatch spriteBatch){
            foreach(Particle particle in particles){
                particle.Draw(spriteBatch);
            }
        }
    }
}