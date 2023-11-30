using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IInteractable {
    public void Interact();
}
public class interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) {
                Debug.Log("Name: " + hitInfo.collider.gameObject.name);
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    Debug.Log("Got in second if -> one more to go");
                    interactObj.Interact();
                }
            }
        }
    }
}