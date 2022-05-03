using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosManager : MonoBehaviour
{
    public static DinosManager Instance;

    public GameObject player;
    public List<DinoBase> dinos;


    private bool hasInformedOtherDino = false, hasLevelEnded;

    private void OnEnable()
    {
        Instance = this;
        NeoFPS.FpsGameMode.OnCharacterSpawnedEvent += FpsGameMode_OnCharacterSpawnedEvent;
    }

    private void FpsGameMode_OnCharacterSpawnedEvent(GameObject character)
    {
        player = character;
    }

    void Start()
    {
        HUD.Instance.UpdateDinoTargetCount(dinos.Count);
    }

    private void OnDisable()
    {
        Instance = null;
        NeoFPS.FpsGameMode.OnCharacterSpawnedEvent -= FpsGameMode_OnCharacterSpawnedEvent;
    }

    public void InformOthers(DinoBase dino)
    {
        if (hasInformedOtherDino)
        {
            return;
        }
        hasInformedOtherDino = true;
        foreach (var d in dinos)
        {
            if(d != dino)
            {
                d.OnOtherDinoHit();
            }
        }
    }

    public void DinoAttackedPlayer(DinoBase dino)
    {
        if (!hasLevelEnded)
        {
            hasLevelEnded = true;

            foreach (var d in dinos)
            {
                if (d != dino)
                {
                    d.StopDino(true);
                }
            }

            HUD.Instance.SetUIOnLevelEnd();
            Invoke("CallLevelFailed", 1);
        }
    }

    private void CallLevelFailed()
    {
        player.GetComponent<NeoFPS.BasicHealthManager>().AddDamage(120);
        HUD.Instance.OnPlayerDead();
        Invoke("ShowLevelFailed", 2);
    }

    public void DinoDied(DinoBase dino)
    {
        if (hasLevelEnded)
        {
            return;
        }
        if (dinos.Contains(dino))
        {
            dinos.Remove(dino);
        }
        HUD.Instance.UpdateDinoTargetCount(dinos.Count);
        if(dinos.Count == 0)
        {
            hasLevelEnded = true;
            HUD.Instance.SetUIOnLevelEnd();
            Invoke("ShowLevelComplete", 5);
        }
    }

    private void ShowLevelComplete()
    {
        GameManager.Instance.ChangeGameState(GameState.LEVEL_COMPLETE);
    }

    private void ShowLevelFailed()
    {
        GameManager.Instance.ChangeGameState(GameState.LEVEL_FAIL);
    }
}