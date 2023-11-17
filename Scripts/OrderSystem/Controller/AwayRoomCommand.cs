using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwayRoomCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        RoomProxy roomProxy = facade.RetrieveProxy(RoomProxy.NAME) as RoomProxy;
        switch (notification.Type)
        {
            case "Add":
                
                RoomItem room=notification.Body as RoomItem;
                room.type = 0;
                room.population=Random.Range(3, 14);
                roomProxy.AddRoom(room);
                break;
        }
    }
}
