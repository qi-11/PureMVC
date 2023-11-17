﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : Notifier, IMediator
{
    protected string m_mediatorName;
    protected object m_viewComponent;
    public const string NAME = "Mediator";
    public Mediator() : this("Mediator", null)
    {

    }
    public Mediator(string mediatorName) : this(mediatorName, null)
    {

    }
    public Mediator(string mediatorName,object viewComponent)
    {
        this.m_mediatorName = (mediatorName!=null)?mediatorName: "Mediator";
        this.m_viewComponent = viewComponent;
    }

    public virtual string MeditorName
    {
        get
        {
            return this.m_mediatorName;
        }
    }

    public object ViewComponent
    {
        get
        {
            return this.m_viewComponent;
        }
        set { this.m_viewComponent = value;}
    }
    /// <summary>
    /// 执行通知事件
    /// </summary>
    /// <param name="notification"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public virtual void HandleNotification(INotification notification)
    {
        
    }

    public virtual IList<string> ListNotificationInterests()
    {
        return new List<string>();
    }

    public virtual void OnRegister()
    {
        
    }

    public virtual void OnRemove()
    {
        
    }

 
}
