using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPig : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Life = 3;
        Ani.SetInteger("Life", Life);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
