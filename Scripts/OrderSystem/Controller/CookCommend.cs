using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCommend : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        CookProxy cookProxy=facade.RetrieveProxy(CookProxy.NAME) as CookProxy;//厨师的代理
        Order order=notification.Body as Order;
        cookProxy.CookCooking(order);
    }
}
