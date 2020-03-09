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
        foreach (GameObject cloud in clouds)
        {
            //Debug.Log(hex.GetComponent<BasicHexEngine>().IsAlive());
            Debug.Log(cloud.gameObject.name);
            Cloud cloudObj = cloud.GetComponent<Cloud>();
            GameObject obj = cloudObj.castRay();
            if (obj != null)
            {
                BasicHexEngine hex = obj.GetComponent<BasicHexEngine>();
                if (hex != null)
                {
                    cloudObj.attachedHex = hex;
                    //hex.attachedCloud = cloudObj;
                }
            }
        }
    }

    public override void Execute()
    {
        if (base.IsRun())
        {
            foreach (GameObject cloud in clouds)
            {
                Cloud cloudObj = cloud.GetComponent<Cloud>();
                cloudObj.attachedHex.hexModel.SetState(HexState.Alive);
                cloudObj.attachedHex.hexModel.SetProgressState(ProgressState.Forest);
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
}