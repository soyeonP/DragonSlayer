using UnityEngine;

public class GetMoney : Interactable
{
    //아이템과 돈이 같이 획득되는 경우엔 ItemPickup함수 사용할것.
    [SerializeField] int money;
    //필드에 돈이 뿌려질 경우...돈 먹으면 증감.

    public override void Interact()
    {
        base.Interact();
        getMoney(money);
    }

    void getMoney(int money)
    {
        PlayerMoney.instance.addMoney(money);
    }
}
