using UnityEngine;

public class QuickScript_Genocide : MonoBehaviour
{
    [ContextMenu("Genocide")]
    public void Genocide() {

        GameObject[] objs = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach(GameObject obj in objs) {
            QuickScript_MoveTowardPlayer[] scripts = obj.GetComponents<QuickScript_MoveTowardPlayer>();
           
            if(scripts.Length > 0)
            {

                Destroy(obj, 0.1f);    
            }
        }
    }


    [ContextMenu("Kill All Building")]
    public void KillAllBuilding() {
        GameObject[] objs = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject obj in objs)
        {
            HandLoaderMono_SleepyMoveMapToHandsPositions[] scripts = obj.GetComponents<HandLoaderMono_SleepyMoveMapToHandsPositions>();

            if (scripts.Length > 0)
            {
                Destroy(obj, 0.1f);
            }
        }

    }

}
