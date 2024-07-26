using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ChaseSystem : MonoBehaviour
{
    [SerializeField] private CameraController camController;
    [SerializeField] private StressReceiver stressReceiver;
    [SerializeField] private float chaseSpeed = 3.5f;
    [SerializeField] private Animator chaseAnimation;
    [SerializeField] private float  stopPoint = 0;
    private bool isChasing;

    private void Update()
    {
        if(!isChasing)
        {
            return;
        }

        if (camController.transform.position.x <= stopPoint)
        {
            camController.enabled = false;
        }
        else
        {
            camController.enabled = true;
        }
    }

    [ContextMenu("StartChase")]
    public void StartChase()
    {
        isChasing = true;
        StartCoroutine(ChaseSequence());
    }

    private IEnumerator ChaseSequence()
    {
        yield return new WaitForSeconds(1);
        stressReceiver.TraumaExponent = 0f;
        stressReceiver.InduceStress(1f);
        yield return new WaitForSeconds(3);
        stressReceiver.TraumaExponent = 1f;
        chaseAnimation.enabled = true;
        yield return new WaitForSeconds(2);

        camController.AutoScrollLeft(chaseSpeed);
        camController.SetLocationOffset(new Vector3(-2, 0, -10));
    }

    public void ResetChase()
    {

    }
}
