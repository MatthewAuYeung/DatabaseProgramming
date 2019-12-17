using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WebClient : MonoBehaviour
{
    public abstract IEnumerator GetPlayerByUsername(string username);
    public abstract IEnumerator GetPlayerByID(int id);
    public abstract IEnumerator UpdatePlayerProfile(PlayerData player);
    public abstract IEnumerable DeletePlayer(string username);
    public abstract IEnumerator AddPlayer(PlayerData player);

    public abstract IEnumerator GetMatchesByPlayerID(int player_id);
    public abstract IEnumerator GetMatchesBetween(string from_date, string to_date);
    public abstract IEnumerable DeleteMatch(int player_id);
    public abstract IEnumerator AddMatch(MatchData match);
}
