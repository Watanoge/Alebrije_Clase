using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenEjecucion : MonoBehaviour
{
    //Este script no sirve de nada, es para visualizar el orden en el que Unity ejecuta cositas
    public int _updateCount, _lateCount, _fixedCount;

    void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Update " + _updateCount);
        _updateCount++;
    }

    void LateUpdate()
    {
        Debug.Log("Late " + _lateCount);
        _lateCount++;
    }

    void FixedUpdate()
    {
        Debug.Log("Fixed " + _fixedCount);
        _fixedCount++;
    }
}
