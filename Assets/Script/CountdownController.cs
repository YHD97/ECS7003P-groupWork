using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject rules;
    public GameObject camera;
    public string cameraScriptName;
    public GameObject player;
    public string playerScript;
    // Start is called before the first frame update
    void Start()
    {
        if(GameSettings.ShowCountdownOnLevelStart)
        {
            (camera.GetComponent(cameraScriptName) as MonoBehaviour).enabled = false;
            (player.GetComponent(playerScript) as MonoBehaviour).enabled = false;
            StartCoroutine(CountdownToStart());
        } else {
            rules.SetActive(false);
        }
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        (camera.GetComponent(cameraScriptName) as MonoBehaviour).enabled = true;
        (player.GetComponent(playerScript) as MonoBehaviour).enabled = true;
        rules.SetActive(false);
        countdownDisplay.text = "MOVE NOW!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
