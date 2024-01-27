using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippyController : MonoBehaviour
{
    public GameObject magicCarpet; // Reference to the magic carpet GameObject
    public float playerHeightOffset = 5.0f; // Adjust this value to control the vertical offset

    void Update()
    {
        if (magicCarpet != null)
        {
            // Match the position and orientation of the magic carpet
            transform.position = magicCarpet.transform.position + Vector3.up * playerHeightOffset;
            transform.rotation = magicCarpet.transform.rotation;
        }
    }
}
