using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class StartUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        Debug.Log("启动");
        //菜单代理
        MenuProxy menuProxy = new MenuProxy();
        facade.RegisterProxy(menuProxy);

        //客户端代理
        ClientProxy clientProxy = new ClientProxy();
        facade.RegisterProxy(clientProxy);

        //服务员代理
        WaiterProxy waitProxy = new WaiterProxy();
        facade.RegisterProxy(waitProxy);

        //厨师代理
        CookProxy cookProxy = new CookProxy();
        facade.RegisterProxy(cookProxy);

        OrderProxy orderProxy = new OrderProxy();
        facade.RegisterProxy(orderProxy);

        RoomProxy roomProxy = new RoomProxy();
        facade.RegisterProxy(roomProxy);

        MainUI mainUI = notification.Body as MainUI;

        if (null == mainUI)
            throw new Exception("程序启动失败..");
        facade.RegisterMediator(new MenuMediator(mainUI.MenuView));
        facade.RegisterMediator(new ClientMediator(mainUI.ClientView));
        facade.RegisterMediator(new WaiterMediator(mainUI.WaitView));
        facade.RegisterMediator(new CookMediator(mainUI.CookView));
        facade.RegisterMediator(new RoomMediator(mainUI.RoomView));

        facade.RegisterCommand(OrderSystemEvent.GUEST_BE_AWAY, typeof(GuestBeAwayCommed));
        facade.RegisterCommand(OrderSystemEvent.GET_ORDER, typeof(GetAndExitOrderCommed));
        facade.RegisterCommand(OrderSystemEvent.CookCooking, typeof(CookCommend));
        facade.RegisterCommand(OrderSystemEvent.selectWaiter, typeof(WaiterCommend));
        facade.RegisterCommand(OrderSystemEvent.ADD_ROOMGUEST, typeof(RoomsCommand));
        facade.RegisterCommand(OrderSystemEvent.ChangeRoomState, typeof(AwayRoomCommand));
    }
}
