using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventCardController : MonoBehaviour
{
    
    // public variables
    public EventCard eventCard;
    public TextMeshProUGUI cardName;
    public Image art;
    public TextMeshProUGUI cardDescription;

    void Start()
    {
        // Set up card graphics here
        eventCard.Print();

        cardName.text = eventCard.cardName;
        art = eventCard.art;
        cardDescription.text = eventCard.description;
    }
}
