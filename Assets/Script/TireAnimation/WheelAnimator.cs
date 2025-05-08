using UnityEngine;
public class WheelAnimator : MonoBehaviour
{
    public WheelCollider wheelCollider;
    public Transform wheelMesh;

    void Update()
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelMesh.position = pos;
        wheelMesh.rotation = rot;
    }
}
