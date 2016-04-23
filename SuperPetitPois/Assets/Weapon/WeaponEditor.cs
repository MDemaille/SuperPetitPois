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

    public override void OnInspectorGUI()
    {
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
        }

    }
}
