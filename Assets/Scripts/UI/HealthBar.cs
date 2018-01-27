using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{

    public GameObject[] healthSprites;
    public GameObject healthPanel;

    public void SetHp(int HP)
    {
        if (HP == 0)
        {
            Camera.main.GetComponent<MamaSpawner>().Spawn();
        }

        foreach (Transform child in healthPanel.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < HP; i++)
        {
            Instantiate(healthSprites[i], healthPanel.transform);
        }


    }

}
