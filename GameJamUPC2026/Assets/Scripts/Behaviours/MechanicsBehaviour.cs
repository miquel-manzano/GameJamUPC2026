using System;
using UnityEngine;

[RequireComponent(typeof(DashBehaviour))]

public class MechanicsBehaviour : MonoBehaviour
{
    private DashBehaviour _dashBehaviour;

    private void Awake()
    {
        _dashBehaviour = GetComponent<DashBehaviour>();
    }
}