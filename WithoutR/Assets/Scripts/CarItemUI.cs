using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarItemUI : MonoBehaviour
{
    [SerializeField] Image carImage;
    [SerializeField] private TMP_Text carPriceText;
    [SerializeField] Button carPurchaseButton;
    [Space(20f)] [SerializeField] Button itemButton;

    public void SetItemPos(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetCarPrice(int price)
    {
        carPriceText.text = price.ToString();
    }

    public void SetCarAsPurchased()
    {
        carPurchaseButton.gameObject.SetActive(false);
        itemButton.interactable = true;
    }
}