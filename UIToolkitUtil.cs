using UnityEngine;
using UnityEngine.UIElements;

namespace JazzApps.Utils
{
    public static class UIToolkitUtil
    {
        public static void TranslateElementToMouse(UIDocument uiDocument, VisualElement element, Vector2 screenMousePosition)
        {
            TranslateElementToTargetWithinDocument(element, ConvertToDocumentSpace(uiDocument, screenMousePosition));
        }
        
        
        
        private static Vector2 ConvertToDocumentSpace(UIDocument uiDocument, Vector2 mousePosition)
        {
            mousePosition.y = Screen.height - mousePosition.y;
            var resolutionScale = uiDocument.rootVisualElement.contentRect.size / new Vector2(Screen.width, Screen.height);
            return Vector2.Scale(mousePosition, resolutionScale);
        }
        
        private static void TranslateElementToTargetWithinDocument(VisualElement element, Vector2 localPosition)
        {
            var documentSize = element.panel.visualTree.resolvedStyle;
            var elementSize = element.resolvedStyle;

            float adjustedX = Mathf.Clamp(localPosition.x, 0, documentSize.width - elementSize.width);
            float adjustedY = Mathf.Clamp(localPosition.y, 0, documentSize.height - elementSize.height);

            element.style.position = Position.Absolute;
            element.style.left = adjustedX;
            element.style.top = adjustedY;
        }
    }
}
