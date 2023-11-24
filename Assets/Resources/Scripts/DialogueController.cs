using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    private Touch theTouch;
    public GameObject thisthing;
    public GameObject tresure;
    public GameObject onboarding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       if(Input.touchCount > 0)
       {
            theTouch = Input.GetTouch(0);

            // Check if the touch phase is ended
            if (theTouch.phase == TouchPhase.Ended)
            {
                NextSentence();
            }
        }
    }

    void NextSentence()
    {
        if(Index <= Sentences.Length - 1)
        {
            if(Index == Sentences.Length - 2)
            {
                tresure.SetActive(true);
            }
            if (Index == Sentences.Length - 1)
            {
                Debug.Log("Out");
                // Deactivate the game object
                DialogueText.text = "";
                thisthing.SetActive(false);
                onboarding.SetActive(true);
            }
            else
            {
                DialogueText.text = "";
                StartCoroutine(WriteSentence());
            }
        
        }
    }

    IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);

        }
        Index++;
    }
}
