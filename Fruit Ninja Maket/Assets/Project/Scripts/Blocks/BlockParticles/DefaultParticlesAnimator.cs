using Project.Scripts.Extensions;
using UnityEngine;

namespace Project.Scripts.Blocks.BlockParticles
{
    public class DefaultParticlesAnimator : ParticlesAnimator
    {
        [SerializeField] 
        private ParticleSystem particles = null;
        
        public override void ChangeParticlesColor(Color color)
        {
            particles.SetParticlesColor(color);
        }

        public override void PlayParticles()
        {
            particles.Play();
        }

        public override void PauseParticles()
        {
            particles.Pause();
        }

        public override bool IsParticlesComplete()
        {
            return !particles.isPlaying;
        }
    }
}