using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRockInteraction : MonoBehaviour, IInteractable
{
    public GameObject prefab;
    public void Interact() {
        Debug.Log("INTERACTED!!");
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
