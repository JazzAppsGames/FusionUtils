using UnityEngine;
using UnityEngine.UIElements;

namespace JazzApps.Utils
{
    public static class UIToolkitUtil
    {
        public static void TranslateElementToMouse(UIDocument uiDocument, VisualElement targetElement)
        {
            Vector2 mousePosition = Input.mousePosition;

            // Convert mouse Y coordinate to UI Toolkit's coordinate system
            mousePosition.y = Screen.height - mousePosition.y;

            // Calculate and apply the ratio between the document size and the screen size
            float xRatio = uiDocument.rootVisualElement.resolvedStyle.width / Screen.width;
            float yRatio = uiDocument.rootVisualElement.resolvedStyle.height / Screen.height;
            Vector2 localPosition = new Vector2(mousePosition.x * xRatio, mousePosition.y * yRatio);

            targetElement.style.left = localPosition.x;
            targetElement.style.top = localPosition.y;
        }
    }
}
