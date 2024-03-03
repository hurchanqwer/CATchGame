using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public int score = 0;
    
    Text ScoreText;
    AudioSource audioSource;
    public GameObject image;
    // Start is called before the first frame update

    private void Awake()
    {
        ScoreText= transform.GetComponent<Text>();
        audioSource = transform.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        if (score == 10 && !image.activeSelf)
        {
            image.SetActive(true);
            audioSource.Play();


        }
        
        ScoreText.text = score + " / 10 ";

    }
}
