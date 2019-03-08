using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BlueBird : This object will split when player click display.
 * This script rotate the object that this object will move.
 * This script check the click when this is flying.
 */

public class BlueBird : Bird
{
    Vector2[] Offset;

    public GameObject Boom;

    // Start is called before the first frame update
    void Start()
    {
        Ability = null;

        Ability += BlueBird_Ability;

        Offset = new Vector2[3];

        Offset[0] = new Vector2(1, 1);
        Offset[1] = new Vector2(1, 0);
        Offset[2] = new Vector2(1, -1);
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

    void BlueBird_Ability()
    {
        Vector2 a = transform.position;

        Debug.Log("BlueBird!!");

        foreach (Vector2 vec in Offset)
        {
            Bird obj = Instantiate<Bird>(Object);

            obj.transform.position = a + vec;

            obj.Rig.velocity = new Vector2(2, -1) * 10;

            obj.IsClick = true;
        }

        Destroy(Instantiate(Boom, transform.position, new Quaternion()), 0.20f);

        gameObject.SetActive(false);
    }

    protected override void Animate()
    {
        Ani.SetBool("IsFlying", IsFlying);
        Ani.SetBool("IsClick", IsClick);
    }
}
