using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GMScript : MonoBehaviour
{

    public int score;
    public GameObject chest;

    public GameObject namePanel;
    public GameObject dialougePanel;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public int index;
    public int index1;

    public GameObject flashlightPanel;
    public TextMeshProUGUI flashlightText;
    public string[] lines1;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        flashlightPanel.SetActive(false);
        flashlightText.text = string.Empty;

        namePanel.SetActive(true);
        textComponent.text = string.Empty;
        dialougePanel.SetActive(true);
        StartDialouge();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopCoroutine(TypeLine());
                textComponent.text = lines[index];
            }
        }

     

        if (score == 0) //box with code activated - after user gets remote. score +=1
        {


        }
        if (score == 1) //tv activated, cant move screen until video over, after, score += 1
        {

        }
        if (score == 2) //computer activated, after, score += 1 but user can reuse computer
        {

        }
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    public void StartFlashlightText()
    {
        index1 = 0;
        StartCoroutine(TypeText());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

   public IEnumerator TypeText()
    {
        foreach (char x in lines1[index1].ToCharArray())
        {
            flashlightText.text += x;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            namePanel.SetActive(false);
            dialougePanel.SetActive(false);
        }
    }



}
