using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public enum Language { German, English };

public class LocalizationManager {


    private static LocalizationManager instance;

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized Text not found";

    public LocalizationManager(Language language)
    {
        loadLocalizedText(language);
    }

    public static LocalizationManager Instance {
        get {
            if (instance == null)
            {
                Debug.LogWarning("Localization manager not set, fallback to english translation");
                instance = new LocalizationManager(Language.English);
            }
            return instance;
        }

        set {
            instance = value;
        }
    }

	public void loadLocalizedText (Language language){
        string lang = "en";
        switch (language)
        {
            case Language.German:
                lang = "de";
                break;
            default:
                lang = "en";
                break;
        }
        string fileName = "localizedText_" + lang + ".json";

        localizedText = new Dictionary<string, string>();
		string filePath = Path.Combine (Application.streamingAssetsPath, fileName);
		if (File.Exists (filePath)) {
			string dataAsJson = File.ReadAllText (filePath);
			LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

			for (int i = 0; i < loadedData.items.Length; i++) {
				localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);
			}

			Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");
		} else {
			//For the final game this should be filled with proper error handling
			Debug.LogError ("Cannot find file!");
		}

		isReady = true;
	}

    public string GetLocalizedValue(string key){
		string result = missingTextString;
		if(instance.localizedText.ContainsKey(key)){
			result = instance.localizedText [key];
		}

		return result;
	}

	public bool GetIsReady(){
		return isReady;
	}
}
