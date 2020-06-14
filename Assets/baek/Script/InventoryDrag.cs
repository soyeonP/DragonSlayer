using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDrag : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    Vector2 beginPosition;
    public void OnBeginDrag (PointerEventData data)
    {
        beginPosition = data.position;
    }

    public void OnDrag (PointerEventData data)
    {
        Vector2 mouseMove = data.position - beginPosition;
        beginPosition = data.position;

        this.gameObject.GetComponent<RectTransform>().anchoredPosition += mouseMove;
    }
}
