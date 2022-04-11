using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {
    public FisherFactory fisherFactory { get; set; }
    public bool isInstalled { get; set; }

    [SerializeField]
    private Material possible;
    [SerializeField]
    private Material impossible;
    private Material originalMaterial;
    private Renderer tileRenderer;

    private void Start() {
        tileRenderer = GetComponent<Renderer>();
        originalMaterial = tileRenderer.material;
    }

    public void SetMaterialAvailable() {
        tileRenderer.material = possible;
    }

    public void SetMaterialUnavailable() {
        tileRenderer.material = impossible;
    }

    public void SetMaterialOriginal() {
        tileRenderer.material = originalMaterial;
    }
}
