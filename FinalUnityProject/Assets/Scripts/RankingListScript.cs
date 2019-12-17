using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class RankingListScript : MonoBehaviour
{
    SQLWebClient sQLWebClient = new SQLWebClient();
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

    private bool show;

    // Start is called before the first frame update
    void Start()
    {
        entryTemplate.gameObject.SetActive(false);
        highScoreEntryList = new List<HighScoreEntry>();
        show = false;
    }

    public void CloseScreen()
    {
        ScreenManagerScript.Instance().PopScreen();
    }

    public void ShowRankingList()
    {
        int from_year = Int32.Parse(dateYearFromInput.text);
        int from_month = Int32.Parse(dateMonthFromInput.text);
        int from_day = Int32.Parse(dateDayFromInput.text);

        int to_year = Int32.Parse(dateYearToInput.text);
        int to_month= Int32.Parse(dateMonthToInput.text);
        int to_day = Int32.Parse(dateDayToInput.text);
        DateTime from = new DateTime(from_year, from_month, from_day);
        DateTime to = new DateTime(to_year, to_month, to_day);

        StartCoroutine(sQLWebClient.GetMatchesBetween(from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd")));
        show = true;
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformsList)
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

    public void ShowMyRankingList()
    {
        StartCoroutine(sQLWebClient.GetMatchesByPlayerID(GameLoader.playerID));
        show = true;
    }

    public void Update()
    {
        if (BackEndManager.Instance().IsMatchDataRecieved && show)
        {
            highScoreEntryList.Clear();
            foreach (var matchData in BackEndManager.Instance().matchDatas)
            {
                HighScoreEntry entry = new HighScoreEntry();
                entry.score = matchData.score;

                StartCoroutine(sQLWebClient.GetPlayerByID(matchData.playerdata_idplayerdata));
                if (BackEndManager.Instance().IsPlayerDataRecieved)
                {
                    entry.name = BackEndManager.Instance().playerData.username;
                    highScoreEntryList.Add(entry);
                }
            }
            show = false;
            highScoreEntryTransformList = new List<Transform>();
            foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
            {
                CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
            }
        }
    }
    private class HighScoreEntry { public int score; public string name; }
}