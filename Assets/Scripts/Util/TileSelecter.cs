using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Util;

public class TileSelecter : Draggable {
    private Tile tile;
    private bool isDragging;

    private void Update() {
        if (!isDragging) return;
        FindTile();
    }

    public override void OnBeginDrag(PointerEventData eventData) {
        isDragging = true;
    }

    public override void OnEndDrag(PointerEventData eventData) {
        base.OnEndDrag(eventData);
        if (!tile) {
            isDragging = false;
            return;
        }

        if (!tile.isInstalled) {
            transform.GetComponent<Fisher>().StartFishing();
            tile.isInstalled = true;
        }
        else {
            gameObject.SetActive(false);
        }

        tile.SetMaterialOriginal();
        isDragging = false;
    }

    protected override void ChangePosition(Vector2 pointerPosition) { }

    protected override void ResetPosition() {
        transform.position = orgPosition;
    }

    private void FindTile() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("Tile");
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            var newTile = hit.collider.GetComponent<Tile>();
            if (tile != newTile) {
                if (tile) {
                    tile.SetMaterialOriginal();
                }

                tile = newTile;
            }

            if (tile) {
                if (tile.isInstalled) {
                    tile.SetMaterialUnavailable();
                }
                else {
                    tile.SetMaterialAvailable();
                }

                transform.position = tile.transform.position + Vector3.up;
            }
        }
    }
}
