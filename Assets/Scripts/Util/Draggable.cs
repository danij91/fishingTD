using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Util {
    public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
        public UnityEvent onBeginDrag;
        public UnityEvent onEndDrag;

        private Vector3 orgPosition;

        private void Start() {
            orgPosition = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            onBeginDrag.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData) {
            transform.position = orgPosition;
            onEndDrag.Invoke();
        }

        public void OnDrag(PointerEventData eventData) {
            transform.position = eventData.position;
        }
    }
}
