﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public MenuView MenuView = null;
    public ClientView ClientView = null;
    public WaiterView WaitView = null;
    public CookView CookView = null;
    public RoomView RoomView = null;
    void Start()
    {
        ApplicationFacade facade=new ApplicationFacade();
        facade.StartUp(this);
    }
}
