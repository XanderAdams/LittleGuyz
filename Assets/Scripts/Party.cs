using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public LittleGuyzStats yourGuy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upload(LittleGuyzStats target)
    {
        target.unitName = yourGuy.unitName;
    }
}
