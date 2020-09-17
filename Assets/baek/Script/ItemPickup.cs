using UnityEngine;

public class ItemPickup : Interactable
{
    //[SerializeField] public Item item;

    [System.Serializable]
    public struct ItemInfo{
        public Item item;
        public int itemCount;
    }
    [SerializeField] ItemInfo itemInfo;
    [SerializeField] int money = 0;
    SceneMusicPlay musicPlay;

    void Start()
    {
        musicPlay = new SceneMusicPlay(GameObject.Find("ItemClickSE"));
    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
        if (money >= 0) getMoney(money);
    }

    void PickUp()
    {
        //Debug.Log("아이템 획득: " + item);
        if (Inventory.instance.Add(itemInfo.item, itemInfo.itemCount))
        {
            if (musicPlay != null)
            {
                musicPlay.MusicStart(); //SE틀기
            }
            Destroy(gameObject);
        }
    }

    void getMoney(int money)
    {
        PlayerMoney.instance.addMoney(money);
    }

}
