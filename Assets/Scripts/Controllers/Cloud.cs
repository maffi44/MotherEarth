﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] int layerMask;

    private void Start()
    {
        if (this.gameObject.CompareTag("Cloud"))
        {
            gameObject.GetComponent<StandartHexEngine>().enabled = !gameObject.GetComponent<StandartHexEngine>().enabled;
        }
        else
        {
            gameObject.GetComponent<Cloud>().enabled = !gameObject.GetComponent<Cloud>().enabled;
        }
    }
    public GameObject castRay()
    {
        int layer = 1 << layerMask;
        RaycastHit hit;
        Debug.DrawRay(this.transform.position, -this.transform.up, Color.red);
        if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, Mathf.Infinity, layer))
        {
            Debug.Log("HIT");
            return (hit.collider.gameObject);
        }
        return null;
    }
}