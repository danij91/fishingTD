using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public FisherFactory fisherFactory { get; set; }
    [SerializeField]
    private Material possible;
    [SerializeField]
    private Material impossible;
    private Material originalMaterial;

    private Renderer tileRenderer;

    private bool isInstalled;

    private void Start() {
        tileRenderer = GetComponent<Renderer>();
        originalMaterial = tileRenderer.material;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (isInstalled) {
            tileRenderer.material = impossible;
        }
        else {
            tileRenderer.material = possible;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (!isInstalled) {
            InstallFisher();
        }

        tileRenderer.material = originalMaterial;
    }

    private void InstallFisher() {
        var newFisher = fisherFactory.CreateFisher();
        newFisher.transform.position = transform.position + Vector3.up ;
        newFisher.StartFishing();
        isInstalled = true;
    }
}
