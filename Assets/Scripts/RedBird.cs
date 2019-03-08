using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * RedBird : This is not has a ability.
 * This is a normal bird.
 * So This script just rotate the object that this object will move.
 */

public class RedBird : Bird
{
    // Start is called before the first frame update
    void Start()
    {
        Ability = null;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        /*
         * Other Scripts... ...
         */

        Animate();
    }

    protected override void Animate()
    {
        Ani.SetBool("IsFlying", IsFlying);
    }
}
