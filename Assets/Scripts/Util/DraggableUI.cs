using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class DraggableUI : Draggable {
    protected override void ChangePosition(Vector2 pointerPosition) {
        transform.position = pointerPosition;
    }

    protected override void ResetPosition() {
        transform.position = orgPosition;
    }
}
