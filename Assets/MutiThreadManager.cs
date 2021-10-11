using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Jobs;


public class MutiThreadManager : MonoBehaviour
{
    public GameObject ourObjectPrefab;
    public int numberOfObject;
    private TransformAccessArray _transformAccessArray;
    private JobHandle _aJobHandle;
    private Transform[] _allTransforms;
    private struct MovePosition :IJobParallelForTransform  
    {
        public void Execute(int index, TransformAccess transform)
        {
          transform.position += 0.01f * Vector3.forward ;
        }
    }
    
    private void Start()
    {
        _allTransforms = new Transform[numberOfObject];
        for (int i = 0; i < numberOfObject; i++)
        {
            Vector3 myPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            GameObject temp =  Instantiate(ourObjectPrefab, myPosition,transform.rotation);
            _allTransforms[i] = temp.transform;
        }
        _transformAccessArray = new TransformAccessArray(_allTransforms);

    }

    private void Update()
    {
        MovePosition moveJob = new MovePosition { };
        _aJobHandle = moveJob.Schedule(_transformAccessArray);
    }

    private void LateUpdate()
    {
        _aJobHandle.Complete();
    }

    private void OnDestroy()
    {
        _transformAccessArray.Dispose();
    }
}
