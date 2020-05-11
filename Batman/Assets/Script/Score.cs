using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    static int latscore;
    int curScore;
    Text textEditor;
    

    private void Start()
    {
        textEditor = GetComponent<Text>();
        if (Application.loadedLevel == 1)
        {
            latscore = 0;
        }
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        textEditor.text = Display().ToString();
    }

   
    public int Display()
    {
        return latscore;
    }

    public int AddToScore(int curScore)
    {
        latscore += curScore;
        return latscore;
    }

  
}
