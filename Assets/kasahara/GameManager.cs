
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�@�X�^�[�g�p�e�L�X�g�v���n�u
    [SerializeField]
    private GameObject textPrefab;
    [SerializeField]
    private TimeManager timeManager;

    private bool finished;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Goal()
    {
        finished = true;
        //�@�S�[���p�e�L�X�g�\��
        InstantiateMessage("ESCAPE�I�I");
        //�@�ō��^�C���̍X�V
        timeManager.UpdateFastestTime();
    }

    //�@�Q�[�����I���������ǂ���
    public bool IsFinished()
    {
        return finished;
    }

    //�@�Q�[�������b�Z�[�W��\��
    public void InstantiateMessage(string message)
    {
        var ins = Instantiate<GameObject>(textPrefab);
        ins.GetComponentInChildren<Text>().text = message;
    }
}
