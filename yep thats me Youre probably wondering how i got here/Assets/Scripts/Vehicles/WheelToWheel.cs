using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelToWheel : MonoBehaviour
{
    public WheelCollider FLW, FRW;
    public WheelCollider RLW, RRW;
    public Transform FLT, FRT;
    public Transform RLT, RRT;
    private void UpdateWheelPoses()
    {
        UpdateWheelPoses(FLW, FLT);
        UpdateWheelPoses(FRW, FRT);
        UpdateWheelPoses(RLW, RLT);
        UpdateWheelPoses(RRW, RRT);
    }
    private void UpdateWheelPoses(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;
        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;
    }
    private void Update()
    {
        UpdateWheelPoses();
    }
}
