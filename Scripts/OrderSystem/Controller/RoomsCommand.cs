using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class RoomsCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        RoomItem roomItem=notification.Body as RoomItem;
        if(roomItem == null )
        {
            return;
        }
        RoomProxy roomProxy=facade.RetrieveProxy(RoomProxy.NAME)as RoomProxy;
        switch (notification.Type)
        {
            case "Sleep":
                roomProxy.OnClientType(roomItem, RoomType.Sleep);
                break;
            case "Remove":
                roomProxy.OnClientType(roomItem, RoomType.Pay);
                break;
        }
    }
}
