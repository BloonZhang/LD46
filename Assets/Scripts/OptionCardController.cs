using System; // Enum.GetValue
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
    public OptionCardDropZone myDropZone;

    // private variables
    private int[] tokensOnMe = new int[7]; // each index corresponds with an tokentype enum
    private int[] requiredTokens = new int[7];

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
        //optionCard.Print();

        // set up text and costs and such
        cardName.text = optionCard.cardName;
        setUpLayout();

    }

    void Update()
    {
        tokensOnMe = myDropZone.checkTokens();
        
        if (checkIfPaid()) {Debug.Log("paid");}
    }

    // helper function, sets up cost and reward spirtes
    // Also sets up rqeuiredTokens array
    void setUpLayout()
    {
        foreach(Token.TokenType token in optionCard.cost)
        {
            /*
            0: WATER
            1: LIGHT
            2: NUTRIENT
            3: MONEY
            4: LEGALREP
            5: FOOD
            6: HUNGER
            */
            switch ((int)token)
            {
                case 0:
                    Instantiate(WaterSprite, costLayout.transform);
                    ++requiredTokens[(int)Token.TokenType.WATER];
                    break;
                case 1:
                    Instantiate(LightSprite, costLayout.transform);
                    ++requiredTokens[(int)Token.TokenType.LIGHT];
                    break;
                case 2:
                    Instantiate(NutrientSprite, costLayout.transform);
                    ++requiredTokens[(int)Token.TokenType.NUTRIENT];
                    break;
                case 3:
                    Instantiate(MoneySprite, costLayout.transform);
                    ++requiredTokens[(int)Token.TokenType.MONEY];
                    break;
                case 4:
                    Instantiate(LegalRepSprite, costLayout.transform);
                    ++requiredTokens[(int)Token.TokenType.LEGALREP];
                    break;
                case 5:
                    Instantiate(FoodSprite, costLayout.transform);
                    ++requiredTokens[(int)Token.TokenType.FOOD];
                    break;
                case 6:
                    Instantiate(HungerSprite, costLayout.transform);
                    ++requiredTokens[(int)Token.TokenType.HUNGER];
                    break;
                default:
                    break;
            }
        }
        foreach(Token.TokenType token in optionCard.reward)
        {
            switch ((int)token)
            {
                case 0:
                    Instantiate(WaterSprite, rewardsLayout.transform);
                    break;
                case 1:
                    Instantiate(LightSprite, rewardsLayout.transform);
                    break;
                case 2:
                    Instantiate(NutrientSprite, rewardsLayout.transform);
                    break;
                case 3:
                    Instantiate(MoneySprite, rewardsLayout.transform);
                    break;
                case 4:
                    Instantiate(LegalRepSprite, rewardsLayout.transform);
                    break;
                case 5:
                    Instantiate(FoodSprite, rewardsLayout.transform);
                    break;
                case 6:
                    Instantiate(HungerSprite, rewardsLayout.transform);
                    break;
                default:
                    break;
            }
        }
    }

    // helper funcion, see if all costs are paid off
    bool checkIfPaid()
    {
        int difference = 0;
        // go through each type of resource execept legalRep
        for (int i = 0; i < Enum.GetValues(typeof(Token.TokenType)).Length; ++i)
        {
            // Skip legalRep
            if (i == (int) Token.TokenType.LEGALREP) {continue;}

            // If more than required
            if (tokensOnMe[i] > requiredTokens[i]) {return false;}
            // Else calculate how many more are needed
            else {difference += requiredTokens[i] - tokensOnMe[i];}
        }

        // return true if the difference is made up by LEGALREP
        return (difference - tokensOnMe[(int)Token.TokenType.LEGALREP]) == 0;
    }
}
