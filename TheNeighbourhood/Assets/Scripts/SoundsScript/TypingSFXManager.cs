using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class TypingSFXManager: DialogueViewBase
{
    [Header("NPC's Names with corresponding ScriptableObject")]
    [SerializeField]
    private string[] NPC_Names;
    [SerializeField]
    private SoundScriptableObject soundScriptableObject;

    [SerializeField]
    private string characterName_TXT;

    [Header("Current AudioSource_READ_ONLY")]
    [SerializeField]
    private AudioSource currentAudioSource;

    void Start()
    {
        currentAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        SetCharacterSFX_AudioClip(dialogueLine.CharacterName);
        //Debug.Log("Running Line!!! " + this.gameObject.name);
    }

    private void SetCharacterSFX_AudioClip(string characterName)
    {
        characterName_TXT = characterName;
        Dictionary<string, AudioClip> characterAudioClip = new Dictionary<string, AudioClip>
        {
            {NPC_Names[0], soundScriptableObject.LillySFX}, //Lilly
            {NPC_Names[1], soundScriptableObject.CarolineSFX}, //Caro
            {NPC_Names[2], soundScriptableObject.MalkaSFX}, //Malka, Grandma
            {NPC_Names[3], soundScriptableObject.AmonSFX}, //Amon, Grandpa
            {NPC_Names[4], soundScriptableObject.TomSFX}, //Wolf
            {NPC_Names[5], soundScriptableObject.BirdSFX}, //Bird
            {NPC_Names[6], soundScriptableObject.SquirrelSFX}, //Squirrel
        };

        if (string.IsNullOrEmpty(characterName))
        {
            //Debug.Log("There is no Speaker");
            return;
        }
        else if (characterAudioClip.ContainsKey(characterName))
        {
            currentAudioSource.clip = characterAudioClip[characterName];

            //Debug.Log(characterName + " is speaking with" + characterNameColor);
        }
    }
}