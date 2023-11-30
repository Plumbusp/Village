using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Dynamic;
public class Dynamictest : MonoBehaviour
{
    private dynamic _dynamicVariable = 1;

    private void Start()
    {
        Debug.LogError($"{_dynamicVariable.GetType()}  {_dynamicVariable}");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _dynamicVariable = "Hi! I am dynamic variable!";
            Debug.LogError($"{_dynamicVariable.GetType()}  {_dynamicVariable}");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            _dynamicVariable = 2.22222;
            Debug.LogError($"{_dynamicVariable.GetType()}  { _dynamicVariable}");
        }
    }
}
