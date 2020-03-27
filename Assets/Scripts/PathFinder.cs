using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    // Maps each cube (waypoint) in path with its position in the world
    private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();

    // Collection of all the waypoints (cubes) defined in Path
    private Waypoint[] _waypoints;

    // Used to explore neighbor waypoints (cubes)
    private Vector2Int[] _compass =  {  Vector2Int.up, 
                                        Vector2Int.right, 
                                        Vector2Int.down, 
                                        Vector2Int.left
                                     };

    // Used for path finding algorithm
    private Queue<Waypoint> _queue = new Queue<Waypoint>();

    [SerializeField] private bool _isEndNodeFound;
    [SerializeField] private Waypoint _startWaypoint;
    [SerializeField] private Waypoint _endWaypoint;
    

    private void Awake()
    {
        LoadAllBlocks();
        GenerateDictionary();
        ColorStartEndBlocks();
        FindPath();
    }

    private void LoadAllBlocks()
    {
        _waypoints = GetComponentsInChildren<Waypoint>();
    }

    private void ColorStartEndBlocks()
    {
        _startWaypoint.SetWaypointColor(Color.green);
        _endWaypoint.SetWaypointColor(Color.red);
    }

    private void GenerateDictionary()
    {

        foreach (Waypoint _waypoint in _waypoints)
        {
            //Debug.Log("Adding " + _waypoint.GetGridPos());
            _grid.Add(_waypoint.GetGridPos(), _waypoint);

        }
    }




    private void FindPath()
    {
        // Initializes the pathfinding markers variables
        var _currentWaypoint = _startWaypoint;
        _queue.Enqueue(_startWaypoint);

        // Iterates as long as the queue is not empty or the end node is found
        while(_queue.Count > 0 && !isEndReached(_currentWaypoint))
        {
            // Picks up the first waypoint from the queue
            _currentWaypoint = _queue.Dequeue();
            Debug.Log(_currentWaypoint + " - dequeued");

            // Checks if that waypoint is the end waypoint
            if (!isEndReached(_currentWaypoint))
            {
                // Enqueues all its neighbor waypoints
                ExploreNeighbors(_currentWaypoint);

            }
        }

        Debug.Log(_currentWaypoint + " - node found");



    }

    private void ExploreNeighbors(Waypoint _waypoint)
    {
        // Iterates over the 4 directions (NSWE) and enqueues the waypoints 
        foreach (Vector2Int _direction in _compass)
        {
            var _waypointKey = _waypoint.GetGridPos() + _direction;
            try
            {
                var _waypointValue = _grid[_waypointKey];
                _waypointValue = _grid[_waypointKey];
                _waypointValue.SetWaypointColor(Color.white);
                _queue.Enqueue(_waypointValue);
                Debug.Log(_waypointValue + " - queued");
            }
            
            catch
            {
                Debug.LogWarning(_waypointKey + " - do not exist");
            }
            
            
            
        }

    }

    private bool isEndReached(Waypoint _currentWaypoint)
    {
        return (_currentWaypoint == _endWaypoint);
        
    }


}
