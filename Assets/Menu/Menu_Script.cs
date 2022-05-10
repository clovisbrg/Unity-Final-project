using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{

    public AudioClip MenuTheme, click;
    protected AudioSource ref_audiosource1, ref_audiosource2;
    // Start is called before the first frame update
    void Start()
    {
        ref_audiosource1 = gameObject.AddComponent<AudioSource>();
        ref_audiosource2 = gameObject.AddComponent<AudioSource>();

        ref_audiosource1.clip = MenuTheme;
        ref_audiosource2.clip = click;

        ref_audiosource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //each method is linked to a button and starts its own coroutine
    public void loadApple_Catcher()
    {
        StartCoroutine(LoadScene_AppleCatcher() );
    }
    public void loadBrickBreaker()
    {
        StartCoroutine(LoadScene_BrickBreaker());
    }
    public void loadFurapiBird()
    {
        StartCoroutine(LoadScene_FurapiBird());
    }

    IEnumerator LoadScene_AppleCatcher()
    {
        //Stop music and play the exit sound
        ref_audiosource1.Pause();
        ref_audiosource2.Play();

        //Wait for that sound to end
        yield return new WaitForSeconds(1f);

        //Load game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    IEnumerator LoadScene_BrickBreaker()
    {
        //Stop music and play the exit sound
        ref_audiosource1.Pause();
        ref_audiosource2.Play();

        //Wait for that sound to end
        yield return new WaitForSeconds(1f);

        //Load game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BrickBreaker_scene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    IEnumerator LoadScene_FurapiBird()
    {
        //Stop music and play the exit sound
        ref_audiosource1.Pause();
        ref_audiosource2.Play();

        //Wait for that sound to end
        yield return new WaitForSeconds(1f);

        //Load game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FurapiBird");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
