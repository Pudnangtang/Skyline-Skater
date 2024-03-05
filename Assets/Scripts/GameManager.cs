using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool PlayerHasItem;

    public int RemainingTime = 5;

    public TMP_Text CountdownUI;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHasItem == true)
        {
            print("Player has all items");
        }
    }

    public void LoadGoodScene()
    {
        print("Load good scene");
    }

    public void LoadBadScene()
    {
        SceneManager.LoadScene("TimeUp");
    }

    private IEnumerator CountDown()
    {
       while(true)
        {
            CountdownUI.text = RemainingTime.ToString();
            if (RemainingTime == 0)
            {
                LoadBadScene();
            }

            yield return new WaitForSeconds(1);

           if(RemainingTime > 0) 
            {
                RemainingTime = RemainingTime - 1;
                print(RemainingTime);
            }
        }
    }
}
