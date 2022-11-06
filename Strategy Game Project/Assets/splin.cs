using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var r = transform.localEulerAngles;
        r.y += 0.4f;
        transform.localEulerAngles = r;
    }
}
