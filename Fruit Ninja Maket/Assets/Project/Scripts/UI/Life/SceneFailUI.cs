using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.Life
{
    public class SceneFailUI : MonoBehaviour
    {
        [SerializeField]
        private float destroyDelay = 2f;

        [SerializeField]
        private UIRectTransformAnimation scaleAnimation = null;

        [SerializeField]
        private UICanvasGroupAnimation canvasGroupAnimation = null;

        private void Start()
        {
            scaleAnimation.PlayAnimation();
            canvasGroupAnimation.PlayAnimation();
            Destroy(gameObject, destroyDelay);
        }
    }
}
