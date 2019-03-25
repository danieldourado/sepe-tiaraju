using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (CustomWave))]
public class CustomWaveDrawer : PropertyDrawer 
{
		
	// Draw the property inside the given rect
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty (position, label, property);
		
		// Draw label
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
		
		// Don't make child fields be indented
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		
		// Calculate rects
		Rect waveRect = new Rect (position.x, position.y, 50, position.height);
		Rect timeRect = new Rect (position.x + 50, position.y, 50, position.height);
		Rect GORect = new Rect (position.x + 100, position.y, position.width - 90, position.height);
		
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField (waveRect, property.FindPropertyRelative ("wave"), GUIContent.none);
		EditorGUI.PropertyField (timeRect, property.FindPropertyRelative ("tempo"), GUIContent.none);
		EditorGUI.PropertyField (GORect, property.FindPropertyRelative ("enemyPrefab"), GUIContent.none);
		
		// Set indent back to what it was
		EditorGUI.indentLevel = indent;
		
		EditorGUI.EndProperty ();
	}
}
