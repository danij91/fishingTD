using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFlash : MonoBehaviour {
    private List<Material[]> materials = new List<Material[]>();
    private Renderer[] renderers;
    [SerializeField]
    private Material flashMaterial;
    void Start() {
        renderers = GetComponentsInChildren<Renderer>(true);

        foreach (var renderer in renderers) {
            materials.Add(renderer.materials);
        }
    }

    public void Flash() {
        SetFlashedMaterial();
        Invoke("SetOriginalMaterial",0.2f);
    }

    private void SetFlashedMaterial() {
        foreach (var renderer in renderers) {
            var materialLength = renderer.materials.Length;
            Material[] newMaterials = new Material[materialLength];
            
            for(int i=0;i<materialLength;i++) {
                newMaterials[i] = flashMaterial;
            }

            renderer.materials = newMaterials;
        }
    }

    private void SetOriginalMaterial() {
        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].materials = materials[i];

        }
    }
}
 