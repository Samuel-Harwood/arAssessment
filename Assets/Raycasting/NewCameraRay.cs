using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCameraRay : MonoBehaviour
{
    [SerializeField] private Text _objectLabel;
    RaycastHit[] hits; 
    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        hits = Physics.RaycastAll(ray);
        if (Physics.Raycast(ray, out hit, 100000f))
        {
            if (hit.collider.tag.Equals("apple"))
            {
                if (hits.Length == 1)
                {
                    _objectLabel.text = $"1 apple Found";

                }
                else if (hits.Length == 2)
                {
                    _objectLabel.text = $"2 apples Found";

                }
                else if (hits.Length == 3)
                {
                    _objectLabel.text = $"3 apples Found";

                }
            }
        }
        else
        {
            _objectLabel.text = " ";
        }
    }
}
