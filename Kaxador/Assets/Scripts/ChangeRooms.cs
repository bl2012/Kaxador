using UnityEngine;
using System.Collections;

public class ChangeRooms : MonoBehaviour {
    public string dir;
    public bool active;
    private float click_timer = 5;
    private float click_time_elapsed = 0;
    private GameManager gameManger;
    private UIManager uiManager;

	void Start()
    {
        active = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void OnMouseEnter()
    {
        switchActive();
        click_time_elapsed = 0;
    }

    void OnMouseOver()
    {
        if((click_timer - click_time_elapsed) >= 0)
            uiManager.ChangeTimer(Mathf.RoundToInt(click_timer - click_time_elapsed).ToString());

        if (click_time_elapsed >= click_timer)
            gameManger.Move(dir);

        click_time_elapsed += Time.deltaTime;

    }

    void OnMouseExit()
    {
        switchActive();
        uiManager.ChangeTimer("");
    }

    void OnMouseDown()
    {
        gameManger.Move(dir);
    }



    private void switchActive()
    {
        active = !active;
        var arr = gameObject.transform.GetChild(0).gameObject;
        var dir_text = gameObject.transform.GetChild(1).gameObject;

        if(active)
        {
            arr.SetActive(true);
            dir_text.SetActive(true);
        }
        else
        {
            arr.SetActive(false);
            dir_text.SetActive(false);
        }
    }
}
