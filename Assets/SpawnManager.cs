using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ourObject;
    public int numberOfObjects;
    private void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 myPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            Instantiate(ourObject, myPosition,transform.rotation);
        }
    }


}
