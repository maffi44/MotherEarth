using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartHexEngine : BasicHexEngine, IHexEngine
{
    [SerializeField] const float waterKoef = 0.5f;
    [SerializeField] const float temperatureKoef = 0.5f;


    // Process Hex on Frame
    public void Tick()
    {
        if (this.IsAlive())
        {
            tickProgressDelta = (tickProgressDelta -
            (hexModel.GetWaterBalance() * waterKoef
            + hexModel.GetTemperatureBalance() * temperatureKoef)
            + 0.1f) * Time.deltaTime;
            hexModel.MakeProgress(tickProgressDelta + neigborsEffects / neiboursCount);
            hexModel.waterBalance -= 0.1f * Time.deltaTime;
            hexModel.temperatureBalance -= 0.1f * Time.deltaTime;
            tickProgressDelta -= 0.1f * Time.deltaTime;
            hexModel.ResetEffects();
            if (hexModel.health <= 0)
            {
                this.Die();
            }
        }
        return;
    }


    // Make dead a hex block
    public void Die()
    {
        hexModel.SetState(HexState.Dead);
        hexModel.ResetAll();
    }

    // Make alive a hex block
    public void Live()
    {
        hexModel.health = 100;
        hexModel.SetState(HexState.Alive);
    }

    // Is Hex is alive
    public bool IsAlive()
    {
        return hexModel.GetState() == HexState.Alive;
    }

    // Set Sun Effect
    public void SetSunEffect(float sunEffect)
    {
        hexModel.deltaTemperature = sunEffect;
    }

    // Set Water Effect
    public void SetWaterEffect(float waterEffect)
    {
        hexModel.deltaWater = waterEffect;
    }

    // Set Type to Cloud
    public void SetTypeCloud()
    {
        hexModel.SetState(HexState.Cloud);
    }

}
