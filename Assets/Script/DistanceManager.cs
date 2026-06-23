using UnityEngine;
using TMPro;
public class DistanceManager : MonoBehaviour
{
    public Transform player;
    public TMP_Text distanceText;
    public TMP_Text bestDistanceText;

    float startX;
    float distance;
    float bestDistance;
    
    void Start()
    {
        startX= player.position.x;
        bestDistance = PlayerPrefs.GetFloat("BestDistance", 0f);

        if(bestDistanceText != null)
        {
            bestDistanceText.text = "BEST : "  + bestDistance.ToString("F0") +"m";
        }
    }

    void Update()
    {
        distance = player.position.x - startX;
        if(distanceText != null)
        {
            distanceText.text = distance.ToString("F0") + "m";
        }
        
        if(distance > bestDistance)
        {
            bestDistance = distance;
            PlayerPrefs.SetFloat("BestDistance",bestDistance);
            PlayerPrefs.Save();

            if(bestDistanceText != null)
            {
                bestDistanceText.text = "BEST : "  + bestDistance.ToString("F0") +"m";
            }
        }
    }
}
