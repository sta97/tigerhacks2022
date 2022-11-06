using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject movable;
    [SerializeField] private GameObject attackable;
    [SerializeField] public terrain type;
    [SerializeField] private bool isWalkable;
    [SerializeField] private bool isFlyable;
    [SerializeField] public GameObject occupier;
    [SerializeField] private bool occupied;

    Unit unitScript;

    Node nodeScript;

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        nodeScript = this.GetComponent<Node>();
        if (occupier != null)
        {
            paintTiles();
        }
        if(occupier==null && nodeScript.traversed == true)
        {
            
        }
    }

    void paintTiles()
    {
        GameObject unit = occupier.transform.GetChild(0).gameObject;
        unitScript = unit.GetComponent<Unit>();
        print(unitScript.movement);

        exploreNodes(this.GetComponent<Node>(), unitScript.movement+1);
    }

    void exploreNodes(Node node, int movement)
    {
        if (node != null)
        {
            if (movement > 0)
            {
                node.tile.attackable.SetActive(false);
                node.tile.movable.SetActive(true);
                node.traversed = true;
                movement--;
                exploreNodes(node.up, movement);
                exploreNodes(node.left, movement);
                exploreNodes(node.down, movement);
                exploreNodes(node.right, movement);
            }
            if (movement == 0 && node.traversed == false)
            {
                node.tile.attackable.SetActive(true);
            }
        }
    }
}

public enum terrain
{
    Grass = 0,
    Mountain = 1
}