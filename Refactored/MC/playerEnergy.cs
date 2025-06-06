using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEnergy : MonoBehaviour
{
    private float playerEnergy;
    private float playerMaxEnergy;
    private float playerEnergyRegen;
    private bool energyRegenerating = false;

    private energyBarAdjuster energyBar;

    public void consumePlayerEnergy(float energy)
    {
        if (playerEnergy > 0)
        {
            playerEnergy -= energy;
            energyBar.setEnergy(playerEnergy);
        }
    }

    public IEnumerator regenPlayerEnergy()
    {
        while (playerEnergy < playerMaxEnergy && energyRegenerating == true)
        {
            yield return new WaitForSeconds(1);
            playerEnergy += playerEnergyRegen;
            energyBar.setEnergy(playerEnergy);
        }
        energyRegenerating = false;
    }

    void StartEnergy()
    {
        playerEnergy = playerMaxEnergy;
        energyBar.setMaxEnergy(playerMaxEnergy);
    }

    void UpdateEnergy()
    {
        if(playerEnergy > playerMaxEnergy)
        {
            playerEnergy = playerMaxEnergy;
        }
        
        if(playerEnergy != playerMaxEnergy && energyRegenerating == false)
        {
            energyRegenerating = true;
            StartCoroutine(regenEnergy());
        }
    }
}