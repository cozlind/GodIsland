using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other);
    }
}
