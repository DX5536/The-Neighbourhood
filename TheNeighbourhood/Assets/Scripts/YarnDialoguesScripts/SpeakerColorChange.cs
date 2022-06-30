using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn.Unity;


public class SpeakerColorChange: DialogueViewBase
{
    [Header("NPC's Names with corresponding ScriptableObject")]
    [SerializeField]
    private string[] NPC_Names;
    [SerializeField]
    private ItemScriptableObject[] itemScriptableObjects;

    [Header("Current speaker_READ_ONLY")]
    [SerializeField]
    private string characterName_TXT;

    [Header("DialogSystem > Speaker's TMP -> Auto find")]
    [SerializeField]
    private TMP_Text characterName_TMP;

    [Header("DialogSystem > Lineview > Background -> Drag/Drop")]
    [SerializeField]
    private Image textBox_Background;


    void Start()
    {
        characterName_TMP = GameObject.Find("Character Name").GetComponent<TMP_Text>();
        if (characterName_TMP == null)
        {
            var sceneName = SceneManager.GetActiveScene();
            Debug.Log("There is no Character Name in this" + sceneName.name);
        }
    }

    void Update()
    {
    }

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        SetNameColor(dialogueLine.CharacterName);
        ChangeTextBoxColor(dialogueLine.CharacterName);
        Debug.Log("Running Line!!! " + this.gameObject.name);
    }

    private void SetNameColor(string characterName)
    {
        characterName_TXT = characterName;
        Dictionary<string, Color> characterNameColor = new Dictionary<string, Color>
        {
            {NPC_Names[0], itemScriptableObjects[0].SpeakerNPC_Color}, //Lilly
            {NPC_Names[1], itemScriptableObjects[1].SpeakerNPC_Color}, //Caro
            {NPC_Names[2], itemScriptableObjects[2].SpeakerNPC_Color}, //Malka, Grandma
            {NPC_Names[3], itemScriptableObjects[3].SpeakerNPC_Color}, //Amon, Grandpa
            {NPC_Names[4], itemScriptableObjects[4].SpeakerNPC_Color}, //Wolf
            {NPC_Names[5], itemScriptableObjects[5].SpeakerNPC_Color}, //Bird
            {NPC_Names[6], itemScriptableObjects[6].SpeakerNPC_Color}, //Squirrel
        };

        if (string.IsNullOrEmpty(characterName))
        {
            Debug.Log("There is no Speaker");
        }
        else if (characterNameColor.ContainsKey(characterName))
        {
            characterName_TMP.color = characterNameColor[characterName];

            Debug.Log(characterName + " is speaking with" + characterNameColor);
        }
    }

    public void ChangeTextBoxColor(string characterNameTextBox)
    {
        Dictionary<string, Color> characterTextBoxColor = new Dictionary<string, Color>
        {
            {NPC_Names[0], itemScriptableObjects[0].TextBox_Color}, //Lilly
            {NPC_Names[1], itemScriptableObjects[1].TextBox_Color}, //Caro
            {NPC_Names[2], itemScriptableObjects[2].TextBox_Color}, //Malka, Grandma
            {NPC_Names[3], itemScriptableObjects[3].TextBox_Color}, //Amon, Grandpa
            {NPC_Names[4], itemScriptableObjects[4].TextBox_Color}, //Wolf
            {NPC_Names[5], itemScriptableObjects[5].TextBox_Color}, //Bird
            {NPC_Names[6], itemScriptableObjects[6].TextBox_Color}, //Squirrel
        };

        //textBox_Background.color = new Color(255, 255, 0, 50);

        if (string.IsNullOrEmpty(characterNameTextBox))
        {
            Debug.Log("There is no Speaker");
        }
        else if (characterTextBoxColor.ContainsKey(characterNameTextBox))
        {
            textBox_Background.color = characterTextBoxColor[characterNameTextBox];

            Debug.Log(characterNameTextBox + " is speaking with box: " + characterTextBoxColor);
        }
    }

}

