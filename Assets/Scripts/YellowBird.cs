using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * YellowBird : This object will dash to down when player click display.
 * This script rotate the object that this object will move.
 * This script check the click when this is flying.
 */

public class YellowBird : Bird
{
    public GameObject Boom;
    
    // Start is called before the first frame update
    void Start()
    {
        Ability = null;

        Ability += YellowBird_Ability;  
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

    void YellowBird_Ability()
    {
        Debug.Log("YellowBird!!");

        Destroy(Instantiate(Boom, transform.position, new Quaternion()), 0.20f);

        Rig.velocity = new Vector2(2, -1) * 20;
    }

    protected override void Animate()
    {
        Ani.SetBool("IsFlying", IsFlying);
        Ani.SetBool("IsClick", IsClick);
    }
}
