﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientProxy : Proxy
{
    public new const string NAME = "ClientProxy";
    public IList<ClientItem> Clients
    {
        get { return (IList<ClientItem>)base.Data; }
    }

    public ClientProxy() : base(NAME, new List<ClientItem>())
    {
        AddClient(new ClientItem(1, 2, 0));
        AddClient(new ClientItem(2, 1, 0));
        AddClient(new ClientItem(3, 4, 0));
        AddClient(new ClientItem(4, 5, 0));
        AddClient(new ClientItem(5, 12, 0));
    }

    public void AddClient(ClientItem item)
    {
        if (Clients.Count < 5)
        {
            Clients.Add(item);
        }
        UpdateClient(item);

    }
    public void DeleteClient(ClientItem item)
    {
        Debug.Log(item);
        for (int i = 0; i < Clients.Count; i++)
        {
            if (Clients[i].id == item.id)
            {
                Clients[i].state = 3;
                SendNotification(OrderSystemEvent.ADD_GUEST, Clients[i]);
                return;
            }
        }
        Debug.Log("客人走了刷新一下界面");

    }
    public void UpdateClient(ClientItem item)
    {
        Debug.Log(item.state);
        for (int i = 0; i < Clients.Count; i++)
        {
            if (Clients[i].id == item.id)
            {
                Clients[i] = item;
                Clients[i].state = item.state;
                Clients[i].population = item.population;
                SendNotification(OrderSystemEvent.ADD_GUEST, Clients[i]);
                return;
            }
        }
    }
}

