
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomProxy : Proxy
{
    public new const string NAME = "RoomProxy";
    public IList<RoomItem> RoomItems
    {
        get
        {
            return (IList<RoomItem>)base.Data;
        }
    }


    public RoomProxy():base(NAME,new List<RoomItem>())
    {
        AddRoom(new RoomItem(1, 2, 0));
        AddRoom(new RoomItem(2, 4, 0));
        AddRoom(new RoomItem(3, 3, 0));
        AddRoom(new RoomItem(4, 1, 0));
    }

    public void AddRoom(RoomItem roomItem)
    {
        if (RoomItems.Count<5)
        {
            RoomItems.Add(roomItem);
        }
        UpdateRoom(roomItem);
    }

    private void UpdateRoom(RoomItem roomItem)
    {
        for (int i = 0; i < RoomItems.Count; i++)
        {
            if (RoomItems[i].id==roomItem.id)
            {
                RoomItems[i] = roomItem;
                RoomItems[i].type=roomItem.type;
                RoomItems[i].population=roomItem.population;
                SendNotification(OrderSystemEvent.ResfrshRoom, RoomItems[i]);
                return;             
            }
        }
    }
    public void OnClientType(RoomItem roomItem,RoomType roomType)
    {
        roomItem.type = roomType;
        SendNotification(OrderSystemEvent.ResfrshRoom, roomItem);
    }
    public void OnRemRoom(RoomItem roomItem)
    {
        for (int i = 0; i < RoomItems.Count; i++)
        {
            if (RoomItems[i].id==roomItem.id)
            {
                RoomItems[i].type = RoomType.Pay;
                SendNotification(OrderSystemEvent.ResfrshRoom, RoomItems[i].type);
                return;
            }
        }
    }
    public RoomItem OnGetNullRoom() 
    {
        for (int i = 0; i < RoomItems.Count; i++)
        {
            if (RoomItems[i].type==0)
            {
                return RoomItems[i];
            }
        }
        return null;
    }

}
