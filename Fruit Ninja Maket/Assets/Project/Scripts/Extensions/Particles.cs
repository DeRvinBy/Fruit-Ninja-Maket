using UnityEngine;

namespace Project.Scripts.Extensions
{
    public static class Particles
    {
        public static void SetParticlesColor(this ParticleSystem particles, Color color)
        {
            var particleSettings = particles.main;
            particleSettings.startColor = color;
        }
    }
}