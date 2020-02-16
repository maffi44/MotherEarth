using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorData : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject prefab;
    private Vector3 directionMove;
    private Vector3 rotateMove;
    private GameObject meteor;
    private GameObject affectedArea;

    private void Start()
    {
        meteor = transform.Find("Meteor").gameObject;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        transform.RotateAround(Vector3.zero, mainCamera.transform.right, Random.Range(10.0f, 90.0f));
        transform.RotateAround(Vector3.zero, mainCamera.transform.forward, Random.Range(0.0f, 360.0f));
        prefab = gameObject;
        directionMove = Vector3.Normalize(Vector3.zero - transform.position);
        rotateMove = Random.insideUnitSphere;
    }

    public void GetAffectedArea(GameObject affected)
    {
        affectedArea = affected;
    }

    public GameObject CreateAffectedArea(GameObject affected)
    {
        return Instantiate(
                affected,
                Vector3.Normalize(transform.position) * 5,
                transform.rotation);
    }

    public GameObject create()
    { }

    public GameObject SetAffectedArea()
    {
        return affectedArea;
    }

    public GameObject SetPrefab()
    {
        return prefab;
    }

    public GameObject SetMeteor()
    {
        return meteor;
    }

    public void GetDirectionMove(Vector3 direction)
    {
        directionMove = direction;
    }
    public Vector3 SetDirectionMove()
    {
        return directionMove;
    }

    public void GetRotateMove(Vector3 rotate)
    {
        rotateMove = rotate;
    }
    public Vector3 SetRotateMove()
    {
        return rotateMove;
    }
}
