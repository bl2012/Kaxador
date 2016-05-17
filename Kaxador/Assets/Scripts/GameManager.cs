using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public string[] scenes;
	private static GameManager firstInstance = null;

    private int roomZ = 0;
    private int roomX = 0;
    private int roomY = 0;

    private GameObject player;

    public bool paused = false;
    private GameObject PauseM;


    //-----------------Level Setup------------------------
    void Awake() // implement singleton
	{
		if (firstInstance == null)
			firstInstance = this;
		else if (firstInstance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

        player = GameObject.FindGameObjectWithTag("Player");

        paused = false;
	}
    
    void OnLevelWasLoaded()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    //-----------------Manage the Level-------------------

    public void PauseGame()
    {
        paused = !paused;

        if(paused)
        { 

            PauseM = GameObject.Instantiate(Resources.Load("llamasrevenge_Pause(Arcade)")) as GameObject;
        }
        else
        {
            if (PauseM != null)
                Destroy(PauseM);
        }
    }

    public void Move(string dir)
    {
        player.GetComponent<Animator>().SetTrigger(dir);
    }

    public coordinates getCoordinates()
    {
        return new coordinates(roomX, roomY, roomZ);
    }

    //------------------End the Level---------------------

    

	//---------------Scene Navigation---------------------

	public void loadScene(string sceneName)
	{
		var found = false;

		foreach (string Str in scenes) {
			if(Str.Equals(sceneName))
			{
				found = true;
				break;
			}
		}

		if (found)
			Application.LoadLevel (sceneName);
		else if(sceneName == "quit")
        {
            QuitGame();
        }
        else
			Debug.Log ("Level " + sceneName + " not found");
	}

	public void loadScene(int sceneIndex)
	{
		if (sceneIndex >= scenes.Length || sceneIndex < 0)
			sceneIndex = 0;

		Application.LoadLevel (sceneIndex);

	}

    public void QuitGame()
    {
        Application.Quit();
    }
}

public class coordinates
{
    int x;
    int y;
    int z;

    public coordinates(int newX, int newY, int newZ)
    {
        x = newX;
        y = newY;
        z = newZ;
    }

}