using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public class SunController : BasicController
{
    [SerializeField] private GameObject sun;
    [SerializeField] private float temperature = 1000f;
    private GameObject[] hexes;
    private Vector3 sunDir;

    void Start()
    {
        hexes = GameObject.FindGameObjectsWithTag("Hex");
        sunDir = sun.transform.forward;
    }

    public override void Execute()
    {
        if (this.IsRun())
        {
            foreach (var hex in hexes)
            {
                float temp = Vector3.Dot(hex.transform.up, sunDir) * Time.deltaTime * temperature;
                hex.GetComponent<StandartHexEngine>()
                    .SetSunEffect(temp > 0f ? temp : 0);
            }
        }
    }
}
