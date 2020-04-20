using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// Lots of redundant code from DropZone.cs
// Perhaps dropzone can be integrated?

public class OptionCardDropZone : MonoBehaviour, IDropHandler
{

    // public variables
    //public int[] requiredTokens = new int[7];

    // private variables
    //private int[] tokensOnMe = new int[7];

    // Returns an array showing the number of tokens in this drop zone
    public int[] checkTokens()
    {
        int[] tokensOnMe = new int[7];

        //float beginTime = Time.time;
        // Check the children 
        Token[] tokenChildren = GetComponentsInChildren<Token>();
        foreach (Token token in tokenChildren)
        {
            ++tokensOnMe[(int)token.myTokenType];
        }


        //Debug.Log("calculation took " + (Time.time - beginTime).ToString("#.0000") + " seconds.");

        return tokensOnMe;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Token t = eventData.pointerDrag.GetComponent<Token>();
        if (d != null && t != null) 
        {
            d.parentToSnapTo = this.transform;
            d.pointToSnapTo = d.transform.position;
        }
    }

    /*
    // Returns whether or not the cost is fully paid off
    public bool CostPaidOff()
    {
        return false;
    }
    */

}
