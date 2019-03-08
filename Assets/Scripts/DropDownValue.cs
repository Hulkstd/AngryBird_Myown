using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownValue : MonoBehaviour
{
    public Dropdown dropdown;

    public int GetValue()
    {
        return dropdown.value;
    }

    void Start()
    {
        dropdown.options.Clear();
        SettingDropDownBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SettingDropDownBar()
    {
        Dropdown.OptionData data_1 = new Dropdown.OptionData();
        Dropdown.OptionData data_2 = new Dropdown.OptionData();
        Dropdown.OptionData data_3 = new Dropdown.OptionData();

        data_1.text = "RedBird";
        data_2.text = "YellowBird";
        data_3.text = "BlueBird";

        dropdown.options.Add(data_1);
        dropdown.options.Add(data_2);
        dropdown.options.Add(data_3);
    }
}
