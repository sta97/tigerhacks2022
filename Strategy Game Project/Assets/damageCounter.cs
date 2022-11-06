using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageCounter : MonoBehaviour
{
    public int pokes = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        pokes += 1;
    }
}
