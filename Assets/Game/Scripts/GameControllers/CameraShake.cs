using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    Quaternion currentRotation;
    [SerializeField] private Transform transform;

    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void CameraShaker(float intensity, float timeShake)
    {
        StartCoroutine(PerformCameraShaker(intensity, timeShake));
        currentRotation.eulerAngles = new Vector3(0,0,0);
        transform.rotation = currentRotation;
    }

    IEnumerator PerformCameraShaker(float intensity, float timeShake)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(timeShake);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        yield return null;
    }
}

