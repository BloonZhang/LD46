using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionCardController : MonoBehaviour
{
    // public variables
    public OptionCard optionCard;
    public TextMeshProUGUI cardName;
    public LayoutGroup costLayout;
    public LayoutGroup rewardsLayout;
    public DropZone myDropZone;
    //public Token.TokenType[] cost;
    //public Token.TokenType[] rewards;

    // GameObjects for Cost
    public GameObject WaterSprite;
    public GameObject LightSprite;
    public GameObject NutrientSprite;
    public GameObject MoneySprite;
    public GameObject LegalRepSprite;
    public GameObject FoodSprite;
    public GameObject HungerSprite;

    void Start()
    {
        // Set up card graphics here
        optionCard.Print();

        cardName.text = optionCard.cardName;

    }
}
