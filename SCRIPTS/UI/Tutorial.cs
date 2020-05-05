using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public Text helpText;
    public float timer;
    public GameObject[] items;
    private string[] tipsText;

    void Start () {
        tipsText = new string[7];

        tipsText[0] = "Welcome to\nLight Trails";
        tipsText[1] = "Follow the Pulsing Trail";
        tipsText[2] = "This is your Attempts\nand your Best Attempts";
        tipsText[3] = "Click here to\nReveal the Trail!";
        tipsText[4] = "Or choose to\nSkip a Level";
        tipsText[5] = "Click here to\nReturn to the Menu";
        tipsText[6] = "Have fun!!!";

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }

        if (helpText.gameObject != null)
        {
            StartCoroutine(NextStep(timer));
        }
    }

    IEnumerator NextStep (float wait) {
        for (int i = 0; i < tipsText.Length+items.Length+1; i++)
        {
            if (tipsText.Length > i)
            {
                helpText.text = tipsText[i];
            }
            yield return new WaitForSeconds(wait);

            switch (i)
            {
                case 1:
                    items[0].SetActive(true);
                    break;
                case 2:
                    items[1].SetActive(true);
                    break;
                case 3:
                    items[2].SetActive(true);
                    break;
                case 4:
                    items[3].SetActive(true);
                    break;
                case 5:
                    break;
                case 6:
                    SceneManager.LoadScene("LEVEL 1");
                    break;
            }
        }
        yield return new WaitForSeconds(wait);

	}
}
