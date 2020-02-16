using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLife : MonoBehaviour
{
    private MeteorController meteorController;

    private void Start()
    {
        meteorController = GameObject.FindGameObjectWithTag("MeteorController").GetComponent<MeteorController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hex"))
        {
            meteorController.Collision(gameObject, other.gameObject);
        }
    }
}
