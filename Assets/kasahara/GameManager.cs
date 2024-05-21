
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
        InstantiateMessage("�Q�[���X�^�[�g");
    }

    public void Goal()
    {
        finished = true;
        //�@�S�[���p�e�L�X�g�\��
        InstantiateMessage("�S�[���I�I");
        //�@�ō��^�C���̍X�V
        timeManager.UpdateFastestTime();
        StartCoroutine(ReStart());
    }

    //�@�Q�[�����I���������ǂ���
    public bool IsFinished()
    {
        return finished;
    }

    //�@�Q�[���̃��X�^�[�g
    IEnumerator ReStart()
    {
        //�@3�b��Ƀ��X�^�[�g
        yield return new WaitForSeconds(3f);
        //�@���݂̃V�[�����ēǂݍ���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //�@�Q�[�������b�Z�[�W��\��
    public void InstantiateMessage(string message)
    {
        var ins = Instantiate<GameObject>(textPrefab);
        ins.GetComponentInChildren<Text>().text = message;
    }
}
