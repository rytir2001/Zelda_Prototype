using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class Dictation : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    private DictationRecognizer dictationRecognizer;
    public string pica;
    public static Queue<string> wordsQueue = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_Result;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;

        dictationRecognizer.Start();
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
    }

    private void ON_TEXT_CHANGED(UnityEngine.Object obj)
    {
        if (obj == tmp)
        {
            pica += tmp.text;
            string[] words = pica.Split(" ");
            foreach (string word in words)
            {
                //Debug.Log(word);
                wordsQueue.Enqueue(word);
            }

            foreach (string item in wordsQueue)
            {
                Debug.Log(item);
            }
            pica = "";

            
        }
        
    }

    private void DictationRecognizer_Result(string text, ConfidenceLevel confidence)
    {
        //tmp.text = text;
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        tmp.text = text;
    }

}
