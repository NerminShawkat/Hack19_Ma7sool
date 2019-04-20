#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class TextFixerTool : MonoBehaviour {

    [MenuItem("Text/FixText %q")]
    private static void DoSomethingWithTexture()
    {
        for (int i = 0; i < Selection.transforms.Length; i++)
        {
            Text component = Selection.transforms[i].GetComponent<Text>();
            if (component)
            {
                component.text = ArabicFixer.Fix(component.text);
            }
        }
        
    }
    
    [MenuItem("Text/FixText", true)]
    private static bool NewMenuOptionValidation()
    {

        return Selection.activeTransform.GetComponent<Text>();// == typeof(Text);
    }
}
#endif
