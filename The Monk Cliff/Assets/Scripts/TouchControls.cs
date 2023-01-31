using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour
{
    // ...

    private GameObject selectedMonk;
    private MonkState selectedWorkplace;

    private void Update()
    {
        // Check if a touch event has occurred
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch event was a tap
            if (touch.phase == TouchPhase.Began)
            {
                // Raycast to determine if the touch event was on a GameObject
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null)
                {
                    GameObject hitObject = hit.collider.gameObject;

                    // Check if the touch event was on a Monk object
                    if (hitObject.tag == "Monk")
                    {
                        selectedMonk = hitObject;
                    }
                    // Check if the touch event was on a Workplace object
                    else if (hitObject.tag == "Veg")
                    {
                        selectedWorkplace = MonkState.CollectingFood;
                    }
                    else if (hitObject.tag == "For")
                    {
                        selectedWorkplace = MonkState.CuttingWood;
                    }
                    else if (hitObject.tag == "Med")
                    {
                        selectedWorkplace = MonkState.Meditating;
                    }
                    else if (hitObject.tag == "Riv")
                    {
                        selectedWorkplace = MonkState.CollectingWater;
                    }
                    else
                    {
                        selectedMonk = null;
                        selectedWorkplace = MonkState.None;
                    }
                }
            }
        }

        // Check if a Monk and a Workplace have both been selected
        if (selectedMonk != null && selectedWorkplace != MonkState.None)
        {

            if (selectedMonk.GetComponent<MonkBehaviour>() != null)
            {
                selectedMonk.GetComponent<MonkBehaviour>().currentState = selectedWorkplace;
            }

            selectedMonk = null;
            selectedWorkplace = MonkState.None;
        }
    }
}