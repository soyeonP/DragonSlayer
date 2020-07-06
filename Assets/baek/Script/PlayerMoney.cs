using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    #region Singleton
    public static PlayerMoney instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Money 인스턴스가 1개 이상 발견되었습니다.");
            return;
        }
        instance = this;
    }
    #endregion

    public static int moneyValue = 0;

    public delegate void OnMoneyChanged(); //delegate: 함수에 대한 참조
    public OnMoneyChanged onMoneyChagedCallback;

    public void addMoney(int money)
    {
        moneyValue += money;
        if (onMoneyChagedCallback != null)
            onMoneyChagedCallback.Invoke();
    }

    public void reduceMoney(int money)
    {
        moneyValue -= money;
        if (onMoneyChagedCallback != null)
            onMoneyChagedCallback.Invoke();
    }

    public int returnMoney()
    {
        return moneyValue;
    }
}
