using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public class StoryQuest
    {
        public readonly Dictionary<int, bool> QuestProgress = new();

        public void OpenQuest(int id)
        {
            QuestProgress[id] = false;
            PlayerHP.Instance.Show(StoryScripts.QuestNames[id]);
            PlayerHP.Instance.QuestName = StoryScripts.QuestNames[id];
        }

        public void ClearQuest(int id)
        {
            QuestProgress[id] = true;
            PlayerHP.Instance.Show(StoryScripts.QuestReward[id]);
            PlayerHP.Instance.QuestName = "";
        }
    }
    
    // 게임 데이터 관리
    public int savedStageId;
    public int savedHp;
    public int savedQuestId;
    
    public StoryQuest Quest = new();

    public void GameStart()
    {
        LoadData();
    }

    public void StageClear()
    {
        if (savedStageId >= 5)
        {
            SceneManagerEx.Instance.LoadScene(SceneType.Main);

            return;
        }

        savedStageId++;
        SaveData();
        SceneManagerEx.Instance.LoadScene((SceneType)savedStageId + 1);
    }

    public void GameOver()
    {
        
    }
    
    private void SaveData()
    {
        PlayerPrefs.SetInt("STAGE_ID", savedStageId);
        PlayerPrefs.SetInt("HP", savedHp);
        PlayerPrefs.SetInt("QUEST_ID", savedQuestId);
    }

    private void LoadData()
    {
        savedStageId = 1;
        savedHp = 4;
        savedQuestId = 0;
    }
}
