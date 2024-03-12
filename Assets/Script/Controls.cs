using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask _layer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var _hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), _camera.ScreenPointToRay(Input.mousePosition).direction, _layer);

            if (_hit)
            {
                _hit.transform.GetComponent<IClickable>().OnClick();
            }
        }
    }
}