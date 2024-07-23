using UnityEngine;

public class CameraShakeTest : MonoBehaviour
{
    [SerializeField] private StressReceiver stressReceiver;
    [SerializeField] private float stressLevel = 0.5f;
    [ContextMenu("Test")]
    private void Test()
    {
        stressReceiver.InduceStress(stressLevel);
    }
}
