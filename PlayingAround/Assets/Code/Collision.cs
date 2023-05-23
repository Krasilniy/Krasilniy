using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] AudioClip Crush;
    [SerializeField] AudioClip Winingg;
    [SerializeField] ParticleSystem Wn;
    [SerializeField] ParticleSystem Csh;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Collision")
        {
            Losing();
        }
        if (collision.gameObject.tag == "Finish")
        {
            Wining();
        }
    }

    void Wining()
    {
        audioSource.PlayOneShot(Winingg);
        Wn.Play(Wn);
        Invoke("NextLevel", 2f);
    }
    void Losing()
    {
        audioSource.PlayOneShot(Crush);
        Csh.Play();
        Invoke("Restart", 2f);
    }


    void NextLevel()
    { 
        int SceneCount = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneCount == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            SceneCount = 0;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneCount);
    }

    void Restart()
    {
        audioSource.PlayOneShot(Crush);
        int SceneCount = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneCount);
    }
}
