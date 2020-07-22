
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class Player : MonoBehaviour
{
    private float timeLeft = 120;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
        public int playerScore = 0;
    }

    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -20;

    void Update()
    {

        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer (9999999);
        }

        //
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("TIME "+ (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("SCORE " + playerStats.playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void DamagePlayer (int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.name == "HeadDetect")
        {
            playerStats.playerScore += 10;
        }
        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
            //GetComponent<PlatformerCharacter2D>().enabled = false;
            //GetComponent<Platformer2DUserControl>().enabled = false;
        }
        if (trig.gameObject.name == "Coin")
        {
            Destroy(trig.gameObject , 0.259f);
            playerStats.playerScore += 15;
        }
    }

    void CountScore()
    {
        playerStats.playerScore = playerStats.playerScore + (int)(timeLeft * 10);
        Debug.Log(playerStats.playerScore);
    }
}
