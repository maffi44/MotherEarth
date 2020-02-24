using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RenderState
{
    Nothing,
    Bush,
    Trees,
    Animals,
    Tribe,
    Village,
    City,
    MediumCity,
    MegaCity,
    Winner
}

public class HexViewController : BasicController
{
    [SerializeField] private GameObject[] hexes;

    private void Start()
    {
        hexes = GameObject.FindGameObjectsWithTag("Hex");
    }

    public override void Execute()
    {
        if (base.IsRun())
        {
            foreach (var hex in hexes)
            {
                BasicHexEngine temp;
                if (temp = hex.GetComponent<BasicHexEngine>())
                {
                    temp.RenderUpdate();
                }
            }
        }
    }
}
