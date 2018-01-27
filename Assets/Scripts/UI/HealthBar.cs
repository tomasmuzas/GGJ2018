using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{

    public GameObject[] healthSprites;
    public GameObject healthPanel;


    private void Start()
    {
        SetHp(3);
    }

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
