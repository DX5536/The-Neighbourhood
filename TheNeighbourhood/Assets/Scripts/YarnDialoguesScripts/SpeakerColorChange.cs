using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;


public class SpeakerColorChange: DialogueViewBase
{
    [Header("NPC's Names with corresponding ScriptableObject")]
    [SerializeField]
    private string[] NPC_Names;
    [SerializeField]
    private ItemScriptableObject[] itemScriptableObjects;

    [Header("DialogSystem > Speaker's TMP -> Auto find")]
    [SerializeField]
    private TMP_Text characterName_TMP;


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
        Debug.Log("Running Line!!!");
    }

    private void SetNameColor(string characterName)
    {
        Dictionary<string, Color> characterNameColor = new Dictionary<string, Color>
        {
            {NPC_Names[0], itemScriptableObjects[0].SpeakerNPC_Color}, //Lilly
            {NPC_Names[1], itemScriptableObjects[1].SpeakerNPC_Color}, //Caro
            {NPC_Names[2], itemScriptableObjects[2].SpeakerNPC_Color}, //Malka, Grandma
            {NPC_Names[3], itemScriptableObjects[3].SpeakerNPC_Color}, //Amon, Grandpa
            {NPC_Names[4], itemScriptableObjects[4].SpeakerNPC_Color}, //Wolf
            {NPC_Names[5], itemScriptableObjects[5].SpeakerNPC_Color}, //Bird
            {NPC_Names[6], itemScriptableObjects[6].SpeakerNPC_Color}, //Squirrel

            //DOESNT WORK and simply more work ;_;
            /*{NPC_Names[0], NPC_Colors[0]}, //Lilly
            {NPC_Names[1], NPC_Colors[1]}, //Caro
            {NPC_Names[2], NPC_Colors[2]}, //Malka, Grandma
            {NPC_Names[3], NPC_Colors[3]}, //Amon, Grandpa
            {NPC_Names[4], NPC_Colors[4]}, //Wolf
            {NPC_Names[5], NPC_Colors[5]}, //Bird
            {NPC_Names[6], NPC_Colors[6]}, //Squirrel*/
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
}