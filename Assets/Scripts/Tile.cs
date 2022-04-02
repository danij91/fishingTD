using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField]
    private FisherFactory fisherFactory;
    [SerializeField]
    private Material possible;
    [SerializeField]
    private Material impossible;
    private Material originalMaterial;

    private Renderer renderer;

    private bool isInstalled;

    private void Start() {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (isInstalled) {
            renderer.material = impossible;
        }
        else {
            renderer.material = possible;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (!isInstalled) {
            InstallFisher();
        }

        renderer.material = originalMaterial;
    }

    private void InstallFisher() {
        var newFisher = fisherFactory.CreateFisher();
        newFisher.transform.position = transform.position + Vector3.up ;
        newFisher.StartFishing();
    }
}
