using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(LayoutGroup))]
public class MenuController : MonoBehaviour
{
    public MenuItem[] MenuItems;
    public GameObject MenuItemPrefab;
    
    private int selectedItem;
    private readonly List<MenuItemController> menuItemObjs = new();

    private void Start()
    {
        foreach (MenuItem item in MenuItems)
        {
            var uiObj = Instantiate(MenuItemPrefab, transform);
            var controller = uiObj.GetComponent<MenuItemController>();
            if (!controller)
            {
                Debug.LogError($"Unable to get menu item controller for {uiObj}");
                return;
            }
            controller.Init(item);
            menuItemObjs.Add(controller);
        }
        selectedItem = 0;
        menuItemObjs[selectedItem].Select();
    }

    private void Update()
    {
        int prevSelectedItem = selectedItem;

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            selectedItem -= 1;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            selectedItem += 1;
        }

        selectedItem = (selectedItem + MenuItems.Length) % MenuItems.Length;
        if (prevSelectedItem != selectedItem)
        {
            menuItemObjs[prevSelectedItem].Deselect();
            menuItemObjs[selectedItem].Select();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
        {
            menuItemObjs[selectedItem].Click();
        }
    }
}