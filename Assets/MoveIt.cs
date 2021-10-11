using UnityEngine;

public class MoveIt : MonoBehaviour
{

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
