
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;

    private bool finished;

    void Start()
    {

    }

    public void Goal()
    {
        finished = true;
        timeManager.UpdateFastestTime();
    }

    //@ƒQ[ƒ€‚ğI—¹‚µ‚½‚©‚Ç‚¤‚©
    public bool IsFinished()
    {
        return finished;
    }

}
