using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tells Unity that's it's possible to make through the Create menu. Nifty!
[CreateAssetMenu(fileName = "New OptionCard", menuName = "OptionCard")]
public class OptionCard : ScriptableObject
{

    // public variables
    public string cardName;
    public Token.TokenType[] cost;
    public Token.TokenType[] reward;
    public EventCard cardReward;

    // test method
    public void Print ()
    {
        Debug.Log("successfuly printed: " + cardName);
    }

}
