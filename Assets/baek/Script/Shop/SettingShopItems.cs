using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingShopItems : MonoBehaviour
{
    public ItemForShop itemForShop;
    public  GameObject itemImage;
    public GameObject itemName;
    public GameObject itemDef;
    public GameObject itemPrice;

    // Start is called before the first frame update
    void Start()
    {
        itemImage.GetComponent<Image>().sprite = itemForShop.item.itemIcon;
        itemName.GetComponent<Text>().text = itemForShop.item.itemName;
        itemDef.GetComponent<Text>().text = itemForShop.itemShopDescripton;
        itemPrice.GetComponent<Text>().text = "$" + itemForShop.price.ToString();
    }

}
