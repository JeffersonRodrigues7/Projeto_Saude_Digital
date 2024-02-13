using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction_2 : MonoBehaviour, IInteractable
{

    [SerializeField] TextAsset inkDialogueText;
    [SerializeField] InteractionButton interactionButton;

    private TalkHelpUI talkHelpUI;
    private bool isPlayerOnRange = true;

    private void Start()
    {
        talkHelpUI = FindObjectOfType<TalkHelpUI>();
    }

    public void Interact()
    {
        Dialogue dialogue = new Dialogue(inkDialogueText);
        DialogueManager.Instance.InitDialogue(dialogue);
        DialogueManager.Instance.StartDialogue();
    }

    public void InInteractionRange()
    {
        if (isPlayerOnRange)
            return;

        isPlayerOnRange = true;
        interactionButton.Show(this);

        if (talkHelpUI)
            talkHelpUI.ShowTalkingHelp();
    }

    public void OutOfInteractionRange()
    {
        if (!isPlayerOnRange)
            return;

        isPlayerOnRange = true;
        interactionButton.Hide();

        if (talkHelpUI)
            talkHelpUI.CloseTalkingHelp();
    }

}
