using Unity.VisualScripting;
using UnityEngine;

public class QuickScript_RemoveVelocityOfRigibodies : MonoBehaviour
{
    public GameObject[] m_targets;

    [ContextMenu("Remove Velocity")]
    public void RemoveVelocity()
    {
        foreach (GameObject target in m_targets)
        {
            Rigidbody [] rbs = target.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
    }

}
