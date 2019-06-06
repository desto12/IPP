using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }

    [HideInInspector]
    public string npcName;

    public GameObject dialoguePanel;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    TextMeshProUGUI dialogueText, nameText;
    int dialogueIndex;

    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("ContinueButton").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<TextMeshProUGUI>();
        continueButton.onClick.AddListener(delegate { ContinueDialog(); });
        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {   
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        CreateDialogue();
        Debug.Log("dialog został dodany  " + npcName);
        Debug.Log(dialogueText);
    }

    public void CreateDialogue()
    {
        nameText.text = npcName;
        dialogueText.text = dialogueLines[dialogueIndex];
        dialoguePanel.SetActive(true);
        Debug.Log("Okno dialogu "+ npcName +"a/y zostal aktywowany");

    }

    public void ContinueDialog()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
            Debug.Log("Wyświetlam " + dialogueIndex + " Linie tekstu");
        }
        else
            dialoguePanel.SetActive(false);
    }
}
