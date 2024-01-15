using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePointsTrigger : MonoBehaviour
{ 
    [SerializeField]
    private float detectionRadius = 10f;
    public GameObject teleportMarker;
    public float teleportMargin = 1.0f;
    public LayerMask layerMask;

    private void Update()
    {
        CheckClosestGround();
    }

    void CheckClosestGround()
    {
        float closestDistance = float.MaxValue;
        Transform newClosestGround = null;

        var colliders = Physics.OverlapSphere(transform.position, detectionRadius, layerMask);
        foreach (var collider in colliders)
        {
            float colliderDistance = Vector3.Distance(collider.transform.position, transform.position);
            if (closestDistance > colliderDistance)
            {
                closestDistance = colliderDistance;
                newClosestGround = collider.gameObject.transform;
            }
        }

    
        if (newClosestGround != null)
        {
            MeshRenderer meshRenderer = newClosestGround.GetComponentInChildren<MeshRenderer>();
            Canvas canvas = newClosestGround.GetComponentInChildren<Canvas>();

            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }

            if (canvas != null)
            {
                canvas.enabled = true;
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}