using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class RankingListScript : MonoBehaviour
{
    public InputField dateYearFromInput;
    public InputField dateMonthFromInput;
    public InputField dateDayFromInput;
    public InputField dateYearToInput;
    public InputField dateMonthToInput;
    public InputField dateDayToInput;

    public Transform entryTemplate;
    public Transform entryContainer;

    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    // Start is called before the first frame update
    void Start()
    {
        entryTemplate.gameObject.SetActive(false);
        dateYearFromInput = GetComponent<InputField>();
        dateMonthFromInput = GetComponent<InputField>();
        dateDayFromInput = GetComponent<InputField>();
        dateYearToInput = GetComponent<InputField>();
        dateMonthToInput = GetComponent<InputField>();
        dateDayToInput = GetComponent<InputField>();
    }

    public void CloseScreen()
    {
        ScreenManagerScript.Instance().PopScreen();
    }

    public void ShowRankingList()
    {
        //do somethuing;
        //DateTime date = DateTime.Now;
        //string ss =  date.ToString("yyyy-MM-dd");

        highScoreEntryList = new List<HighScoreEntry>()
        {
             new HighScoreEntry{score=1032,name="nesdcil"},
             new HighScoreEntry{score=1035,name="nexzvil"},
             new HighScoreEntry{score=1037,name="newzxcil"},
             new HighScoreEntry{score=10372,name="neczcil"},
             new HighScoreEntry{score=1032,name="nedasil"},
             new HighScoreEntry{score=10332,name="ne42il"},
             new HighScoreEntry{score=10932,name="neewqil"},
             new HighScoreEntry{score=11032,name="nesdawil"},
             new HighScoreEntry{score=10032,name="neasdail"},
             new HighScoreEntry{score=102232,name="fdsd"},
        };
        //for (int i = 0; i < highScoreEntryList.Count(); i++)
        //{
        //    for (int j = 0; j < highScoreEntryList.Count(); j++)
        //    {
        //        if (highScoreEntryList[j].score<highScoreEntryList[i].score)
        //        {
        //            HighScoreEntry temp = highScoreEntryList[i];
        //            highScoreEntryList[i] = highScoreEntryList[j];
        //            highScoreEntryList[j] = temp;
        //        }
        //    }
        //}
        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container,List<Transform>transformsList )
    {
        float templateHeight = 25f;
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformsList.Count());
            entryTransform.gameObject.SetActive(true);
            int rank = transformsList.Count() + 1;
            entryTransform.Find("PosText").GetComponent<Text>().text = rank.ToString();
            int score = highScoreEntry.score;
            entryTransform.Find("NameText").GetComponent<Text>().text = score.ToString();
            string name = highScoreEntry.name;
            entryTransform.Find("ScoreText").GetComponent<Text>().text = name;
            transformsList.Add(entryTransform);
    }

    private class HighScoreEntry { public int score; public string name; }
}