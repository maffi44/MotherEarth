﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicHexEngine : MonoBehaviour
{
    [SerializeField] protected int neiboursCount = 1;
    [SerializeField] protected float tickProgressDelta;
    [SerializeField] protected float neigborsEffects;
    [SerializeField] public BasicHexModel hexModel;
    [SerializeField] protected List<BasicHexEngine> hexNeibours = new List<BasicHexEngine>();
    [SerializeField] protected RenderState renderState;
    public GameObject deadLand;
    public GameObject desert;
    public GameObject grass;
    public GameObject sbirth;
    public GameObject animal;
    public GameObject sanimal;
    public GameObject tribe;
    public GameObject village;
    public GameObject smallcity;
    public GameObject middlecity;
    public GameObject megapolice;

    [SerializeField] public GameObject tileActive;
    [SerializeField] public GameObject activeContent;

    // Start is called before the first frame update
    void Start()
    {
        //if (this.gameObject.tag == "Cloud")
        //{
        //    hexModel = new BasicHexModel(HexState.Cloud);
        //    this.gameObject.GetComponent()
        //}
        //else
        TDeepChildFinder<Transform, string> finder = new TDeepChildFinder<Transform, string>();
        hexModel = new BasicHexModel(HexState.Dead);
        getNeibours();
        neiboursCount = hexNeibours.Count;
        grass = transform.FindDeepChild("HexTop_River").gameObject;
        desert = transform.FindDeepChild("HexTop_Desert").gameObject;
        int rInt = UnityEngine.Random.Range(0, 2); //for ints
        if (rInt == 0)
            deadLand = transform.FindDeepChild("HexTop_ClayGround").gameObject;
        else
            deadLand = transform.FindDeepChild("HexTop_StoneGround").gameObject;
        sbirth = transform.FindDeepChild("hex_tile_plant1").gameObject;
        animal = transform.FindDeepChild("hex_tile_trees1").gameObject;
        sanimal = transform.FindDeepChild("hex_tile_animals2").gameObject;
        tribe = transform.FindDeepChild("hex_tile_tribe1").gameObject;
        village = transform.FindDeepChild("hex_tile_vilage2").gameObject;
        smallcity = transform.FindDeepChild("hex_tile_Small_town1").gameObject;
        middlecity = transform.FindDeepChild("hex_tile_Middle_town1").gameObject;
        megapolice = transform.FindDeepChild("hex_tile_Megapolis").gameObject;
        grass.SetActive(false);
        desert.SetActive(false);
        deadLand.SetActive(false);

        sbirth.SetActive(false);
        animal.SetActive(false);
        sanimal.SetActive(false);
        tribe.SetActive(false);
        village.SetActive(false);
        smallcity.SetActive(false);
        middlecity.SetActive(false);
        megapolice.SetActive(false);
    }

    private void getNeibours()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 0.5f);
        foreach (var gobject in hitColliders)
        {
            Debug.Log(gobject.gameObject.name);

            BasicHexEngine temp;
            if (temp = gobject.GetComponent<BasicHexEngine>())
            {
                if (temp != this)
                {
                    hexNeibours.Add(temp);
                }
            }
        }
    }

    public void ProgresEffectAddition(float progresEffect)
    {
        neigborsEffects += progresEffect;
    }

    public virtual void RenderUpdate()
    {

    }

    public virtual RenderState GetRenderState()
    {
        return RenderState.Nothing;
    }

    public virtual void Tick()
    {
        //if (this.IsAlive())
        //{
        //    tickProgressDelta = (tickProgressDelta -
        //    (hexModel.GetWaterBalance() * waterKoef
        //    + hexModel.GetTemperatureBalance() * temperatureKoef)
        //    + 0.1f) * Time.deltaTime;
        //    hexModel.MakeProgress(tickProgressDelta + neigborsEffects / neiboursCount);
        //    hexModel.waterBalance -= 0.1f * Time.deltaTime;
        //    hexModel.temperatureBalance -= 0.1f * Time.deltaTime;
        //    tickProgressDelta -= 0.1f * Time.deltaTime;
        //    hexModel.ResetEffects();
        //    if (hexModel.health <= 0)
        //    {
        //        this.Die();
        //    }
        //}
        //return;
    }

};
