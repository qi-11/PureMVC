
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoomView : MonoBehaviour
{
    public UnityAction<RoomItem> CallWaiter = null;
    public UnityAction Pay = null;
    private ObjectPool<RoomItemView> objectPool = null;
    private List<RoomItemView> rooms = new List<RoomItemView>();
    private Transform parent = null;
    private void Awake()
    {
        parent = this.transform.Find("Content");
        var prefab = Resources.Load<GameObject>("Prefabs/UI/RoomItem");
        objectPool = new ObjectPool<RoomItemView>(prefab, "RoomPool");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateClient(IList<RoomItem> rooms, IList<Action<object>> objs)
    {

        for (int i = 0; i < this.rooms.Count; i++)
            objectPool.Push(this.rooms[i]);

        this.rooms.AddRange(objectPool.Pop(rooms.Count));

        for (int i = 0; i < this.rooms.Count; i++)
        {
            var room = this.rooms[i];
            room.transform.SetParent(parent);
            room.InitRoom(rooms[i]);
            room.list_Action = objs;
            room.GetComponent<Button>().onClick.RemoveAllListeners();
            room.GetComponent<Button>().onClick.AddListener(() => { if (room.roomItem.type == 0) CallWaiter(room.roomItem); });
        }
    }
    public void UpdateState(RoomItem room)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].roomItem.id.Equals(room.id))
            {
                rooms[i].InitRoom(room);
                return;
            }
        }
    }
    public void RefrshRoom(IList<RoomItem> Reclients)
    {
        for (int i = 0; i < Reclients.Count; i++)
        {
            UpdateState(Reclients[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
