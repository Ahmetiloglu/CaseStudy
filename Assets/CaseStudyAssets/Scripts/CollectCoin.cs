using System;
using TMPro;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public int AmountofCoin = 0;
    public TextMeshProUGUI CoinText;

    private void Awake()
    {
        AmountofCoin = PlayerPrefs.GetInt("coins", 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            AmountofCoin++;
            Destroy(collider.gameObject);
            CoinText.text = "" + AmountofCoin;
            PlayerPrefs.SetInt("coins",AmountofCoin);
        }
    }
}
