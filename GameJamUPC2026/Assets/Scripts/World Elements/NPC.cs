using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider2D))]
public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private NPCDialogue dialogueData;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText, nameText;
    [SerializeField] private Image portraitImage;

    private int _dialogueIndex;
    private bool _isTyping, _isDialogueActive;
    private float _interactionCooldown = 0f;

    public bool CanInteract() => !_isDialogueActive && Time.time >= _interactionCooldown;

    public void Interact()
    {
        if (Time.time < _interactionCooldown) return;

        if (_isDialogueActive) 
            NextLine();
        else 
            StartDialogue();
    }

    private void StartDialogue()
    {
        _isDialogueActive = true;
        _dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        if (_isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[_dialogueIndex]);
            _isTyping = false;
        }
        else
        {
            _dialogueIndex++;
            if (_dialogueIndex < dialogueData.dialogueLines.Length)
                StartCoroutine(TypeLine());
            else
                EndDialogue();
        }
    }

    private IEnumerator TypeLine()
    {
        _isTyping = true;
        dialogueText.SetText("");

        foreach(var letter in dialogueData.dialogueLines[_dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        _isTyping = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent(out PlayerController player))
        {
            if (_isDialogueActive)
                EndDialogue();
        }
    }

    private void EndDialogue()
    {
        StopAllCoroutines();
        _isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        _interactionCooldown = Time.time + 0.5f;
    }
}