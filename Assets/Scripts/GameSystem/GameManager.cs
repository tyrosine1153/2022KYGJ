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
            InGameCanvas.Instance.Show(StoryScripts.QuestNames[id]);
            InGameCanvas.Instance.QuestName = StoryScripts.QuestNames[id];
        }

        public void ClearQuest(int id)
        {
            QuestProgress[id] = true;
            InGameCanvas.Instance.Show(StoryScripts.QuestReward[id]);
            InGameCanvas.Instance.QuestName = "";
        }
    }
    
    // 게임 데이터 관리
    public int savedStageId;
    public int savedHp;
    public int savedQuestId;

    public CharacterController character;
    private bool _isGamePlaying;
    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            _hp = Mathf.Min(value, 5);
            if (_hp <= 0)
            {
                GameOver();
            }
        }
    }

    public readonly StoryQuest Quest = new();

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

    private void GameOver()
    {
        if(!_isGamePlaying) return;
        _isGamePlaying = false;
        character.Die();
        // Todo : Delay
        InGameCanvas.Instance.ShowOnDie();
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
