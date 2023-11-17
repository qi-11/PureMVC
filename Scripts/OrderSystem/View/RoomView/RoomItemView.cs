using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemView : MonoBehaviour
{
    private Text roomText;
    private Image roomImage;
    public RoomItem roomItem;
    public IList<Action<object>>list_Action=new List<Action<object>>();
    private void Awake()
    {
        roomText = transform.Find("Id").GetComponent<Text>();
        roomImage = transform.GetComponent<Image>();
    }
    public void InitRoom(RoomItem roomItem)
    {
        this.roomItem = roomItem;
        UpdateType();
    }

    private void UpdateType()
    {
        if (roomItem == null)
            return;
        Color color = Color.white;
        switch (this.roomItem.type)
        {
            case RoomType.WaitClient:
                color = Color.green;
                break;
            case RoomType.Sleep:
                color = Color.red;
                StartCoroutine(sleeping(5));
                break;
            case RoomType.Pay:
                color = Color.white;
                StartCoroutine(AddGuest(4));
                break;
            default:
                break;
        }
        roomImage.color = color;
        roomText.text= roomItem.ToString();
    }

    IEnumerator AddGuest(float time)
    {
        yield return new WaitForSeconds(time);
        list_Action[0].Invoke(roomItem);
    }

    IEnumerator sleeping(float time)
    {
        yield return new WaitForSeconds(time);
        roomItem.type++;
        list_Action[1].Invoke(roomItem);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
