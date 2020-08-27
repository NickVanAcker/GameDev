using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobPlatformer.Snow
{
        public abstract class Emitter
        {
            private float _generateTimer;

            private float _swayTimer;

            protected Snow _particlePrefab;

            protected List<Snow> _particles;


            public float GenerateSpeed = 0.005f;


            public float GlobalVelocitySpeed = 1;

            public int MaxParticles = 1000;

            public Emitter(Snow particle)
            {
                _particlePrefab = particle;

                _particles = new List<Snow>();
            }

            public void Update(GameTime gameTime)
            {
                _generateTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                _swayTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                AddParticle();

                if (_swayTimer > GlobalVelocitySpeed)
                {
                    _swayTimer = 0;

                    ApplyGlobalVelocity();
                }

                foreach (var particle in _particles)
                    particle.Update(gameTime);

                RemovedFinishedParticles();
            }

            private void AddParticle()
            {
                if (_generateTimer > GenerateSpeed)
                {
                    _generateTimer = 0;

                    if (_particles.Count < MaxParticles)
                    {
                        _particles.Add(GenerateParticle());
                    }
                }
            }

            protected abstract void ApplyGlobalVelocity();

            private void RemovedFinishedParticles()
            {
                for (int i = 0; i < _particles.Count; i++)
                {
                    if (_particles[i].IsRemoved)
                    {
                        _particles.RemoveAt(i);
                        i--;
                    }
                }
            }

            protected abstract Snow GenerateParticle();

            public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                foreach (var particle in _particles)
                    particle.Draw(gameTime, spriteBatch);
            }
        }
    }
