using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThrowed : MonoBehaviour
{

    public bool IsObjectThrowed;

    private void OnCollisionEnter(Collision collision)
    {
        IsObjectThrowed = false;
    }
}
