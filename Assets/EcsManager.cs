using UnityEngine;
using Unity.Entities;
using Unity.Transforms;


public class EcsManager : MonoBehaviour
{
    public GameObject ourObject;
    public int numberOfObjects;
    private EntityManager _entityManager;


    private void Start()
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var newEntityConversion = GameObjectConversionUtility.ConvertGameObjectHierarchy(ourObject, settings);
        for (var i = 0; i < numberOfObjects; i++)
        {
            Entity instance = _entityManager.Instantiate(newEntityConversion);
            Vector3 myPosition = new Vector3(UnityEngine.Random.Range(-100, 100), 0, UnityEngine.Random.Range(-100, 100));
            _entityManager.SetComponentData(instance,new Translation(){Value = myPosition});
            _entityManager.SetComponentData(instance,new Rotation(){Value = transform.rotation});

        }
    }
}
