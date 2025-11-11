using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace GenshinImpactMovement
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] [Range(0f,10f)]private float defaultDistance = 6f;
        [SerializeField] [Range(0f,10f)]private float minDistance = 1f;
        [SerializeField] [Range(0f,10f)]private float maxDistance = 6f;

        [SerializeField] [Range(0f,10f)]private float smoothing = 6f;
        [SerializeField][Range(0f, 10f)] private float zoomSensitivity = 6f;

        private CinemachineFramingTransposer framingTransposer;
        private CinemachineInputProvider inputProvider;
        private float currentTargetDistance;

        private void Awake()
        {
            framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
            inputProvider = GetComponent<CinemachineInputProvider>();
            currentTargetDistance = defaultDistance;
        }

        private void Update()
        {
            Zoom();
        }

        private void Zoom()
        {
            float zoomValue = inputProvider.GetAxisValue(2) * zoomSensitivity;
            currentTargetDistance = Mathf.Clamp(currentTargetDistance + zoomValue, minDistance, maxDistance);
            float currentDistance = framingTransposer.m_CameraDistance;
            if (currentDistance == currentTargetDistance) return;
            float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, Time.deltaTime * smoothing);
            framingTransposer.m_CameraDistance = lerpedZoomValue; 
        }
    }
}
