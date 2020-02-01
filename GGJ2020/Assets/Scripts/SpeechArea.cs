using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechArea : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string text;

    [SerializeField] private GameObject backImage;
    private bool isShown;

    private void Start()
    {
        backImage.SetActive(false);

        GetComponentInChildren<TMP_Text>().text = "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player") && !isShown)
        {
            Debug.Log("Player");
            //backImage.SetActive(true);
            isShown = true;
            StartCoroutine(TypeText(GetComponentInChildren<TMP_Text>()));
        }
    }

    private IEnumerator TypeText(TMP_Text tmpText)
    {
        foreach (var letter in text)
        {
            tmpText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
