using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Util {
    public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
        public UnityEvent onBeginDrag;
        public UnityEvent onEndDrag;

        [SerializeField]
        protected bool shouldReset;
        protected Vector3 orgPosition;

        public virtual void Start() {
            orgPosition = transform.position;
        }

        public virtual void OnBeginDrag(PointerEventData eventData) {
            onBeginDrag?.Invoke();
        }

        public virtual void OnEndDrag(PointerEventData eventData) {
            if (shouldReset) {
                ResetPosition();
            }

            onEndDrag?.Invoke();
        }

        public virtual void OnDrag(PointerEventData eventData) {
            ChangePosition(eventData.position);
        }

        protected virtual void ChangePosition(Vector2 pointerPosition) { }

        protected virtual void ResetPosition() { }
    }
}
