using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        ObjectCollide.OnSubjectEntered += ObjectCollide_OnSubjectEntered;

        // Bonus
        string CountKey = "Number of collided";
        string CountKeyFlag = CountKey + "flag";
        PlayerPrefs.SetInt(CountKeyFlag, 0);
    }

    private void ObjectCollide_OnSubjectEntered(ObjectCollide objectCollide)
    {
        string individualKey = "Individual Achievement " + objectCollide.ObjName;
        if (PlayerPrefs.GetInt(individualKey) == 1)
            return;
        PlayerPrefs.SetInt(individualKey, 1);
        Debug.Log("Achivement " + objectCollide.ObjName);

        // Bonus
        string CountKey = "Number of collided";
        string CountKeyFlag = CountKey + "flag";
        int count = PlayerPrefs.GetInt(CountKey);
        count++;
        PlayerPrefs.SetInt(CountKey, count);
        if (count > 5 && PlayerPrefs.GetInt(CountKeyFlag) == 0)
        {
            Debug.Log("Collide more than 5 achieved");
            PlayerPrefs.SetInt(CountKeyFlag, 1);
        }
    }
}
