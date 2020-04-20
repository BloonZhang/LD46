using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Tells Unity that's it's possible to make through the Create menu. Nifty!
[CreateAssetMenu(fileName = "New EventCard", menuName = "EventCard")]
public class EventCard : ScriptableObject
{

    // public variables
    public string cardName;
    public string description;
    public Image art;
    public OptionCard[] options;
    public string season;

    // test method
    public void Print ()
    {
        Debug.Log("successfuly printed: " + cardName);
    }

}
