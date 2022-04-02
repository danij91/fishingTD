using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherFactory : MonoBehaviour {
    [SerializeField]
    private Fisher fisherPrefab;
    
    public Fisher CreateFisher() {
        return Instantiate(fisherPrefab);
    }
}
