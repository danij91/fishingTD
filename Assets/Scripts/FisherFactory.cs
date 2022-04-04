using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherFactory : MonoBehaviour {
    public Fisher fisherPrefab { get; set; }
    
    public Fisher CreateFisher() {
        return Instantiate(fisherPrefab);
    }
}
