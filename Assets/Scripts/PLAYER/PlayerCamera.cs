using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float senseX;
    public float senseY;

    public Transform orientation;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // MOUSE INPUTS
        float mouseX = Input.GetAxisRaw("Mouse X") * senseX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * senseY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        // ROTATE CAMERA AND IT ORIENTAION
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
