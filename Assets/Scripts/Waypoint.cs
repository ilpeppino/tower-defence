using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] public const int CUBESIZE = 2;

    [SerializeField] public bool isExplored;
    [SerializeField] public Waypoint exploredFrom; 

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / CUBESIZE ),
            Mathf.RoundToInt(transform.position.z / CUBESIZE ));
    }

    public Vector3 GetWorldPosition()
    {
        return transform.position;
    }

    public void SetWaypointColor(Color _color)
    {
        transform.GetComponent<MeshRenderer>().material.color = _color;
    }




}
