using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;

    Queue<string> sentences = new Queue<string>();

    public Animator anim;

    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpen", true);
        sentences.Clear();

        txtName.text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence); //개체를 끝부분에 추가
        }
        if (Input.GetKey(KeyCode.X))
        {
            Next();
        }
        
    }

    public void Next()
    {

        if (sentences.Count == 0)
        {
            End();
            return;
        }

        txtSentence.text = string.Empty;
        StopAllCoroutines(); //코루틴은 시간의 경과에 따른 절차적 단계를 수행하는 로직을 구현하는데 사용되는 함수
        StartCoroutine(TypeSentence(sentences.Dequeue()));
        
        //sentences.Dequeue() 맨앞에 데이터만 가져오는 것이고 이것을 실행 시켰을 시에는 사라지고 sentences를 출력시 맨 앞 데이터는 사라져잇느 상태로 되어있다.
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach(var letter in sentence) //var 형식은 컴퓨터가 알아서 자료형을 찾을 수 있따.
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f); 
        }

     
    }
    
    private void End()
    {
        txtSentence.text= string.Empty;
        anim.SetBool("isOpen", false);
    }
}
