using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    /*public Transform target;
    public float distance = 100.0f;
    public float height = 100.0f;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public bool followBehind = true;
    public float rotationDamping = 10.0f;

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if ((System.Object)target == null)
            return;

        Vector3 wantedPosition;
        if (followBehind)
            wantedPosition = target.TransformPoint(0, height, -distance) + target.forward * 10 + target.up * 3;
        else
            wantedPosition = target.TransformPoint(0, height, distance) + target.forward * 10 + target.up * 3;

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, new Vector3(0,0,0));
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
            transform.LookAt(target, new Vector3(0, 0, 0));
    }*/
    public Transform target;
    public float distance = 5.0f;
    public float height = 3.0f;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public bool followBehind = true;
    public float rotationDamping = 10.0f;

    void Update()
    {
        Vector3 wantedPosition;
        if (followBehind)
            wantedPosition = target.TransformPoint(0, height, -distance) + target.forward * 10;
        else
            wantedPosition = target.TransformPoint(0, height, distance) + target.forward * 10;
        
        if (wantedPosition.y < 0)
            wantedPosition.y = transform.position.y + 3;
        if (Mathf.Abs(wantedPosition.y - target.position.y) > 20)
            wantedPosition.y = target.position.y + 20;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else transform.LookAt(target, target.up);
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }
}