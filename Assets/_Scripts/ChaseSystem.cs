using System.Collections;
using UnityEngine;

public class ChaseSystem : MonoBehaviour, IChase
{
    [SerializeField] private Transform resetPoint;
    [SerializeField] private CameraController camController;
    [SerializeField] private StressReceiver stressReceiver;
    [SerializeField] private float chaseSpeed = 3.5f;
    [SerializeField] private Animator chaseAnimation;
    [SerializeField] private GameObject deathZoneFallBehind;
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
            camController.CameraState(true);
        }
        else
        {
            camController.CameraState(false);
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
        deathZoneFallBehind.SetActive(true);
        yield return new WaitForSeconds(1);
        stressReceiver.TraumaExponent = 0f;
        stressReceiver.InduceStress(1f);
        yield return new WaitForSeconds(3);
        stressReceiver.TraumaExponent = 1f;
        //haseAnimation.enabled = true;
        yield return new WaitForSeconds(2);

        camController.CameraState(false);
        camController.AutoScrollLeft(chaseSpeed);
        camController.SetLocationOffset(new Vector3(-2, -1, -10));
    }

    public void ResetChase()
    {
        isChasing = false;
        deathZoneFallBehind.SetActive(false);
        camController.CameraState(true);
        camController.transform.position = new Vector3(resetPoint.position.x, resetPoint.position.y, -10);
        LevelManager.Instance.player.transform.position = resetPoint.position;

        StartChase();
    }
}
