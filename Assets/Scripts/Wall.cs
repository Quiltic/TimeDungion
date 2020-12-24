using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // due to how the grid finds objects and the way the camra detects objects if the wall has a colider then the clicker can select it which is bad since there is a floor peace behind the wall
    void Start() {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    //void Update(){}
}
