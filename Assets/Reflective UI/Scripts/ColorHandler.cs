using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PomodoroGames.ReflectiveUI
{
    public enum ColorHandleType
    {
        Vertical,
        Horizontal
    }
    
    public abstract class ColorHandler : MonoBehaviour
    {
        protected CameraRecorder cameraRecorder;
        
        [SerializeField] protected ColorHandleType colorHandleType = ColorHandleType.Vertical;
        
        protected Vector2 screenPosition = Vector2.zero;
        private Vector3 centerPosition = Vector3.zero;
        private RectTransform rectTransform;
        private Vector3[] cornerPositions = new Vector3[4];

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            UpdateScreenPosition();

            if (cameraRecorder != null)
            {
                if (colorHandleType == ColorHandleType.Vertical)
                {
                    HandleVerticalColorGradient();
                }
                else
                {
                    HandleHorizontalColorGradient();
                }
            }
            
        }

        protected void UpdateScreenPosition()
        {
            rectTransform.GetWorldCorners(cornerPositions);
            centerPosition = Vector3.zero;

            for (int i = 0; i < 4; i++)
            {
                centerPosition += cornerPositions[i];
            }

            centerPosition /= 4.0f;

            screenPosition.x = centerPosition.x / Screen.width;
            screenPosition.y = centerPosition.y / Screen.height;
        }
    
        protected virtual void HandleVerticalColorGradient() { }
    
        protected virtual void HandleHorizontalColorGradient() { }
        
    }
}

