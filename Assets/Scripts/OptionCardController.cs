using System; // Enum.GetValue
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // IPointerClickHandler
using TMPro;



public class OptionCardController : MonoBehaviour, IPointerClickHandler
{
    // public variables
    public OptionCard optionCard;
    public Image cardGlow;
    public TextMeshProUGUI cardName;
    public LayoutGroup costLayout;
    public LayoutGroup rewardsLayout;
    public TextMeshProUGUI rewardText;
    public OptionCardDropZone myDropZone;

    // private variables
    private int[] tokensOnMe = new int[7]; // each index corresponds with an tokentype enum
    private int[] requiredTokens = new int[7];
    private int[] rewardsArray = new int[7];
    private bool paidOff;

    // helper variables

    // GameObjects for Cost
    /*
    0: WATER
    1: LIGHT
    2: NUTRIENT
    3: MONEY
    4: LEGALREP
    5: FOOD
    6: HUNGER
    */
    public GameObject[] CostSprites = new GameObject[7];
    public GameObject[] RewardTokens = new GameObject[7];

    void Start()
    {
        //optionCard.Print();

        // set up text and costs and such
        cardName.text = optionCard.cardName;
        setUpLayout();
        paidOff = false;
        cardGlow.enabled = false;

        //giveRewards();

    }

    void Update()
    {
        tokensOnMe = myDropZone.checkTokens();

        // Control card glow if paid
        paidOff = checkIfPaid();
        cardGlow.enabled = paidOff;

    }

    // When clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (paidOff)
        {
            giveRewards();
            Debug.Log("rewards!");
            //TODO: remove all attached tokens
            //TODO: remove card
        }
    }



    // See if all costs are paid off
    bool checkIfPaid()
    {
        int difference = 0;
        int extraLegalRep = 0;
        // go through each type of resource execept legalRep
        for (int i = 0; i < Enum.GetValues(typeof(Token.TokenType)).Length; ++i)
        {
            // legalRep is unique
            if (i == (int) Token.TokenType.LEGALREP) 
            {
                // Too few legal rep
                if (requiredTokens[i] > tokensOnMe[i]) {return false;}
                // Calculate extra legal rep
                else {extraLegalRep = tokensOnMe[i] - requiredTokens[i];}
                continue;
            }

            // If more than required
            if (tokensOnMe[i] > requiredTokens[i]) {return false;}
            // Else calculate how many more are needed
            else {difference += requiredTokens[i] - tokensOnMe[i];}
        }

        // return true if the difference is made up by LEGALREP
        return (difference - tokensOnMe[(int)Token.TokenType.LEGALREP]) == 0;
    }

    // Dispenses rewards
    // NOTE: Gross hardcode. Maybe offset by half of size of token?
    void giveRewards()
    {
        // First five resources
        // NOTE: hardcoded
        GameObject resourceZone = GameObject.FindWithTag("ResourceZone");
        Vector3 baseSpawnPoint = new Vector3(resourceZone.transform.position.x + 35, resourceZone.transform.position.y + 120, 0);
        int offsetCounter = 0;
        for (int iTokenType = 0; iTokenType < 5; ++iTokenType)
        {
            for (int j = 0; j < rewardsArray[iTokenType]; ++j)
            {
                Instantiate(RewardTokens[iTokenType], 
                    baseSpawnPoint + new Vector3(35 * offsetCounter, 0, 0),
                    Quaternion.identity, 
                    resourceZone.transform);
                ++offsetCounter;
            }
        }
        // Sixth resource, food
        GameObject foodZone = GameObject.FindWithTag("FoodZone");
        baseSpawnPoint = new Vector3(foodZone.transform.position.x + 35, foodZone.transform.position.y + 120, 0);
        offsetCounter = 0;
        for (int j = 0; j < rewardsArray[5]; ++j)
        {
            Instantiate(RewardTokens[5], 
                baseSpawnPoint + new Vector3(35 * offsetCounter, 0, 0),
                Quaternion.identity, 
                foodZone.transform);
            ++offsetCounter;
        }
        // Seventh resource, hunger
        GameObject hungerZone = GameObject.FindWithTag("HungerZone");
        baseSpawnPoint = new Vector3(hungerZone.transform.position.x + 35, hungerZone.transform.position.y + 120, 0);
        offsetCounter = 0;
        for (int j = 0; j < rewardsArray[6]; ++j)
        {
            Instantiate(RewardTokens[6], 
                baseSpawnPoint + new Vector3(35 * offsetCounter, 0, 0),
                Quaternion.identity, 
                hungerZone.transform);
            ++offsetCounter;
        }
    }

    // helper function, sets up cost and reward spirtes
    // Also sets up rqeuiredTokens array and rewardArray
    void setUpLayout()
    {
        foreach(Token.TokenType token in optionCard.cost)
        {
            Instantiate(CostSprites[(int)token], costLayout.transform);
            ++requiredTokens[(int)token];
        }
        foreach(Token.TokenType token in optionCard.reward)
        {
            Instantiate(CostSprites[(int)token], rewardsLayout.transform);
            ++rewardsArray[(int)token];
        }
    }
}
