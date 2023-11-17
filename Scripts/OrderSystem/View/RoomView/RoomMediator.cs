
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMediator : Mediator
{
    private RoomProxy roomProxy = null;
    public new const string NAME = "RoomMeditor";
    private RoomView View
    {
        get
        {
            return (RoomView)ViewComponent;
        }
    }
    public RoomMediator(RoomView view) : base(NAME, view)
    {
        //放送消息 给
        view.CallWaiter += data => { SendNotification(OrderSystemEvent.RoomSleep, data); };
    }
    public override void OnRegister()
    {
        base.OnRegister();
        roomProxy = facade.RetrieveProxy(RoomProxy.NAME) as RoomProxy;
        if (null == roomProxy)
            throw new Exception("获取" + RoomProxy.NAME + "代理失败");
        IList<Action<object>> actionList = new List<Action<object>>()
            {
                item =>  SendNotification(OrderSystemEvent.ChangeRoomState, item, "Add"),
                item =>  SendNotification(OrderSystemEvent.RoomPay, item),
            };
        View.UpdateClient(roomProxy.RoomItems, actionList);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.RoomSleep);
        notifications.Add(OrderSystemEvent.ResfrshRoom);
        notifications.Add(OrderSystemEvent.RoomPay);
        return notifications;
    }
    public override void HandleNotification(INotification notification)
    {
        Debug.Log(notification.Name);
        switch (notification.Name)
        {
            case OrderSystemEvent.RoomSleep:
                RoomItem room = notification.Body as RoomItem;
                SendNotification(OrderSystemEvent.ADD_ROOMGUEST, room, "Sleep");
                break;
            case OrderSystemEvent.ORDER:
                Order order1 = notification.Body as Order;
                if (null == order1)
                    throw new Exception("order1 is null ,please check it!");
                SendNotification(OrderSystemEvent.ChangeClientState, order1, "WaitFood");
                break;
            case OrderSystemEvent.PAY:
                break;
            case OrderSystemEvent.ResfrshRoom:
                Debug.Log("刷新界面");
                RoomItem roomItem = notification.Body as RoomItem;
                if (null == roomProxy)
                    throw new Exception("获取" + ClientProxy.NAME + "代理失败");
                View.UpdateState(roomItem);
                break;
            case OrderSystemEvent.RoomPay:
                Debug.Log(" 服务员拿到顾客的付款 ");
                RoomItem item = notification.Body as RoomItem;
                if (item != null)
                    SendNotification(OrderSystemEvent.ADD_ROOMGUEST, item, "Remove");
                break;
        }
    }
}
