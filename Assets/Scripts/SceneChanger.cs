using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public Animator fadeAnim;
    public float fadeTime = .7F;
    //public Vector2 newPlayerPosition;
    //private Transform player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            //player = collision.transform;
            fadeAnim.Play("FadeToGray");
            StartCoroutine(DelayFade());
        }
    }

    //coroutine that lets us set the fade time of our transition, change the fadetime variable to adjust 
    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(fadeTime);
        //player.position = newPlayerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }
}
