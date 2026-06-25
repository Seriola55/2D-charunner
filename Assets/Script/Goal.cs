using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TMP_Text clearTimeText;
    public GameObject clearPanel;
    public AudioManager audioManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if(player != null)
            {
                if(audioManager != null)
                {
                    audioManager.PlayClear();
                }
                player.isClear =true;

                clearTimeText.text  = "TIME : "+ player.clearTime.ToString("F2");
            }
            Debug.Log("CLEAR");

            clearPanel.SetActive(true);
        }
    }


}
