using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int politicsStat=6;
    public int moneyStat=2;
    public int trueStat=5;
    public int elisaStrikes=0;

    public bool newspaperTrigger;
    public bool resetMatasellos;
    public string verb;
    public TMP_InputField playerName, playerLastName;
    public TextMeshProUGUI playerCompleteName;
    public GameObject verbObject;
    public Animator anim;
    public Animator exitAnim;
    public List<string> verbList = new List<string>();
    //int[] verb;

    public GameObject[] days;
    public string[] options;
    public GameObject blackScreen;
    public int actualDay = 0;


    public GameObject matasellos;
    public GameObject sello;
    public Transform positionMatasellos;
    public Transform positionName;
    UpdateParameters updateParameters;
    EndingsManager endingsManager;

    public bool criticalEnding=false, alternativeEnding=false;

    private void Start()
    {
        days[actualDay].SetActive(true);
        options = new string[days.Length];
        instance = this;
        updateParameters = GetComponent<UpdateParameters>();
        endingsManager = GetComponent<EndingsManager>();

    }
    private void Update()
    {
        if (playerName.text != "" && playerLastName.text != "")
        {
            newspaperTrigger = true;
            anim.SetBool("moveUp", true);
        }
        else
        {
            newspaperTrigger = false;
            anim.SetBool("moveUp", false);
        }
        playerCompleteName.text = "Fdo.: " + playerName.text + " " + playerLastName.text;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitAnim.SetBool("up", !exitAnim.GetBool("up"));
        }
    }

    public void PublishNewsPaper(int _politics, int _money, int _true)
    {
        politicsStat += _politics;
        moneyStat += _money;
        trueStat += _true;
    }

    public void EditNewsPaper(string _verb,GameObject _verbObject)
    {
        verb = _verb;
        verbObject = _verbObject;
    }

    public void goToNextDay()
    {
        StartCoroutine(fadeToNextDay());
    }
    
    IEnumerator fadeToNextDay()
    {
        yield return new WaitForSeconds(1f);
        while (blackScreen.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color tmp = blackScreen.GetComponent<SpriteRenderer>().color;
            tmp.a += 0.006f;
            blackScreen.GetComponent<SpriteRenderer>().color = tmp;
            yield return null;
        }

        resetMatasellos = true;

        days[actualDay].SetActive(false);
        sello.SetActive(false);
        sello.transform.SetParent(matasellos.transform);
        sello.transform.localPosition = new Vector3(0, -1, 0);

        updateParameters.UpdateStats();
        Debug.Log(politicsStat+" "+
                moneyStat+" "+
                trueStat+" "+
                elisaStrikes);

        endingsManager.CriticalEndings();
        matasellos.transform.position = positionMatasellos.position;
        if (actualDay==7 && !criticalEnding){
            alternativeEnding = true;
            endingsManager.AlternativeEndings();
            playerCompleteName.gameObject.SetActive(false);
        }
        else if (!criticalEnding) {
            actualDay++;
            days[actualDay].SetActive(true);
            playerCompleteName.gameObject.SetActive(true);
            playerLastName.gameObject.SetActive(false);
            playerName.gameObject.SetActive(false);
        } else {
            playerCompleteName.gameObject.SetActive(false);
        }

        

        
        if (GameManager.instance.verbList.Count > 0)
        {
            verbList.RemoveAt(0);
        }

        while (blackScreen.GetComponent<SpriteRenderer>().color.a > 0)
        {
            Color tmp = blackScreen.GetComponent<SpriteRenderer>().color;
            tmp.a -= 0.006f;
            blackScreen.GetComponent<SpriteRenderer>().color = tmp;
            yield return null;
        }
        
    }


}
