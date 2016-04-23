using System;
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Weapon))]
[CanEditMultipleObjects]
public class WeaponEditor : Editor
{
    private int _weaponDirectionIndex;
    private string[] names;

    private SerializedProperty _fireRate;
    private SerializedProperty _bullet;
    private SerializedProperty _weaponDirection;
    private SerializedProperty _angle;
    private SerializedProperty _nbShots;
    private SerializedProperty _hasMunitions;
    private SerializedProperty _maxMunitions;
    private SerializedProperty _reloadTime;


    void OnEnable()
    {
        _fireRate = serializedObject.FindProperty("FireRate");
        _bullet = serializedObject.FindProperty("Bullet");
        _weaponDirection = serializedObject.FindProperty("DirectionType");
        _angle = serializedObject.FindProperty("Angle");
        _nbShots = serializedObject.FindProperty("NbShots");
        _hasMunitions = serializedObject.FindProperty("HasMunitions");
        _maxMunitions = serializedObject.FindProperty("MaxMunitions");
        _reloadTime = serializedObject.FindProperty("ReloadTime");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_bullet, new GUIContent("Bullet"));
        EditorGUILayout.PropertyField(_fireRate, new GUIContent("Fire rate"));
        EditorGUILayout.PropertyField(_weaponDirection, new GUIContent("Weapon Mode"));

        if (_weaponDirection.enumValueIndex == (int) WeaponDirection.CONE)
        {
            EditorGUILayout.PropertyField(_angle, new GUIContent("Angle"));
        }
        if (_weaponDirection.enumValueIndex == (int) WeaponDirection.CONE || _weaponDirection.enumValueIndex == (int)WeaponDirection.CIRCLE)
        {
            EditorGUILayout.PropertyField(_nbShots, new GUIContent("NbShots"));
        }

        EditorGUILayout.PropertyField(_hasMunitions, new GUIContent("Has munitions ?"));
        if (_hasMunitions.boolValue)
        {
            EditorGUILayout.PropertyField(_maxMunitions, new GUIContent("MaxMunitions"));
            EditorGUILayout.PropertyField(_reloadTime, new GUIContent("ReloadTime"));
        }


        serializedObject.ApplyModifiedProperties();

        /*
        Weapon script = (Weapon)target;

        script.Bullet = (GameObject)EditorGUILayout.ObjectField("Bullet", script.Bullet, typeof(GameObject), false);
        script.FireRate = EditorGUILayout.FloatField("Fire Rate :", script.FireRate);
        script.DirectionType =
            (WeaponDirection)
                EditorGUILayout.Popup("Weapon Direction", (int)script.DirectionType,
                    Enum.GetNames(typeof(WeaponDirection)));

        if (script.DirectionType == WeaponDirection.CONE)
        {
            script.Angle = EditorGUILayout.FloatField("Angle", script.Angle);
            script.NbShots = EditorGUILayout.IntField("Number Shots", script.NbShots);
        }

        if (script.DirectionType == WeaponDirection.CIRCLE)
        {
            script.NbShots = EditorGUILayout.IntField("Number Shots", script.NbShots);
        }

        script.HasMunitions = EditorGUILayout.Toggle("Has Munitions ?", script.HasMunitions);

        if (script.HasMunitions)
        {
            script.MaxMunitions = EditorGUILayout.IntField("Max Munitions", script.MaxMunitions);
            script.ReloadTime = EditorGUILayout.FloatField("Reload Time", script.ReloadTime);
        }*/

    }
}
