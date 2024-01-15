using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePointsTrigger : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        CheckOverlap();
    }

    private void CheckOverlap()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask, QueryTriggerInteraction.Collide);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Batman"))
            {
                Transform childWithMesh = hitCollider.transform.GetChild(0);
                Transform childWithCanvas = hitCollider.transform.GetChild(1);

                if (childWithMesh != null)
                {
                    MeshRenderer meshRenderer = childWithMesh.GetComponent<MeshRenderer>();

                    if (meshRenderer != null && !meshRenderer.enabled)
                    {
                        meshRenderer.enabled = true;
                    }
                }

                if (childWithCanvas != null)
                {
                    Canvas canvas = childWithCanvas.GetComponent<Canvas>();

                    if (canvas != null && !canvas.enabled)
                    {
                        canvas.enabled = true;
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}