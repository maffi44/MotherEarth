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

    public override RenderState GetRenderState()
    {
        switch (this.hexModel.GetProgressState())
        {
            case ProgressState.Nothing:
                return RenderState.Nothing;
            case ProgressState.Bush:
                return RenderState.Bush;
            case ProgressState.Forest:
                return RenderState.Trees;
            case ProgressState.Animals:
            case ProgressState.StableAnimals:
                return RenderState.Animals;
            case ProgressState.Tribe:
                return RenderState.Tribe;
            case ProgressState.City:
                return RenderState.City;
            case ProgressState.MediumCity:
                return RenderState.MediumCity;
            case ProgressState.MegaCity:
                return RenderState.MegaCity;
            case ProgressState.Winner:
                return RenderState.Winner;
            default:
                return RenderState.Nothing;
        }
    }

    public override void RenderUpdate()
    {
        ChangeRender(this.GetRenderState());
        setTile();
    }

    private void ChangeRender(RenderState state)
    {
        if (activeContent)
            activeContent.SetActive(false);
        switch (state)
        {
            case RenderState.Nothing:
                activeContent = null;
                break;
            case RenderState.Bush:
                activeContent = sbirth;
                break;
            case RenderState.Trees:
                activeContent = animal;
                break;
            case RenderState.Animals:
                activeContent = sanimal;
                break;
            case RenderState.Tribe:
                activeContent = tribe;
                break;
            case RenderState.Village:
                activeContent = village;
                break;
            case RenderState.City:
                activeContent = smallcity;
                break;
            case RenderState.MediumCity:
                activeContent = middlecity;
                break;
            case RenderState.MegaCity:
                activeContent = megapolice;
                break;
            case RenderState.Winner:
                break;
        }
        if (activeContent)
            activeContent.SetActive(true);
    }

    private void setTile()
    {
        if (tileActive)
            tileActive.SetActive(false);
        if (hexModel.GetState() == HexState.Dead)
        {
            tileActive = stones;
        }
        else
        {
            tileActive = grass;
        }
        if (tileActive)
            tileActive.SetActive(true);
    }
}
