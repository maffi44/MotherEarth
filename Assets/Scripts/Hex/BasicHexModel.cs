using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stages of hex progress
public enum ProgressState
{
    Nothing = 0,
    Bush = 32,
    Forest = 128,
    Animals = 512,
    StableAnimals = 1024,
    Tribe = 2048,
    Village = 4096,
    City = 8192,
    MediumCity = 16384,
    MegaCity = 32768,
    Winner = 65536
};

// Dead or Alive hex state
public enum HexState
{
    Dead,
    Alive,
    Cloud,
    Water
};


[System.Serializable]
public class BasicHexModel
{
    [SerializeField] public float temperatureBalance;
    [SerializeField] public float waterBalance;
    [SerializeField] public float progressPoints;
    [SerializeField] public float health;
    public float deltaTemperature;
    public float deltaWater;

    [SerializeField] private ProgressState hexProgressState;

    [SerializeField] private HexState state;

    public BasicHexModel(HexState awakeState)
    {
        temperatureBalance = 0;
        waterBalance = 0;
        deltaTemperature = 0;
        deltaWater = 0;
        progressPoints = 0;
        state = awakeState;
        health = 100;
        hexProgressState = ProgressState.Nothing;
    }

    // Getter to know hex state (Dead or Alive)
    public HexState GetState()
    {
        return state;
    }

    // Setter to change state (Dead or Alive)
    public void SetState(HexState newState)
    {
        state = newState;
    }
    // Add to progressPoints value
    public void MakeProgress(float progresRate)
    {
        ProgressState newHexProgressState;

        newHexProgressState = (ProgressState)((int)progressPoints);
        if (newHexProgressState < hexProgressState)
        {
            health += progresRate;
        }
        else
        {
            progressPoints += progresRate;
            hexProgressState = newHexProgressState;
        }
    }

    public float GetWaterBalance()
    {
        waterBalance = waterBalance + deltaWater;
        return System.Math.Abs(waterBalance);
    }

    public float GetTemperatureBalance()
    {
        temperatureBalance = temperatureBalance + deltaTemperature;
        return System.Math.Abs(temperatureBalance);
    }

    public void ResetEffects()
    {
        deltaTemperature = 0;
        deltaWater = 0;
    }

    public void ResetAll()
    {
        temperatureBalance = 0;
        waterBalance = 0;
        deltaTemperature = 0;
        deltaWater = 0;
        progressPoints = 0;
        health = 0;
        state = HexState.Dead;
        hexProgressState = ProgressState.Nothing;
    }

    public ProgressState GetProgressState()
    {
        return this.hexProgressState;
    }

    public void SetProgressState(ProgressState newState)
    {
        this.hexProgressState = newState;
    }
};