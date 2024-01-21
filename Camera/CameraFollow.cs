using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float damping;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, damping); 
    }
}
