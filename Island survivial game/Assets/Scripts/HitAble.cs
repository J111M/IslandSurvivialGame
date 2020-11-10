using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAble : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 4;
    [SerializeField] float spread = 1f;

    public float object_Health;

    void Start()
    {
        dropCount = Random.Range(3, 6);
        object_Health = 100;
    }

    void Update()
    {
        if(object_Health <= 0)
        {
            while (dropCount > 0)
            {
                dropCount -= 1;

                Vector3 position = transform.position;
                position.x += spread * UnityEngine.Random.value - spread / 2;
                position.y += spread * UnityEngine.Random.value - spread / 2;

                GameObject go = Instantiate(pickUpDrop);
                go.transform.position = position;
            }
            Destroy(gameObject);
        }
    }

    public override void Hit()
    {
        object_Health -= 20;
    }
 
}
