using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();
    private Waypoint[] _waypoints;

    private void Awake()
    {
        LoadAllBlocks();
        GenerateDictionary();
    }

    private void LoadAllBlocks()
    {
        _waypoints = GetComponentsInChildren<Waypoint>();
    }

    private void GenerateDictionary()
    {

        foreach (Waypoint _waypoint in _waypoints)
        {
            Debug.Log("Adding " + _waypoint.GetGridPos());
            _grid.Add(_waypoint.GetGridPos(), _waypoint);
        }
    }

}
