namespace Dreamteck
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public static class SceneUtility
    {
        public static void GetChildrenRecursively(Transform current, ref List<Transform> transformList)
        {
            transformList.Add(current);
            foreach (Transform child in current) GetChildrenRecursively(child, ref transformList);
        }

        public static T GetComponentInScene<T>(this Scene scene, string objectName = null) where T : Component
        {
            var component = default(T);
            var rootObjects = scene.GetRootGameObjects();

            foreach (var obj in rootObjects)
            {
                if (objectName != null && obj.name != objectName) continue;

                component = obj.GetComponent<T>();

                if (component != null) break;

                component = obj.GetComponentInChildren<T>();
            }

            return component;
        }

        public static T[] GetComponentsInScene<T>(this Scene scene, string objectName = null) where T : Component
        {
            var rootObjects = scene.GetRootGameObjects();
            var components = new List<T>();

            foreach (var obj in rootObjects)
            {
                var rootComponent = obj.GetComponent<T>();

                if (rootComponent != null && (objectName == null || (objectName != null && obj.gameObject.name == obj.name)))
                {
                    components.Add(rootComponent);
                }

                var foundComponents = obj.GetComponentsInChildren<T>();

                for (int i = 0; i < foundComponents.Length; i++)
                {
                    var component = foundComponents[i];

                    if (objectName != null && component.gameObject.name != objectName) continue;

                    components.Add(component);
                }
            }

            return components.ToArray();
        }
    }
}
