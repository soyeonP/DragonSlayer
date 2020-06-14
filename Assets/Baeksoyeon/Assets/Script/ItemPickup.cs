using UnityEngine;

public class ItemPickup : Interactable
{
    //[SerializeField] public Item item;

    public Item item;
    SceneMusicPlay musicPlay;

    void Start()
    {
        musicPlay = new SceneMusicPlay(GameObject.Find("ItemClickSE"));
    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        //Debug.Log("아이템 획득: " + item.itemName);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            if (musicPlay != null)
            {
                musicPlay.MusicStart(); //SE틀기
            }
            Destroy(gameObject);
        }
    }

}
