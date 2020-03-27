using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    private const int CUBESIZE = 10;

    [SerializeField] public bool isExplored;
    [SerializeField] public Waypoint exploredFrom; 

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / CUBESIZE ),
            Mathf.RoundToInt(transform.position.z / CUBESIZE ));
    }

    public void SetWaypointColor(Color _color)
    {
        transform.GetComponent<MeshRenderer>().material.color = _color;
    }




}
