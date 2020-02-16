using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMeteor : BasicController
{
    public GameObject Meteor;
    public GameObject Explosion;
    public GameObject AffectedArea;
    public float MinDelaySpawn = 1.0f;
    public float MaxDelaySpawn = 2.0f;
    public float SpeedMove = 1.0f;
    public float SpeedRotate = 100.0f;
    private GameObject mainCamera;
    private float nextSpawn;
    private GameObject[] hexes;
    private List<MeteorData> meteors;
    private List<GameObject> affectedsArea;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        meteors = new List<MeteorData>();
        affectedsArea = new List<GameObject>();
        hexes = GameObject.FindGameObjectsWithTag("Hex");
        nextSpawn = Random.Range(MinDelaySpawn, MaxDelaySpawn);
    }

    public override void Execute()
    {
        if (base.IsRun())
        {
            if (nextSpawn <= 0.0f)
            {
                meteors.Add(spawn());
                nextSpawn = Random.Range(MinDelaySpawn, MaxDelaySpawn);
            }
            else
            {
                nextSpawn -= Time.deltaTime;
            }
            Invoke("step", 0.1f);
        }
    }

    private MeteorData spawn()
    {
        GameObject prefab;
        MeteorData data;

        prefab = Instantiate(
            Meteor,
            mainCamera.transform.position,
            Quaternion.identity);
        data = prefab.GetComponent<MeteorData>();
        data.GetDirectionMove(data.SetDirectionMove() * SpeedMove);
        data.GetRotateMove(data.SetRotateMove() * Random.Range(1.0f, SpeedRotate));
        affectedsArea.Add(data.CreateAffectedArea(AffectedArea));
        return data;
    }

    private void step()
    {
        foreach (MeteorData data in meteors)
        {
            data.SetPrefab().transform.position += data.SetDirectionMove() * Time.deltaTime * SpeedMove;
            data.SetMeteor().transform.rotation *= Quaternion.Euler(
                data.SetRotateMove().x * Time.deltaTime * SpeedRotate,
                data.SetRotateMove().y * Time.deltaTime * SpeedRotate,
                data.SetRotateMove().z * Time.deltaTime * SpeedRotate);
        }
        foreach (GameObject effect in affectedsArea)
        {
            effect.GetComponent<AffectedAreaState>().Change();
        }
    }

    public void Collision(GameObject meteor, GameObject Hex)
    {
        //Hex.GetComponent<name>().name;
        Instantiate(Explosion, meteor.transform.position, Quaternion.identity);
        Destroy(meteor.GetComponent<MeteorData>().SetAffectedArea());
        meteors.Remove(meteor.GetComponent<MeteorData>());
        Destroy(meteor);
    }
}
