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
    EqipSlot equipSlot;
    bool isEquipSlot = false;
    void Start()
    {
        if(itemDef!=null) itemDef.SetActive(false);
        pos = this.gameObject.transform;

        if(this.gameObject.tag == "EquipSlot"){
            equipSlot = this.gameObject.GetComponent<EqipSlot>();
            isEquipSlot = true;
        }else{
            thisSlot = this.gameObject.GetComponent<InventorySlot>();
            isEquipSlot = false;
        }
        
        
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        if(!isEquipSlot){
            if (thisSlot.item != null)
            {
                if (itemDef != null)
                {
                    itemDef.SetActive(true);
                    itemDef.transform.position = new Vector3(pos.position.x + 80, pos.position.y - 80, pos.position.z);
                }
                itemNameText.text = thisSlot.item.itemName;
                itemDefText.text = thisSlot.item.itemDescripton;
                if(thisSlot.item.itemType == Item.ItemType.equip) itemDefText.text += ("\n* 우클릭으로 장착");
                //장비일 경우 추가 설명
            }
        }else{
            if (equipSlot.item != null)
            {
                if (itemDef != null)
                {
                    itemDef.SetActive(true);
                    itemDef.transform.position = new Vector3(pos.position.x + 50, pos.position.y - 50, pos.position.z);
                }
                itemNameText.text = equipSlot.item.itemName;
                itemDefText.text = equipSlot.item.itemDescripton;
                if(equipSlot.item.itemType == Item.ItemType.equip) itemDefText.text += ("\n* 우클릭으로 장착");
                //장비일 경우 추가 설명
            }            
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (itemDef != null) itemDef.SetActive(false);
    }

}
