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
            sentences.Enqueue(sentence); //��ü�� ���κп� �߰�
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
        StopAllCoroutines(); //�ڷ�ƾ�� �ð��� ����� ���� ������ �ܰ踦 �����ϴ� ������ �����ϴµ� ���Ǵ� �Լ�
        StartCoroutine(TypeSentence(sentences.Dequeue()));
        
        //sentences.Dequeue() �Ǿտ� �����͸� �������� ���̰� �̰��� ���� ������ �ÿ��� ������� sentences�� ��½� �� �� �����ʹ� ������մ� ���·� �Ǿ��ִ�.
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach(var letter in sentence) //var ������ ��ǻ�Ͱ� �˾Ƽ� �ڷ����� ã�� �� �ֵ�.
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
