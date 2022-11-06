using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public int movement;
    [SerializeField] public Vehicle vehicle;
    [SerializeField] public Camera cam;

}

public enum Vehicle
{
    tank = 0,
    helicopter = 1
}