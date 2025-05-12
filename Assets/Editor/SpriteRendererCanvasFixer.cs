using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpriteRendererCanvasFixer : EditorWindow
{
    private List<SpriteRenderer> foundSprites = new List<SpriteRenderer>();

    [MenuItem("Tools/Fix SpriteRenderers Under Canvases")]
    public static void ShowWindow()
    {
        GetWindow<SpriteRendererCanvasFixer>("Fix SpriteRenderers");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Find SpriteRenderers Under Canvases"))
        {
            FindProblemSprites();
        }

        if (foundSprites.Count > 0)
        {
            GUILayout.Space(10);
            GUILayout.Label($"Found {foundSprites.Count} SpriteRenderers under Canvas objects.");

            if (GUILayout.Button("Move All to Scene Root (Preserve World Pos & Convert Transforms)"))
            {
                MoveSpritesToRootAndFix();
            }
        }
    }

    void FindProblemSprites()
    {
        foundSprites.Clear();

        Canvas[] canvases = GameObject.FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            SpriteRenderer[] sprites = canvas.GetComponentsInChildren<SpriteRenderer>(true);
            foundSprites.AddRange(sprites);
        }

        Debug.Log($"Found {foundSprites.Count} SpriteRenderers under Canvas objects.");
    }

    void MoveSpritesToRootAndFix()
    {
        foreach (var sr in foundSprites)
        {
            GameObject go = sr.gameObject;

            // Cache world transform values
            Vector3 worldPos = go.transform.position;
            Quaternion worldRot = go.transform.rotation;
            Vector3 worldScale = go.transform.lossyScale;

            // Unparent
            Undo.SetTransformParent(go.transform, null, "Unparent SpriteRenderer from Canvas");

            // Apply world transform
            go.transform.position = worldPos;
            go.transform.rotation = worldRot;
            go.transform.localScale = worldScale;

            // If RectTransform, replace it with a standard Transform
            RectTransform rt = go.GetComponent<RectTransform>();
            if (rt != null)
            {
                ReplaceRectTransformWithTransform(go, worldPos, worldRot, worldScale);
            }
        }

        Debug.Log($"Moved {foundSprites.Count} SpriteRenderers to root and replaced RectTransforms.");
        foundSprites.Clear();
    }

    void ReplaceRectTransformWithTransform(GameObject go, Vector3 pos, Quaternion rot, Vector3 scale)
    {
        RectTransform rt = go.GetComponent<RectTransform>();
        if (rt == null) return;

        Undo.RecordObject(go, "Replace RectTransform");

        DestroyImmediate(rt, true); // Remove RectTransform
        go.AddComponent<Transform>(); // Add normal Transform

        go.transform.position = pos;
        go.transform.rotation = rot;
        go.transform.localScale = scale;
    }
}