using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

public class DebugPanelEditorWindow : EditorWindow
{
	[MenuItem("Window/Giga Tools/Debug Panel")]

    static void Init()
    {
        DebugPanelEditorWindow window = (DebugPanelEditorWindow)EditorWindow.GetWindow(typeof(DebugPanelEditorWindow));
        window.Show();
    }

	void OnEnable()
	{
		this.titleContent = new GUIContent("Debug Panel");
	}

	void OnGUI()
	{
		MonoBehaviour[] mobs = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
		for (int i = 0; i < mobs.Length; ++i)
		{
			bool hasDrawnLabelForThisMob = false;
			FieldInfo[] objectFields = mobs[i].GetType().GetFields();
			for (int j = 0; j < objectFields.Length; ++j)
			{
				DebugAttribute attr = Attribute.GetCustomAttribute(objectFields[j], typeof(DebugAttribute)) as DebugAttribute;
				if (attr != null)
				{
					if (!hasDrawnLabelForThisMob)
					{
						EditorGUI.indentLevel = 0;

						EditorGUILayout.Space();
						EditorGUILayout.Space();

						EditorGUILayout.LabelField(mobs[i].gameObject.name, EditorStyles.boldLabel);
						hasDrawnLabelForThisMob = true;
					}

					EditorGUI.indentLevel = 1;
					DrawField(objectFields[j], mobs[i]);
				}
			}
		}
	}

	void DrawField(FieldInfo field, MonoBehaviour mob)
	{
		Type type = field.FieldType;
		if (type == typeof(Boolean))
		{
			EditorGUILayout.Toggle(field.Name, (Boolean)field.GetValue(mob));
		}
		else if (type == typeof(Single))
		{
			EditorGUILayout.FloatField(field.Name, (Single)field.GetValue(mob));
		}
		else if (type == typeof(Color))
		{
			EditorGUILayout.ColorField(field.Name, (Color)field.GetValue(mob));
		}
	}
}
