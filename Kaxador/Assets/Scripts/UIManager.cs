using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ChangeTimer("");
	}

    public void ChangeTimer(string str)
    {
        var text_object = GameObject.Find("Select_Time").GetComponent<TextMesh>();
        text_object.text = str;
    }
}
