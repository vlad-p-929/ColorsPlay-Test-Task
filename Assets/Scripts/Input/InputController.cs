using System;
using UnityEngine;
using static UnityEngine.Input;

namespace ColorsPlay.Input
{
    public class InputController<T> where T : UnityEngine.Object
    {
        public event Action<T> OnClick;
        
        private Camera Camera => Camera.main;

        public void HandleMouseClick()
        {
            Vector2 worldPoint = Camera.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                var clickedObject = hit.collider.gameObject;

                if (clickedObject.TryGetComponent(out T foundObject))
                {
                    OnClick?.Invoke(foundObject);
                }
            }
        }
    }
}