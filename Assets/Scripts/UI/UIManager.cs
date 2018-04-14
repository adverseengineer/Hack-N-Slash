using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class UIManager : MonoBehaviour
{
    public Player player;
    private Transform miniMapCam;

    private Canvas HUDCanvas;
    private Canvas inventoryCanvas;

    private RectTransform playerInfoPane;
    private Text playerGold;
    private Text playerCarryWeight;

    void Awake()
    {
        if(player == null)
            throw new Exception("<color=red>no player is assigned</color>");

        miniMapCam = player.gameObject.transform.GetChild(1);
        if(miniMapCam == null)
            throw new Exception("<color=red>no mini map camera found on player</color");

        HUDCanvas = transform.GetChild(0).GetComponent<Canvas>();
        if(HUDCanvas == null)
            throw new Exception("<color=red>attached object is not a canvas</color>");

        inventoryCanvas = transform.GetChild(1).GetComponent<Canvas>();
        if(inventoryCanvas == null)
            throw new Exception("<color=red>attached object is not a canvas</color>");

        playerInfoPane = (RectTransform) inventoryCanvas.transform.GetChild(0);
        if(playerInfoPane == null)
            throw new Exception("<color=red>no player info pane found</color>");

        playerGold = playerInfoPane.GetChild(0).GetComponent<Text>();
        if(playerGold == null)
            throw new Exception("<color=red>no player gold text element found");

        playerCarryWeight = playerInfoPane.GetChild(1).GetComponent<Text>();
        if(playerCarryWeight == null)
            throw new Exception("<color=red>no player carry weight text element found");

        BuildInventory();
    }

    //hide the hud, mini map, and freeze the player
    void ToggleInventory()
    {
        HUDCanvas.enabled = !HUDCanvas.enabled;
        inventoryCanvas.enabled = !inventoryCanvas.enabled;
        miniMapCam.gameObject.SetActive(!miniMapCam.gameObject.activeSelf);
        player.gameObject.GetComponent<PlayerControl>().enabled = !player.gameObject.GetComponent<PlayerControl>().enabled;
        player.gameObject.GetComponent<MouseLook>().enabled = !player.gameObject.GetComponent<MouseLook>().enabled;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) ToggleInventory();
    }

    void BuildInventory()
    {
        playerGold.text = "Gold\n" + player.gold;
        playerCarryWeight.text = "Carry Weight\n" + player.currentCarryWeight + "/" + player.carryWeightLimit;
        foreach(Item item in player.inventory)
        {
            print(item.name + "\t<color=blue>" + item.value + "</color>\t<color=green>" + item.weight + "</color>");
        }
    }
}
