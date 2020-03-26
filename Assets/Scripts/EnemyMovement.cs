using System.Collections.Generic;
using UnityEngine;


// Script attached to Enemy

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private List<Cube> _path;
   
    [SerializeField] private Cube nextCube;
    [SerializeField] private Cube currentCube;
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
