using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDefinition : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject itemDef;
    public Text itemNameText;
    public Text itemDefText;
    Transform pos;
    InventorySlot thisSlot;

    void Start()
    {
        if(itemDef!=null) itemDef.SetActive(false);
        pos = this.gameObject.transform;
        thisSlot = this.gameObject.GetComponent<InventorySlot>();
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        if (thisSlot.item != null)
        {
            if (itemDef != null)
            {
                itemDef.SetActive(true);
                itemDef.transform.position = new Vector3(pos.position.x + 80, pos.position.y - 80, pos.position.z);
            }
            itemNameText.text = thisSlot.item.itemName;
            itemDefText.text = thisSlot.item.itemDescripton;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (itemDef != null) itemDef.SetActive(false);
    }

}
