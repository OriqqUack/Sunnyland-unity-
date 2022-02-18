using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;

    Queue<string> sentences = new Queue<string>();

    public void Begin(Dialogue info)
    {
        sentences.Clear();

        txtName.text = info.name;
        
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence); //개체를 끝부분에 추가
        }

        Next();
    }

    private void Next()
    {
        if (sentences.Count == 0) ;
        {
            End();
        }

        txtSentence.text = sentences.Dequeue(); //시작부분에서 개체를 제거하고 반환
    }

    private void End()
    {
       
    }
}
