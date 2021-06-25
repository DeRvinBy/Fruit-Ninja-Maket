using Project.Scripts.Extensions;
using UnityEngine;

namespace Project.Scripts.Blocks.BlockParticles
{
    public class FruitParticlesAnimator : ParticlesAnimator
    {
        [SerializeField]
        private ParticleSystem sprayParticles = null;
        
        [SerializeField]
        private ParticleSystem blotsParticles = null;
        
        public override void ChangeParticlesColor(Color color)
        {
            sprayParticles.SetParticlesColor(color);
            blotsParticles.SetParticlesColor(color);
        }

        public override void PlayParticles()
        {
            sprayParticles.Play();
            blotsParticles.Play();
        }

        public override void PauseParticles()
        {
            sprayParticles.Pause();
            blotsParticles.Pause();
        }

        public override bool IsParticlesComplete()
        {
            return !sprayParticles.isPlaying && !blotsParticles.isPlaying;
        }
    }
}