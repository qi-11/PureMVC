﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemView : MonoBehaviour
{
    public MenuItem Menu = null;

    public Toggle toggle = null;
    private void Awake()
    {
        toggle=transform.Find("Toggle").GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(isOn => { Menu.iselected =isOn;});
    }

    public void InitData(MenuItem menu)
    {
        Menu = menu;
        transform.Find("Price").GetComponent<Text>().text = menu.price+"元";
        string menuName=menu.name;
        if (!menu.instock)
            menuName += ("无货");
        toggle.transform.Find("Label").GetComponent<Text>().text = menuName;
        toggle.interactable = menu.instock;
        toggle.isOn = menu.iselected;
    }
}
