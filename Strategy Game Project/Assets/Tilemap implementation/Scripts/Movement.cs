using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Unit unit;
    int movement;
    [SerializeField] bool moving = false;

    void Start()
    {
        movement = unit.movement;
        print(movement);
    }
}
