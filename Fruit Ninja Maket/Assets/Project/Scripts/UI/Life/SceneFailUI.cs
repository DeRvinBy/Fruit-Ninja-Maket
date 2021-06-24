using Project.Scripts.Animations.Abstract;
using Project.Scripts.Animations.UIAnimations;
using UnityEngine;

namespace Project.Scripts.UI.Life
{
    public class SceneFailUI : MonoBehaviour
    {
        [SerializeField]
        private float destroyDelay = 2f;

        [SerializeField]
        private RectTransformScaleAnimation scaleAnimation = null;

        [SerializeField]
        private FadeCanvasGroupAnimation canvasGroupAnimation = null;

        private void Start()
        {
            scaleAnimation.PlayAnimation();
            canvasGroupAnimation.PlayAnimation();
            Destroy(gameObject, destroyDelay);
        }
    }
}
