using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject GameEndingInfoPrefab;

    private Dictionary<GameEvent, int> _gameStates;
    private List<StoryLine> _storyLines;

    
    public void Start()
    {
        _gameStates = new Dictionary<GameEvent, int>();
        _storyLines = new List<StoryLine>();

        InitStorylines();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("PauseMenu(Clone)") == null)
        {
            Time.timeScale = 0;
            Instantiate(PauseMenu);
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            onNotify(GameEvent.wa_Weapon_Equipped);
            onNotify(GameEvent.wa_Weapon_Equipped, true);
            onNotify(GameEvent.pl_Cave_Entered);
        }
    }

    public void onNotify(GameEvent gameEvent)
    {
        UpdateGameState(gameEvent, false);
    }
    public void onNotify(GameEvent gameEvent, bool undo)
    {
        UpdateGameState(gameEvent, undo);
    }


    private void InitStorylines()
    {
        _storyLines.AddRange(new List<StoryLine>() {
            new StoryLine("Hibernation").AddChildren(
                new QuestNode().AddConditions(new List<QuestCondition>() {
                    new QuestCondition(GameEvent.pl_Cave_Entered, 1),
                    new QuestCondition(GameEvent.wa_Weapon_Equipped, 0)
                })
            ),
            new StoryLine("Darling Teddybear").AddChildren(
                new QuestNode()
                    .AddConditions(new QuestCondition(GameEvent.cr_BearGirl_TalkTo, 1))
            ),
            /*new StoryLine("Archbear of arcane magic").AddChildren(
                new QuestNode()
                    .AddConditions(new List<QuestCondition>() {
                        new QuestCondition(GameEvent.pl_GraveYard_Entered, 1),
                        new QuestCondition(GameEvent.cr_Witch_Killed, 1)
                    })
                    .AddChildren(
                        new QuestNode()
                            .AddConditions(new List<QuestCondition>() {
                                new QuestCondition(GameEvent.wa_Staff_Equipped, 1),
                                new QuestCondition(GameEvent.ob_MagicBook_Obtained, 1)
                            })
                    )
            ),*/
            new StoryLine("My preciousssss...").AddChildren(
                new QuestNode()
                    .AddConditions(new QuestCondition(GameEvent.ob_TheOneRing_Obtained, 1))
            ),
            /*new StoryLine("Captain Bluebear").AddChildren(
                new QuestNode().AddConditions(new List<QuestCondition>() {
                    new QuestCondition(GameEvent.ob_Alcohol_Obtained, 1)
                    }).AddChildren(new QuestNode().AddConditions(
                        new QuestCondition(GameEvent.cr_Captain_TalkedTo, 1)
                    ))
            ),
            new StoryLine("Captain Blackbear-d").AddChildren(
                new QuestNode().AddConditions(new List<QuestCondition>() {
                    new QuestCondition(GameEvent.ob_Alcohol_Obtained, 0),
                    new QuestCondition(GameEvent.cr_Captain_Killed, 1)
                })
            ),*/
            new StoryLine("Al Ca-paw-ne").AddChildren(
                new QuestNode().AddConditions(new List<QuestCondition>() {
                    new QuestCondition(GameEvent.cr_BanditBoss_Killed, 1)
                })
            )/*,
            new StoryLine("Found the right castle").AddChildren(
                new QuestNode()
                    .AddConditions(new List<QuestCondition>() {
                        new QuestCondition(GameEvent.cr_Knight_Killed, 1),
                        new QuestCondition(GameEvent.we_KnightsArmor_Equipped, 1)
                    })
                    .AddChildren(
                        new QuestNode()
                            .AddConditions(new List<QuestCondition>() {
                                new QuestCondition(GameEvent.pl_WizardTower_Entered, 1),
                                new QuestCondition(GameEvent.cr_Wizard_Killed, 1)
                            })
                    )
            )*/
        });
    }
    private void UpdateGameState(GameEvent gameEvent, bool undo)
    {
        if (!undo && !_gameStates.ContainsKey(gameEvent))
            _gameStates.Add(gameEvent, 1);
        else
            _gameStates[gameEvent] += (undo ? -1 : 1);

        CheckStoryLines();
    }
    private void CheckStoryLines()
    {
        bool win = false;
        StoryLine finished = new StoryLine("");

        foreach (var s in _storyLines)
        {
            if (s.HasFinished(_gameStates))
            {
                win = true;
                finished = s;
                break;
            }
        }

        if (win)
        {
            Instantiate(GameEndingInfoPrefab);
            var g = GameObject.Find("GameEndingInfo(Clone)");
            g.GetComponent<GameEndingInfo>().Ending = "Ending: " + finished.Name;
            Application.LoadLevel("GameOver");
        }
    }
    
}
