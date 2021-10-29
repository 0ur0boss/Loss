using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRiddle : MonoBehaviour
{
    [SerializeField] AudioClip winMusic;
    AudioSource audio1;
    [SerializeField] List<int> solution; // 1 4 3 6        4
    List<int> currentAnswer; // 1 4 3 5 6 7 5 1 4 3 6     11
    public ligthWin ligthwin;
    public HealthPlayer healthplayer;
    void Start()
    {
        currentAnswer = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckSolution())
        {
            Win();
        }
    }

    public void AddRiddleAnswer(int answer)
    {
        currentAnswer.Add(answer);
    }

    public bool CheckSolution()
    {
        if (solution.Count > currentAnswer.Count)
        {
            return false;
        } else
        {
            bool isGood = true;
            for (int i = 0; i < solution.Count; i++)
            {
                if (solution[i] != currentAnswer[currentAnswer.Count - solution.Count + i])
                {
                    isGood = false;
                }
            }
            return isGood;
        }
       
    }

    public void Win()
    {
        Debug.Log("win");
        //gameObject.GetComponent<AudioSource> ().Play ();
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = winMusic;
        audio.Play();
        ligthwin.WinCondi();
        healthplayer.domage = 0;
        currentAnswer.Clear();

    }
}
