using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.MonoSettings
{
    public class BlockSettingsContainer : MonoBehaviour
    {
        [SerializeField]
        private float velocityOfObjects = 20f;

        public float VelocityOfObjects => velocityOfObjects;
    }
}