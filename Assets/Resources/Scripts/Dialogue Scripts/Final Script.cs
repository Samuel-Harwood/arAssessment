using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FinalScript : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences1;
    private int Index = 0;
    public float DialogueSpeed;
    private Touch theTouch;
    public GameObject thisthing;
    // public GameObject onboarding;
    public GameObject treasure;
    public AudioSource source;
    public AudioClip clip;
    public GameObject confettiCannon;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            // Check if the touch phase is ended
            if (theTouch.phase == TouchPhase.Ended)
            {
                NextSentence1();
            }
        }
    }

    void NextSentence1()
    {
        if (Index <= Sentences1.Length - 1)
        {
            if (Index == Sentences1.Length - 2)
            {
                treasure.SetActive(false);
            }

            if (Index == Sentences1.Length - 1)
            {
                Debug.Log("Out");
                // Deactivate the game object
                DialogueText.text = "";
                confettiCannon.SetActive(true);
                thisthing.SetActive(false);


            }
            else
            {
                DialogueText.text = "";
                StartCoroutine(WriteSentence1());
            }

        }

    }

    IEnumerator WriteSentence1()
    {
        foreach (char Character in Sentences1[Index].ToCharArray())
        {
            source.PlayOneShot(clip);
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);

        }
        Index++;
    }
}