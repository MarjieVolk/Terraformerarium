using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject menuPrefab;

    private GameObject menu;
    
	void Update () {
		if (SceneManager.GetActiveScene().name != "Menu" && Input.GetKeyUp(KeyCode.Escape))
        {
            if (menu == null)
                menu = UIManager.Obj.OpenPopup(menuPrefab);
            else
                Destroy(menu);
        }
	}
}
