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

    // Start is called before the first frame update
    void Start()
    {
        meteorController = GameObject.FindGameObjectWithTag("MeteorController").GetComponent<MeteorController>();
        meteorController.ControllerStart();
        hexController = GameObject.FindGameObjectWithTag("HexController").GetComponent<HexController>();
        hexController.ControllerStart();
        planetController = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetController>();
        planetController.ControllerStart();
        cloudController = GameObject.FindGameObjectWithTag("CloudController").GetComponent<CloudController>();
        cloudController.ControllerStart();
        hexViewController = GameObject.FindGameObjectWithTag("HexViewController").GetComponent<HexViewController>();
        hexViewController.ControllerStart();
    }

// Update is called once per frame
void Update()
    {
        hexController.Execute();
        meteorController.Execute();
        planetController.Execute();
        cloudController.Execute();
        hexViewController.Execute();
    }
}
