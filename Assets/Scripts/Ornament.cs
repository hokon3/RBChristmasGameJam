using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ornament : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Camera mainCamera;
    public SpriteRenderer spriteRenderer;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.useWorldSpace = true;
        lineRenderer.enabled = false;
        lineRenderer.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, vector2 - (Vector2)transform.position);

        if (Input.GetMouseButton(0) && spriteRenderer.enabled)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, raycastHit2D.point);
            if (raycastHit2D.collider.name != "Colliders")
                raycastHit2D.collider.SendMessage("TakeDamage", damage * Time.deltaTime);
        }
        else
        {
            lineRenderer.enabled = false;
        }

    }

    void activateOrnament(int ornamentId)
    {
        if (name.Contains(ornamentId.ToString()))
        {
            spriteRenderer.enabled = true;
        }
    }
}
