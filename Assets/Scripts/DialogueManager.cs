using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueManager : MonoBehaviour {
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public bool animateText;

    private Queue<string> _sentences;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    // Start is called before the first frame update
    void Start() {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool(IsOpen, true);

        nameText.text = dialogue.name;
        Debug.Log("Starting conversation with " + dialogue.name);

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (_sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        Debug.Log(sentence);

        if (animateText) {
            StopCoroutine(TypeSentence(sentence));
            StartCoroutine(TypeSentence(sentence));
        }
        else dialogueText.text = sentence;
    }

    IEnumerator<string> TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char character in sentence.ToCharArray()) {
            dialogueText.text += character;
            yield return null;
        }
    }

    private void EndDialogue() {
        Debug.Log("End of conversation");
        animator.SetBool(IsOpen, false);
    }
}