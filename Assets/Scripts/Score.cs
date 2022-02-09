using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip diedSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = "Score  0";
    }

    // Update is called once per frame
    public void scoreHit(int scorePlus)
    {
        audioSource.PlayOneShot(diedSound);
        score += scorePlus;
        scoreText.text = "Score  " + score.ToString();
    }
}
