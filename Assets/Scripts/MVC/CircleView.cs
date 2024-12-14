using DG.Tweening;
using UnityEngine;

namespace ColorsPlay.Core
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CircleView : MonoBehaviour
    {
        public Color Color => spriteRenderer.color;
        
        private Tweener scaleTweener;
        private Tweener positionTweener;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void Reset()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        public void ShowErrorEffect()
        {
            spriteRenderer.color = Color.red;
            
            if (scaleTweener is not { active: true })
            {
                scaleTweener = this.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f);
            }
            
            if (positionTweener is not { active: true })
            {
                positionTweener = this.transform.DOPunchPosition(Vector3.right * 0.2f, 0.5f);
            }
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}