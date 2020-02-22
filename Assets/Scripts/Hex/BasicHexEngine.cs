using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BasicHexEngine : MonoBehaviour
{
    [SerializeField] protected int neiboursCount = 1;
    [SerializeField] protected float tickProgressDelta;
    [SerializeField] protected float neigborsEffects;
    [SerializeField] public BasicHexModel hexModel;
    [SerializeField] protected List<BasicHexEngine> hexNeibours = new List<BasicHexEngine>();

    // Start is called before the first frame update
    void Start()
    {
        //if (this.gameObject.tag == "Cloud")
        //{
        //    hexModel = new BasicHexModel(HexState.Cloud);
        //    this.gameObject.GetComponent()
        //}
        //else
        hexModel = new BasicHexModel(HexState.Dead);
        getNeibours();
        neiboursCount = hexNeibours.Count;
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
