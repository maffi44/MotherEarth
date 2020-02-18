using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : EnvController
{
    [SerializeField] GameObject cloudPreb;
    private PlanetController planet;
    [SerializeField] private GameObject[] clouds;
    [SerializeField] GameObject atmosphere;
    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetController>();
        clouds = GameObject.FindGameObjectsWithTag("Cloud");
        //clouds =  atmosphere.GetComponentsInChildren<BasicHexEngine>();
        //foreach( var cloud in clouds)
        //{
        //    cloud.SetTypeCloud();
        //}
    }

    public override void Execute()
    {
        if (base.IsRun())
        {
            foreach (var cloud in clouds)
            {
                cloud.GetComponent<Cloud>().castRay();
            }
        }
    }

    public void SpawnCloud()
    {
        Debug.Log("New cloud");
        GameObject newCloud = Instantiate(cloudPreb, planet.transform.position, Quaternion.identity) as GameObject;
        newCloud.transform.LookAt(planet.transform.position);
    }
}
