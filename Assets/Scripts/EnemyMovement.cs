using System.Collections.Generic;
using UnityEngine;


// Script attached to Enemy

public class EnemyMovement : MonoBehaviour
{
    private PathFinder _pathFinder;
    Waypoint _currentWaypont;
    private List<Waypoint> _waypoints;

    private int i = 0;

    private void Awake()
    {

        _pathFinder = FindObjectOfType<PathFinder>();
        _waypoints = _pathFinder.GetFinalPath();

        i = 0;
        _currentWaypont = _waypoints[i];

    }

    private void Update()
    {
        
        if (transform.position == _currentWaypont.GetWorldPosition())
        {
            i++;
            try
            {
                _currentWaypont = _waypoints[i];
                _currentWaypont.SetWaypointColor(Color.yellow);
            }
            catch
            {
                Debug.Log("Enemy reached endpoint");
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentWaypont.GetWorldPosition(), 0.1f);

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