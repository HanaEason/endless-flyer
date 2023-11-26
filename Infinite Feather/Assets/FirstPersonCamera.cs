using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;

    private float _xRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        _xRotation = 0.0f;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.IsPaused)
        {
            return;
        }
        
        // get the mouse input and modify it along with the sensitivity
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
