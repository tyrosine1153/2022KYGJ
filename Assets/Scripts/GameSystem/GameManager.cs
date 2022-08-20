using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 게임 데이터 관리
    public int savedStageId;
    public int savedHp;
    public int savedQuestId;

    public void GameStart()
    {
        LoadData();
        SceneManagerEx.Instance.LoadScene((SceneType)savedStageId + 1);
    }

    public void StageClear()
    {
        if (savedStageId >= 5)
        {
            // Todo : GameClear
            return;
        }

        savedStageId++;
        SaveData();
        SceneManagerEx.Instance.LoadScene((SceneType)savedStageId + 1);
    }
    
    private void SaveData()
    {
        PlayerPrefs.SetInt("STAGE_ID", savedStageId);
        PlayerPrefs.SetInt("HP", savedHp);
        PlayerPrefs.SetInt("QUEST_ID", savedQuestId);
    }

    private void LoadData()
    {
        savedStageId = PlayerPrefs.GetInt("STAGE_ID", 1);
        savedHp = PlayerPrefs.GetInt("HP", 4);
        savedQuestId = PlayerPrefs.GetInt("QUEST_ID", 0);
    }
}
