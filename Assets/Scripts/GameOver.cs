using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
