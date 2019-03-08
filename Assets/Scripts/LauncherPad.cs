using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPad : MonoBehaviour
{
    public DropDownValue Dropdown;
    public List<Bird> Birds;

    private Vector3 Offset = new Vector3(-0.15f, 1.0f, 0);
    private delegate int GetMethod();
    public bool IsBirdReady;

    public Bird SummonObj;
    public bool Drag;
    public Vector2 basePos;
    public Vector2 afterPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummonBird(0.0f, 0.0f, Dropdown.GetValue));
    }

    // Update is called once per frame
    void Update()
    {
        if(IsBirdReady)
        {
            Debug.Log("BirdReady");
            if(!Drag && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked");

                Drag = true;

                basePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if(Drag && Input.GetMouseButton(0))
            {
                Debug.Log("Clicking");
                afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 calculatePos = afterPos - basePos;

                SummonObj.transform.position = (Vector2)(transform.position + Offset) + Vector2.ClampMagnitude(calculatePos, 2);

                //SummonObj.transform.position = Vector2.ClampMagnitude(calculatePos, 3);
            }
            else if(Drag && Input.GetMouseButtonUp(0))
            {
                Debug.Log("Mouse Up");


                afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 calculatePos = basePos - afterPos;

                SummonObj.Rig.gravityScale = 1;
                SummonObj.Rig.AddForce(Vector2.ClampMagnitude(calculatePos, 2) * 25, ForceMode2D.Impulse);
                SummonObj.SetFlying();


                IsBirdReady = false;
                Drag = false;
                StartCoroutine(SummonBird(5.0f, 0.0f, Dropdown.GetValue));
            }
        }
    }

    IEnumerator SummonBird(float time, float repeatRete, GetMethod GetValue)
    {
        yield return new WaitForSeconds(time);


        if (!IsBirdReady)
        {
            SummonObj = Instantiate(Birds[GetValue()]);

            SummonObj.transform.position = transform.position + Offset;
            SummonObj.Rig.gravityScale = 0;
            SummonObj.transform.localScale = Vector3.one;

            IsBirdReady = true;
        }
        yield return new WaitForSeconds(repeatRete);
        

        yield return null;
    }
}
