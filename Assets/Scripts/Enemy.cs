using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Boom;
    public Animator Ani;

    protected float Health = 2.0f;
    protected int Life = 1;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > Health)
        {

            Life--;

            Act();
        }
    }

    protected virtual void Act()
    {
        if(Life == 0)
        {
            Destroy(Instantiate(Boom, transform.position, new Quaternion()), 0.2f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(Instantiate(Boom, transform.position, new Quaternion()), 0.2f);
            Ani.SetInteger("Life", Life);
        }
    }
}
