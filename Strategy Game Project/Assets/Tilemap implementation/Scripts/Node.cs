using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] public Tile tile;
    [SerializeField] public Node up;
    [SerializeField] public Node down;
    [SerializeField] public Node left;
    [SerializeField] public Node right;
    [SerializeField] public bool traversed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}