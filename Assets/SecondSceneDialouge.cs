using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondSceneDialouge : MonoBehaviour
{
    public GameObject namePanel;
    public GameObject dialougePanel;
    public GameObject doorPanel;
    public GameObject exitDoorPanel;

    public TextMeshProUGUI monolougeText;
    public TextMeshProUGUI doorText;
    public TextMeshProUGUI exitDoorText;

    public string[] lines;
    public string[] lines1;

    public float textSpeed;
    public int index;
    public int index1;


    // Start is called before the first frame update
    void Start()
    {
        doorPanel.SetActive(false);
        exitDoorPanel.SetActive(false);

        namePanel.SetActive(true);
        monolougeText.text = string.Empty;
        dialougePanel.SetActive(true);
        StartDialouge();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (monolougeText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopCoroutine(TypeLine());
                monolougeText.text = lines[index];
            }
        }
    }

   public void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            monolougeText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            monolougeText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            namePanel.SetActive(false);
            dialougePanel.SetActive(false);
            monolougeText.text = string.Empty;
        }
    }
}
