using UnityEngine;

public class daynight : MonoBehaviour
{
    Vector3 rot = Vector3.zero;
    float degpersec = 3;

    // Update is called once per frame
    void Update()
    {
        rot.x = degpersec * Time.deltaTime;
        transform.Rotate(rot, Space.World);
    }
}
