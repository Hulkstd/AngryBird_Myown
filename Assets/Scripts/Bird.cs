using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Bird Object;
    public Rigidbody2D Rig;
    public Animator Ani;

    public bool IsFlying;
    public bool Delay;
    public bool IsClick;

    protected delegate void AbilityFnc();

    protected AbilityFnc Ability;

    private float Tmp = 180 / Mathf.PI;

    protected virtual void Rotate()
    {
        if( IsFlying ) transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Rig.velocity.y, Rig.velocity.x) * Tmp);
    }

    protected virtual void Update()
    {
        if(IsFlying)
        {
            Rotate();
        }

        if (Input.GetMouseButtonUp(0) && !IsClick && IsFlying && Delay)
        {
            IsClick = true;
            Ability?.Invoke();
            CancelInvoke("CheckClick");
        }
    }

    public void SetFlying()
    {
        IsFlying = true;

        StartCoroutine(Delays());
    }

    IEnumerator Delays() { yield return new WaitForSeconds(0.2f); Delay = true; }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        IsFlying = false;
    }

    protected virtual void Animate()
    {
        /*
         * If you want Animate use this.
         */
    }
}
