using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    // Maps each cube (waypoint) in path with its position in the world
    private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();

    // List of waypoints (cubes) defined in Path
    private Waypoint[] _waypoints;

    // Used to explore neighbor waypoints (cubes)
    private Vector2Int[] _compass =  {  Vector2Int.up, 
                                        Vector2Int.right, 
                                        Vector2Int.down, 
                                        Vector2Int.left
                                     };



    [SerializeField] private Waypoint _startCube;
    [SerializeField] private Waypoint _endCube;

    private void Awake()
    {
        LoadAllBlocks();
        GenerateDictionary();
        ColorStartEndBlocks();
        ExploreNeighbors();
    }

    private void LoadAllBlocks()
    {
        _waypoints = GetComponentsInChildren<Waypoint>();
    }

    private void ColorStartEndBlocks()
    {
        _startCube.SetWaypointColor(Color.green);
        _endCube.SetWaypointColor(Color.red);
    }

    private void GenerateDictionary()
    {

        foreach (Waypoint _waypoint in _waypoints)
        {
            //Debug.Log("Adding " + _waypoint.GetGridPos());
            _grid.Add(_waypoint.GetGridPos(), _waypoint);

        }
    }

    private void ExploreNeighbors()
    {

        foreach (Waypoint _waypoint in _waypoints)
        {
            foreach (Vector2Int _direction in _compass)
            {
                print("WAYPONT " + _waypoint);

                Vector2Int neighbor = _waypoint.GetGridPos() + _direction;
                print("Neighbor: " + neighbor);

            } 
            print("------------------------------");
        }



    }


}
