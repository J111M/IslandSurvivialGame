using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsController : MonoBehaviour
{
    PlayerMovement character;
    Rigidbody2D rb;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.25f;

    private void Awake()
    {
        character = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }

        void UseTool()
        {
            Vector2 postion = rb.position * offsetDistance;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(postion, sizeOfInteractableArea);

            foreach(Collider2D c in colliders)
            {
                ToolHit hit = c.GetComponent<ToolHit>();
                if(hit != null)
                {
                    hit.Hit();
                    break;
                }
            }
        }
    }
}
