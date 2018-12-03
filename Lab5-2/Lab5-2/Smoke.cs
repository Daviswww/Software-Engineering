using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    class Smoke
    {
        public List<Particle> Particles;
        public bool IsParallel;

        public Smoke()
        {
            Particles = new List<Particle>();
            IsParallel = false;
     
        }
        public void FillParticle(int n)
        {
            for(int i = 0; i < n; ++i)
            {
                Particles.Add(Particle.GetNewParticle());
            }
        }
        public void Tick()
        {
            int count = Particles.Count;
            int interval = Particles.Count / 100;

            if (IsParallel)
            {
                Parallel.For(0, 100, (idx) =>
                {
                    int begin = idx * interval, end = (idx + 1) * interval;
                    for (int i = begin; i < end; ++i)
                    {
                        Particles[i].Move(5000);
                    }
                });
            }
            for(int i = 0; i < count; ++i)
            {
                if(!IsParallel)
                {
                    Particles[i].Move(5000);
                }

                if(Particles[i].Life <= 0)
                {
                    Particles[i] = Particle.GetNewParticle();
                }
            }
        }
    }
}
