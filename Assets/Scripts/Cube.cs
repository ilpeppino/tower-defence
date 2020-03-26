using UnityEngine;

// Script attached to Path/Cube 

[RequireComponent(typeof(Waypoint))]

public class Cube : MonoBehaviour
{

    private Waypoint _waypoint;
    private Vector2Int _snappedPosition;
    private TextMesh _label;
    

    private void Awake()
    {


        GetComponentReferences();
        DetermineSnappedPosition();
        RenameCube();


    }

    private void GetComponentReferences()
    {

        _waypoint = GetComponent<Waypoint>();
        _label    = GetComponentInChildren<TextMesh>();

    }

    private void DetermineSnappedPosition()
    {
        _snappedPosition = _waypoint.GetGridPos();
    }


    private void RenameCube()
    {

        string _tmpLabel = 

            _snappedPosition.x  + 
            " , " + 
            _snappedPosition.y;

        _label.text = _tmpLabel;
        gameObject.name = _tmpLabel;
    }


}
