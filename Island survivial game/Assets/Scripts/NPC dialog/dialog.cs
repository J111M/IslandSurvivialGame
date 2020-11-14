using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continuebutton;


    void Start()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
            //StartCoroutine(Type());
        //}
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Type());
        }


        if (textDisplay.text == sentences[index])
        {
            continuebutton.SetActive(true);
        }
    }


    IEnumerator Type (){

        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextSentence()
    {

        continuebutton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continuebutton.SetActive(false);
        }
    }


}
