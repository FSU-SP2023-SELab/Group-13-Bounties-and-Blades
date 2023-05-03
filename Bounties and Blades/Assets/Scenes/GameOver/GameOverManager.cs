using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{

    public TextMeshProUGUI screenText;
    // Start is called before the first frame update
    void Start()
    {
       if(UnitManager.herosWon == true){
          screenText.text = "Victory! You Won!";
       }
       else{
          screenText.text = "Game Over! You Lost!";
       }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
