using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    private const int CUBESIZE = 10;

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / CUBESIZE ),
            Mathf.RoundToInt(transform.position.z / CUBESIZE ));
    }




}
