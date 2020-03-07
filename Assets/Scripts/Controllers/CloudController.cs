using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : EnvController
{
    [SerializeField] GameObject cloudPreb;
    [SerializeField] GameObject[] clouds;

    private PlanetController planet;

    // Start is called before the first frame update
    void Start()
    {
        hexes = GameObject.FindGameObjectsWithTag("Hex");
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetController>();
        clouds = GameObject.FindGameObjectsWithTag("Cloud");
    }

    public override void Execute()
    {
        if (base.IsRun())
        {
            //if (spawn == true)
            //{
            //    this.SpawnCloud();
            //    spawn = false;
            //}

            foreach (GameObject cloud in clouds)
            {
                //Debug.Log(hex.GetComponent<BasicHexEngine>().IsAlive());
                Debug.Log(cloud.gameObject.name);
                GameObject obj = cloud.GetComponent<Cloud>().castRay();
                if (obj != null)
                {
                    Debug.Log(obj.name);
                }

            //cloud.GetComponent<Cloud>().castRay().gameObject.GetComponent<IHexEngine>().Live();
        }
        }
    }

    //public void SpawnCloud()
    //{
    //    Debug.Log("New cloud");
    //    GameObject newCloud = Instantiate(cloudPreb, planet.transform.position - new Vector3(4,4,4), Quaternion.identity) as GameObject;
    //    newCloud.transform.LookAt(planet.transform.position);
    //    clouds.Add(newCloud);
    //}
}
