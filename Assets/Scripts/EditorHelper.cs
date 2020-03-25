using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class EditorHelper : MonoBehaviour
{

    [SerializeField] private Cube[] _list;

    private void Awake()
    {
        _list = GetComponentsInChildren<Cube>();
    }

    private void Update()
    {
        for (int i = 0; i < _list.Length; i++)
        {
            Debug.Log(_list[i].name);
        }
    }
}
