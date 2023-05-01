using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using BountiesAndBlades.BaseHero;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    public CharacterDatabase characterDB;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI NumInParty;
    public TextMeshProUGUI CharacterDesc;
    public GameObject obj;
    private GameObject clone;

    public List<GameObject> team;

    void Awake(){
        Instance = this;
        team = new List<GameObject>();
    }
    

    public Button addButton;
    public Button removeButton;
    public Button playButton;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption);
        playButton.gameObject.SetActive(false);
    }

    void Update(){
        NumInParty.text = team.Count.ToString();

        UpdateDescription();

        if(team.Contains(obj)){
            addButton.interactable = false;
            removeButton.interactable = true;
        }
        else if(team.Count == 3 && team.Contains(obj) == false){
            addButton.interactable = false;
            removeButton.interactable = false;
        }
        else{
            addButton.interactable = true;
            removeButton.interactable = false;
        }
        if(team.Count == 3){
            playButton.gameObject.SetActive(true);
            CharacterDesc.gameObject.SetActive(false);
        }
        else{
            playButton.gameObject.SetActive(false);
            CharacterDesc.gameObject.SetActive(true);
        }
    }
    public void NextOption(){
        Destroy(clone);
        selectedOption++;
        if(selectedOption >= characterDB.CharacterCount){
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
    }

    public void UpdateDescription(){
        BaseHero myHero = obj.GetComponent<BaseHero>();
        CharacterDesc.text = myHero.getDescription();
    }

    public void BackOption(){
        Destroy(clone);
        selectedOption--;
        if(selectedOption < 0){
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
    }

    public void AddToTeam(){
        team.Add(obj);
    }
    public void DeleteFromTeam(){
        team.Remove(obj);
    }

    public void proceedToLevel(){
        SceneManager.LoadScene("Level_1");
    }


    private void UpdateCharacter(int selected){
        Character character = characterDB.GetCharacter(selected);
        nameText.text = character.characterName;
        obj = character.characterObject;
        clone = Instantiate(obj, new Vector3(0, (float).1, 0), Quaternion.identity);
    }
}
