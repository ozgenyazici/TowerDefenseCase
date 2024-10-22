using UnityEngine;
public interface ITurnable
{
    float turnSpeed { get; set; }
    Transform partToRotate { get; set; }
}
