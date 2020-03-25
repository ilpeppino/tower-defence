using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private const int CUBESIZE = 10;

    private TextMesh _label;
    

    private void Awake()
    {
        _label = GetComponentInChildren<TextMesh>();

        Vector3 newPosCube = new Vector3(
            Mathf.RoundToInt(transform.position.x / CUBESIZE) * CUBESIZE,
            0f,
            (Mathf.RoundToInt(transform.position.z / CUBESIZE) * CUBESIZE));

        string _tmpLabel = newPosCube.x / CUBESIZE + " , " + newPosCube.z / CUBESIZE;

        _label.text = _tmpLabel;
        gameObject.name = _tmpLabel;

    }

}
