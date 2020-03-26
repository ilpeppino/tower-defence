using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Script attached to Path

public class CubesHandler : MonoBehaviour
{

    [SerializeField] private List<Cube> _cubes;

    private void Awake()
    {
        _cubes = GetComponentsInChildren<Cube>().Cast<Cube>().ToList();
    }

}
