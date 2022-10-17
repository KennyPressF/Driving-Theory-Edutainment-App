using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableCars : MonoBehaviour
{
    [SerializeField] GameObject lockedSymbol;
    [SerializeField] CarStatsSO carStatsSO;

    private void Start()
    {
        if (carStatsSO.carIsUnlocked)
        {
            HideLockSymbol();
        }
    }

    private void HideLockSymbol()
    {
        lockedSymbol.gameObject.SetActive(false);
    }
}
