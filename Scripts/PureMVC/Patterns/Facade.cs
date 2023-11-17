﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Facade : IFacade
{
    protected IController m_controller;
    protected static volatile IFacade m_instance;
    protected IModel m_model;
    protected static readonly object m_staticSyncRoot = new object();
    protected IView m_view;
    protected Facade()
    {
        this.InitalizeFacade();
    }

    protected virtual void InitalizeFacade()
    {
        this.InitializeModel();
        this.InitializeController();
        this.InitializeView();
    }

    protected virtual void InitializeView()
    {
        if (this.m_view==null)
        {
            this.m_view = View.Instance;
        }
    }

    protected virtual void InitializeController()
    {
        if (this.m_controller==null)
        {
            this.m_controller = Controller.Instance;
        }
    }

    protected virtual void InitializeModel()
    {
        if (this.m_model==null)
        {
            this.m_model = Model.Instance;
        }
    }
    

    public bool HasCommand(string notificationName)
    {
        return this.m_controller.HasCommand(notificationName);  
    }

    public bool HasMediator(string mediatorName)
    {
       return this.m_view.HasMediator(mediatorName);
    }

    public bool HasProxy(string proxyName)
    {
        return this.m_model.HasProxy(proxyName);
    }

    public void NotifyObservers(INotification note)
    {
        this.m_view.NotifyObservers(note);
    }

    public void RegisterCommand(string notificationName, Type commandType)
    {
       this.m_controller.RegisterCommand(notificationName, commandType);
    }

    public void RegisterMediator(IMediator meditor)
    {
        this.m_view.RegisterMediator(meditor);
    }

    public void RegisterProxy(IProxy proxy)
    {
        this.m_model.RegisterProxy(proxy);
    }

    public void RemoveCommand(string notificationName)
    {
       this.m_controller.RemoveCommand(notificationName) ;
    }

    public IMediator RemoveMediator(string mediatorName)
    {
      return this.m_view.RemoveMediator(mediatorName) ;
    }

    public IProxy RemoveProxy(string proxyName)
    {
        return this.m_model.RemoveProxy(proxyName) ;
    }

    public IMediator RetrieveMediator(string mediatorName)
    {
        return this.m_view.RetrieveMediator(mediatorName) ;
    }

    public IProxy RetrieveProxy(string proxyName)
    {
       return this.m_model.RetrieveProxy(proxyName);
    }

    public void SendNotification(string notificationName)
    {
        this.NotifyObservers(new Notification(notificationName));
    }

    public void SendNotification(string notificationName, object body)
    {
        this.NotifyObservers(new Notification(notificationName,body));
    }

    public void SendNotification(string notificationName, object body, string type)
    {
        this.NotifyObservers(new Notification(notificationName, body,type));
    }



    public static IFacade Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance == null)
                    {
                        m_instance = new Facade();
                    }
                }
            }
            return m_instance;
        }
    }
}
