using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CanvasToWorldSpriteConverter : EditorWindow
{
    [MenuItem("Tools/Convert SpriteRenderers to World Space")]
    public static void ShowWindow()
    {
        GetWindow<CanvasToWorldSpriteConverter>("Canvas to World Sprite Converter");
    }

    private void OnGUI()
    {
        GUILayout.Label("Convert SpriteRenderers under Canvas to World Space", EditorStyles.boldLabel);

        if (GUILayout.Button("Convert All in Scene"))
        {
            ConvertAll();
        }
    }

    private void ConvertAll()
    {
        Canvas[] canvases = GameObject.FindObjectsOfType<Canvas>();

        foreach (Canvas canvas in canvases)
        {
            SpriteRenderer[] sprites = canvas.GetComponentsInChildren<SpriteRenderer>(true);

            if (sprites.Length == 0) continue;

            GameObject group = new GameObject(canvas.name + "_WorldGroup");
            Undo.RegisterCreatedObjectUndo(group, "Create World Sprite Group");

            foreach (SpriteRenderer sr in sprites)
            {
                Transform t = sr.transform;
                Vector3 pos = t.position;
                Quaternion rot = t.rotation;
                Vector3 scale = t.lossyScale;

                // Detach from old parent
                Undo.SetTransformParent(t, group.transform, "Reparent to World Group");

                t.position = pos;
                t.rotation = rot;
                t.localScale = scale;

                // Replace RectTransform if needed
                RectTransform rt = sr.GetComponent<RectTransform>();
                if (rt != null)
                {
                    ReplaceRectTransformWithTransform(sr.gameObject, pos, rot, scale);
                }
            }

            // Optionally position new group at the original canvas' position
            group.transform.position = canvas.transform.position;
            group.AddComponent<SpriteGroupVisibility>();

            Debug.Log($"Converted {sprites.Length} SpriteRenderers from Canvas '{canvas.name}' to '{group.name}'");
        }
    }

    void ReplaceRectTransformWithTransform(GameObject go, Vector3 pos, Quaternion rot, Vector3 scale)
    {
        RectTransform rt = go.GetComponent<RectTransform>();
        if (rt == null) return;

        Undo.RecordObject(go, "Replace RectTransform");

        DestroyImmediate(rt, true); // Remove RectTransform
        go.AddComponent<Transform>(); // Add standard Transform

        go.transform.position = pos;
        go.transform.rotation = rot;
        go.transform.localScale = scale;
    }
}