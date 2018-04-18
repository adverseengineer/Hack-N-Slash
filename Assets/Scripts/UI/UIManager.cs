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

    private bool inventoryVisible = false;

	private bool horizontalAxisHasBeenUsedThisFrame = false;
	private bool verticalAxisHasBeenUsedThisFrame = false;

	public GameObject inventoryItemPrefab;
	private RectTransform itemContentPane;
    private RectTransform itemCategoryPane;
    private RectTransform itemCategoryCursor;
    private RectTransform[] itemCategoryIcons;

    private int selectedCategory = 0;
	private int selectedItem = 0;

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
        else
            inventoryCanvas.enabled = false;

        playerInfoPane = (RectTransform) inventoryCanvas.transform.GetChild(0);
        if(playerInfoPane == null)
            throw new Exception("<color=red>no player info pane found</color>");

        playerGold = playerInfoPane.GetChild(0).GetComponent<Text>();
        if(playerGold == null)
            throw new Exception("<color=red>no player gold text element found</color>");

        playerCarryWeight = playerInfoPane.GetChild(1).GetComponent<Text>();
        if(playerCarryWeight == null)
            throw new Exception("<color=red>no player carry weight text element found");

        itemCategoryPane = (RectTransform) inventoryCanvas.transform.GetChild(1);
        if(itemCategoryPane == null)
            throw new Exception("<color=red>no item category pane found</color>");

        itemCategoryIcons = new RectTransform[itemCategoryPane.childCount];
        if(itemCategoryIcons.Length == 0)
            throw new Exception("<color=red>item category icon array is empty</color>");
        else
            for(int i = 0; i < itemCategoryPane.childCount; i++)
                itemCategoryIcons[i] = (RectTransform) itemCategoryPane.GetChild(i);

        //the cursor starts as the child of the first column
        itemCategoryCursor = (RectTransform) itemCategoryIcons[0].GetChild(0);
        if(itemCategoryCursor == null)
            throw new Exception("<color=red>no item category cursor found</color>");

		itemContentPane = (RectTransform) inventoryCanvas.transform.GetChild(3).GetChild(0).GetChild(0);
		if(itemContentPane == null)
			throw new Exception("<color=red>scrolling panel not found</color>");

        BuildInventory();
    }

    //hide the hud, mini map, and freeze the player and cam
    void ToggleInventory()
    {
        inventoryVisible = true;
        HUDCanvas.enabled = !HUDCanvas.enabled;
        inventoryCanvas.enabled = !inventoryCanvas.enabled;
        miniMapCam.gameObject.SetActive(!miniMapCam.gameObject.activeSelf);
        player.gameObject.GetComponent<PlayerControl>().enabled = !player.gameObject.GetComponent<PlayerControl>().enabled;
        player.gameObject.GetComponent<MouseLook>().enabled = !player.gameObject.GetComponent<MouseLook>().enabled;
    }

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.R))
		{
			BuildInventory();
		}

        if(Input.GetButtonDown("Inventory"))
            ToggleInventory();

        if(inventoryVisible)
        {
            //horizontal changes the selected category, vertical changes the selected item
            //TODO: shift+scroll=switch between categories

            //HORIZONTAL (CATEGORY)
            if(Input.GetAxisRaw("Horizontal") != 0)
			{
                if(!horizontalAxisHasBeenUsedThisFrame)
                {
					selectedCategory += (int) Input.GetAxisRaw("Horizontal");
				    horizontalAxisHasBeenUsedThisFrame = true;
                }
			}
			else
				horizontalAxisHasBeenUsedThisFrame = false;

			selectedCategory = Mathf.Clamp(selectedCategory, 0, itemCategoryPane.childCount - 1);
			itemCategoryCursor.SetParent(itemCategoryIcons[selectedCategory], false);
            
			//VERTICAL (ITEM)
			if(Input.GetAxisRaw("Vertical") != 0)
			{
				if(!verticalAxisHasBeenUsedThisFrame)
				{
					selectedItem -= (int) Input.GetAxisRaw("Vertical");
					verticalAxisHasBeenUsedThisFrame = true;
				}
			}
			else
				verticalAxisHasBeenUsedThisFrame = false;

			print(selectedItem);
		}
    }

    void BuildInventory()
    {
		foreach (RectTransform child in itemContentPane)
		{
            Destroy(child);
        }
        playerGold.text = "Gold\n" + player.gold;
        playerCarryWeight.text = "Carry Weight\n" + player.currentCarryWeight + "/" + player.carryWeightLimit;
        foreach(Item item in player.inventory)
        {
            print(item.name + "\t<color=blue>" + item.value + "</color>\t<color=green>" + item.weight + "</color>");
			Instantiate(inventoryItemPrefab, itemContentPane);
        }
    }
}
