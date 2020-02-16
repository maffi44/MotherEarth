using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedAreaState : MonoBehaviour
{
    private Material material;
    private float stateOpacity = 1.0f;
    private float stepOpacity = 1.0f;

    private void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }

    public void Change()
    {
        if (stateOpacity <= 0 || stateOpacity >= 1)
        {
            stepOpacity = -stepOpacity;
        }
        stateOpacity += stepOpacity * Time.deltaTime;
        material.color = new Color(
            material.color.r,
            material.color.g,
            material.color.b,
            stateOpacity);
    }
}
