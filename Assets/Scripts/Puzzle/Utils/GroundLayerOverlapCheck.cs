using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundLayerOverlapCheck : MonoBehaviour
{
    public List<Teleporter> teleportersToDisable;

    public Transform groundCheckPoint;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isOverGroundLayer;

    private void Update()
    {
        isOverGroundLayer = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        foreach (var teleporter in teleportersToDisable)
        {
            teleporter.disabled = isOverGroundLayer;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }
}