using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingShop : MonoBehaviour
{
    public ItemForShop[] itemForShops;
    public GameObject prefab_shopItem;
    public GameObject prefabParentObject;
    GameObject[] child = new GameObject[100];

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<itemForShops.Length; i++){
            child[i] = Instantiate(prefab_shopItem) as GameObject;
            child[i].transform.parent = prefabParentObject.transform;
            child[i].transform.localScale = new Vector3(1,1,1);
            child[i].GetComponent<SettingShopItems>().itemForShop = itemForShops[i];
        }
    }

}
