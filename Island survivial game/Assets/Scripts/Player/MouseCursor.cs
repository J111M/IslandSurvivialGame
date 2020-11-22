using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseCursor : MonoBehaviour
{

    private Vector3 mousePosition;

    public float mouseSpeed = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector2(Mathf.RoundToInt(mousePosition.x), Mathf.RoundToInt(mousePosition.y));

    }

}
