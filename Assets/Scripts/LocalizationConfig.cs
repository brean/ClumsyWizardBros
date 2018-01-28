using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationConfig : MonoBehaviour {
    
	public void German()
    {
        LocalizationManager.Instance = new LocalizationManager(Language.German);
    }

    public void English()
    {
        LocalizationManager.Instance = new LocalizationManager(Language.English);
    }
}
