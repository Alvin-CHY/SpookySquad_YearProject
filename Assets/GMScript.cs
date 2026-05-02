using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{

    public int score;
    public GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
