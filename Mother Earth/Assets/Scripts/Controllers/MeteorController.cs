using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : BasicController
{
    public GameObject Meteor;
    public GameObject Explosion;
    public float MinDelaySpawn = 1.0f;
    public float MaxDelaySpawn = 2.0f;
    public float SpeedMove = 1.0f;
    public float SpeedRotate = 100.0f;
    private GameObject mainCamera;
    private float nextSpawn;
    private GameObject[] hexes;
    public List<MeteorData> meteors;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        meteors = new List<MeteorData>();
        hexes = GameObject.FindGameObjectsWithTag("Hex");
        nextSpawn = Random.Range(MinDelaySpawn, MaxDelaySpawn);
    }

    public override void Execute()
    {
        if (base.IsRun())
        {
            Debug.Log("METOR CONTROLLER EXECUTE");
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
    }

    public void Collision(GameObject meteor, GameObject Hex)
    {
        //Hex.GetComponent<name>().name;
        Instantiate(Explosion, meteor.transform.position, Quaternion.identity);
        meteors.Remove(meteor.GetComponent<MeteorData>());
        Destroy(meteor);
    }
}
