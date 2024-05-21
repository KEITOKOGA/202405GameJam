
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    public static float currentTime;
    private Text currentTimeText;
    private Text fastestTimeText;
    private static float fastestTime = 999.999f;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeText = transform.Find("Text").GetComponent<Text>();
        //�@�ő��^�C����\��
        fastestTimeText = transform.Find("Text").GetComponent<Text>();
        fastestTimeText.text = fastestTime.ToString("0.000");
    }

    // Update is called once per frame
    void Update()
    {
        //�@�S�[�����Ă��Ȃ���Ύ��Ԃ��v��
        if (!gameManager.IsFinished())
        {
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
        }
    }

    //�@�ō��^�C���̍X�V
    public void UpdateFastestTime()
    {
        if (currentTime < fastestTime)
        {
            fastestTime = currentTime;
        }
    }
}
