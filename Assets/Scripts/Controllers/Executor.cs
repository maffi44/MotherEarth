using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executor : MonoBehaviour
{
    // private BasicController[] controllers;
    private MeteorController meteorController;
    private HexController hexController;
    private PlanetController planetController;
    private CloudController cloudController;
    private HexViewController hexViewController;
    private SunController sunController;

    // Start is called before the first frame update
    void Start()
    {
        if (!(meteorController = GameObject.FindGameObjectWithTag("MeteorController").GetComponent<MeteorController>()))
            meteorController.ControllerStart();
        if (!(hexController = GameObject.FindGameObjectWithTag("HexController").GetComponent<HexController>()))
            hexController.ControllerStart();
        if (!(planetController = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetController>()))
            planetController.ControllerStart();
        if (!(cloudController = GameObject.FindGameObjectWithTag("CloudController").GetComponent<CloudController>()))
            cloudController.ControllerStart();
        if (!(hexViewController = GameObject.FindGameObjectWithTag("HexViewController").GetComponent<HexViewController>()))
           hexViewController.ControllerStart();
        if (!(sunController = GameObject.FindGameObjectWithTag("SunController").GetComponent<SunController>()))
            sunController.ControllerStart();
        Debug.Log(sunController.name);
    }

// Update is called once per frame
void Update()
    {
        if (hexController)
            hexController.Execute();
        if (meteorController)
            meteorController.Execute();
        if (cloudController) 
            cloudController.Execute();
        if (planetController)
            planetController.Execute();
        if (hexController)
            hexViewController.Execute();
        if (sunController)
            sunController.Execute();
    }
}
