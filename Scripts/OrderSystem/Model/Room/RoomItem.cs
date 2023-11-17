using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RoomType
{
    WaitClient,
    Sleep,
    Pay
}
public class RoomItem 
{
    public int id { get; set; }
    public int population { get; set; }
    public RoomType type { get; set; }
    public RoomItem(int id, int population, RoomType type)
    {
        this.id = id;
        this.population = population;
        this.type = type;
    }
    public override string ToString()
    {
        return id + "�ŷ�" + "\n" + population + "����" + "\n" + OnRoomsStart(type);
    }

    private string OnRoomsStart(RoomType type)
    {
        if (type.Equals(RoomType.WaitClient))
            return "�ȴ�����";
        if (type.Equals(RoomType.Sleep))
            return "˯��";
        if (type.Equals(RoomType.Pay))
            return "�Ѿ�����";
        return "�Ѿ�����";
    }
}
