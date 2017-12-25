using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public float rotationSpeed = 8;
    public Transform cam; 
    private bool _mouseDown = false;

    void Update()
    {
        if (!_mouseDown && Input.GetMouseButtonDown(0))
            _mouseDown = true;
        if (_mouseDown && Input.GetMouseButtonUp(0))
            _mouseDown = false;

        if (_mouseDown)
            RotateObject();
    }

    void RotateObject()
    {
        transform.Rotate(0, -Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }
}
