using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script attached to Enemy

public class EnemyMovement : MonoBehaviour
{
    private const float TIMEBETWEENMOVES = 4f;
    private PathFinder _pathFinder;
    Waypoint _currentWaypont;
    private List<Waypoint> _waypoints;
    private float _nextMovingTime;

    [SerializeField] public Text elapsedTime;
    [SerializeField] public Text nextTime;

    private int _wpIndex = 0;

    private void Awake()
    {

        _pathFinder = FindObjectOfType<PathFinder>();
        _waypoints = _pathFinder.GetFinalPath();

        _wpIndex = 0;
        _currentWaypont = _waypoints[_wpIndex];

        _nextMovingTime = TIMEBETWEENMOVES;

    }

    private void Update()
    {
        // TODO: To remove
        elapsedTime.text = Time.time.ToString();
        nextTime.text = _nextMovingTime.ToString();
        
        // Has the player reached the waypoint?
        if (transform.position == _currentWaypont.GetWorldPosition())
        {

            // Get the next waypoint and let the player move only when time window is expired
            if (Time.time > _nextMovingTime)
            {
                GetNextWaypoint();
            } 
        } 

        else  { transform.position = Vector3.MoveTowards(transform.position, _currentWaypont.GetWorldPosition(), 0.2f);   }

    }

    private void GetNextWaypoint()
    {
        _wpIndex++;
        try
        {
            _currentWaypont = _waypoints[_wpIndex];
            _currentWaypont.SetWaypointColor(Color.yellow);
            _nextMovingTime += TIMEBETWEENMOVES;
        }
        catch
        {
            Debug.Log("Enemy reached endpoint");
        }
    }
}


/*public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private List<Waypoint> _path;
   
    [SerializeField] private Waypoint nextCube;
    [SerializeField] private Waypoint currentCube;
    [SerializeField] private Vector3 cubeDistance;


    private int cubeCounter = 0;


    private void Start()
    {

        currentCube = _path[cubeCounter];
        nextCube = _path[cubeCounter + 1];
        cubeDistance = nextCube.transform.position - currentCube.transform.position;


    }

    void Update()
    {
        //_path = GetComponentsInChildren<Cube>().Cast<Cube>().ToList();

        if (nextCube != null)
        {
            if (cubeDistance != Vector3.zero)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextCube.transform.position, 0.5f);
                cubeDistance = nextCube.transform.position - transform.position;

            }
            else
            {
                
                currentCube = nextCube;
                nextCube = _path[cubeCounter + 1];              
                cubeDistance = nextCube.transform.position - currentCube.transform.position;
                cubeCounter++;
            }
        }

    }

}
*/