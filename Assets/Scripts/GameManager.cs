using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Make this a singleton, makes sure there is only ever one and makes it easy for 
    //other scripts to interact
    public static GameManager Instance;

    [Header("Persistant Objects")]
    //makes an array of our objects that will persist to the next scene
    public GameObject[] persistentObjects;

    private void Awake ()
    {
        //if there is an instance of the game manager, run the cleanup and destroy function 
        //ELSE set the current object to be the instance and call the DontDestroyOnLoad function, then the MarkPersistentObjects function
        if ( Instance != null )
        {
            CleanUpAndDestroy();
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjects();
        }
    }

    //Uses a foreach to go through the objects in our array of game objects which are selected in unity 
    //if the slot the loop looks has something in it, that object is marked as DontDestroyOnLoad
    private void MarkPersistentObjects()
    {
        foreach ( GameObject obj in persistentObjects )
        {
            if ( obj != null )
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    //foreach loop that goes through the objects in or array and destroys them, effectively destroying duplicate objects
    private void CleanUpAndDestroy()
    {
        foreach ( GameObject obj in persistentObjects )
        {
            Destroy(obj);
        }

        Destroy(gameObject);
    }
}
