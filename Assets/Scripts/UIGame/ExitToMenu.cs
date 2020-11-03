using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToMenu : MonoBehaviour
{
    public void ClickExit()
    {
        SceneManager.LoadScene("GameMenu", LoadSceneMode.Single);

    }
}
