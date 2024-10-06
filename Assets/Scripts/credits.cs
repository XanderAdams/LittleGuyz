using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject CreditsUI;

    // Update is called once per frame
   public void Credits()
    {
        CreditsUI.SetActive(true);
    }

    public void exitCredits()
    {
        CreditsUI.SetActive(false);
    }

}
