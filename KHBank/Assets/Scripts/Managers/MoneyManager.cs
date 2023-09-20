using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    public int cashOnHand;
    public int balance;

    private void Awake()
    {
        instance = this;
    }
}
