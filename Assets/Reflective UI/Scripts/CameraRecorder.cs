using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PomodoroGames.ReflectiveUI
{
    public class CameraRecorder : MonoBehaviour
    { 
        public static CameraRecorder Instance;
        
        [SerializeField] private bool useFrontCamera = false;
        
        private WebCamTexture webCamTexture;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            StartCoroutine(RequestCameraAccess());
        }

        private IEnumerator RequestCameraAccess()
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                WebCamDevice[] availableDevices = WebCamTexture.devices;

                if (webCamTexture == null)
                { 
                    webCamTexture = useFrontCamera ? new WebCamTexture(GetFrontCamera(),100,100, 20) :
                    new WebCamTexture(100,100, 20);
                }

                if (!webCamTexture.isPlaying)
                {
                    webCamTexture.Play();
                }
            }
        }

        public Color[] GetVerticalColor(Vector2 screenPosition)
        {
            if (webCamTexture == null || !webCamTexture.isPlaying) return null;
            
            try
            {
                Color[] averageColor = webCamTexture.GetPixels(Mathf.FloorToInt(screenPosition.x), Mathf.FloorToInt(screenPosition.y), 10, 10);
                if (averageColor == null) return null;
                Color topColor = Color.black;
                Color bottomColor = Color.black;
            
                for (int i = 0; i < averageColor.Length / 2; i++)
                {
                    topColor += averageColor[i] * averageColor[i];
                }

                for (int i = averageColor.Length / 2; i < averageColor.Length; i++)
                {
                    bottomColor += averageColor[i] * averageColor[i];
                }

                int halfColorLength = averageColor.Length / 2;
                topColor = new Color(Mathf.Sqrt(topColor.r / halfColorLength), Mathf.Sqrt(topColor.g / halfColorLength),
                    Mathf.Sqrt(topColor.b / halfColorLength));
                bottomColor = new Color(Mathf.Sqrt(bottomColor.r / halfColorLength), Mathf.Sqrt(bottomColor.g / halfColorLength),
                    Mathf.Sqrt(bottomColor.b / halfColorLength));

                Color[] colorData = new Color[] { topColor, bottomColor };
                return colorData;
            }
            catch (Exception exception)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Alert: This UI element is invisible, so reflective feature is disabled until become visible: " + gameObject.name);
#endif
                return null;
            }


        }

        public Color[] GetHorizontalColor(Vector2 screenPosition)
        {
            if (webCamTexture == null || !webCamTexture.isPlaying) return null;
            try
            {
                Color[] averageColor = webCamTexture.GetPixels(Mathf.FloorToInt(screenPosition.x), Mathf.FloorToInt(screenPosition.y), 10, 10);
                if (averageColor == null) return null;
                Color leftColor = Color.black;
                Color rightColor = Color.black;
            
                for (int i = 0; i < averageColor.Length; i++)
                {
                    if ((i / 5) == 0 || (i / 5) % 2 == 0)
                    {
                        leftColor += averageColor[i] * averageColor[i];
                    }
                    else
                    {
                        rightColor += averageColor[i] * averageColor[i];
                    }
                }

                int halfColorLength = averageColor.Length / 2;
            
                leftColor = new Color(Mathf.Sqrt(leftColor.r / halfColorLength), Mathf.Sqrt(leftColor.g / halfColorLength),
                    Mathf.Sqrt(leftColor.b / halfColorLength));
                rightColor = new Color(Mathf.Sqrt(rightColor.r / halfColorLength), Mathf.Sqrt(rightColor.g / halfColorLength),
                    Mathf.Sqrt(rightColor.b / halfColorLength));

                Color[] colorData = new Color[] { leftColor, rightColor };
                return colorData;
                
            }
            catch (Exception exception)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Alert: This UI element is invisible, so reflective feature is disabled until become visible: " + gameObject.name);
#endif
                return null;
            }
        }

        private string GetFrontCamera()
        {
            WebCamDevice[] availableDevices = WebCamTexture.devices;

            for (int i = 0; i < availableDevices.Length; i++)
            {
                if (availableDevices[i].isFrontFacing)
                {
                    return availableDevices[i].name;
                }
            }

            return availableDevices[0].name;
        }
        
    }
}

