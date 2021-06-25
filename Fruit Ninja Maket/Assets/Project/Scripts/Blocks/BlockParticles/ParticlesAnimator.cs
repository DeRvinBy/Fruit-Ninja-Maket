using UnityEngine;

namespace Project.Scripts.Blocks.BlockParticles
{
    public abstract class ParticlesAnimator : MonoBehaviour
    {
        public abstract void ChangeParticlesColor(Color color);
        public abstract void PlayParticles();
        public abstract void PauseParticles();
        public abstract bool IsParticlesComplete();
    }
}