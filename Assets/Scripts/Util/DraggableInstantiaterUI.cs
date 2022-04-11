using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Util;

public class DraggableInstantiaterUI : DraggableUI {
    [SerializeField]
    public GameObject createdObjectPrefab;

    private readonly float DRAG_DISTANCE = 100f;
    private Vector2 dragStartPosition;
    private bool shouldResetPosition;
    private GameObject other;

    private void Update() {
        if (!shouldResetPosition) return;
        transform.position = orgPosition;
        shouldResetPosition = false;
    }

    private void CreateObject() {
        other = Instantiate(createdObjectPrefab);
    }

    public override void OnBeginDrag(PointerEventData eventData) {
        base.OnBeginDrag(eventData);
        dragStartPosition = eventData.position;
    }

    public override void OnDrag(PointerEventData eventData) {
        base.OnEndDrag(eventData);
        transform.position = eventData.position;

        if (Vector2.Distance(eventData.position, dragStartPosition) < DRAG_DISTANCE) return;
        CreateObject();
        ReplaceDraggingTarget(eventData);
    }

    private void ReplaceDraggingTarget(PointerEventData data) {
        shouldResetPosition = true;
        ExecuteEvents.Execute(gameObject, data, ExecuteEvents.endDragHandler);
        data.pointerDrag = other;
        ExecuteEvents.Execute(other, data, ExecuteEvents.beginDragHandler);
    }
}
