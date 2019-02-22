using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking.NetworkSystem;

public class ChangeTransform : ScriptableWizard
{
	public string myEditorPrefsKey;
	private const string My_Editor_Prefs_Key = "My_Editor_Prefs_Key";
	
	public Vector3 myPosition;
	public Vector3 myRotation;
	public Vector3 myScale;
	public List<GameObject> myPrefabs;

	private void OnWizardCreate()
	{
		Debug.Log("OnWizardCreate" + myPrefabs.Count);
		EditorUtility.DisplayProgressBar("进度：", "0/" + myPrefabs.Count + "已经完成", 0);
		for (int i = 0; i < myPrefabs.Count; i++)
		{
			if (myPrefabs[i] != null)
			{
				myPrefabs[i].transform.localPosition = myPosition;
				myPrefabs[i].transform.localRotation = Quaternion.Euler(myRotation);
				myPrefabs[i].transform.localScale = myScale;
				//AssetDatabase.GetAssetPath(Object)
				//可以获取到Object在assets下的路径
				//Debug.Log(AssetDatabase.GetAssetPath(myPrefabs[i]));
				AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(myPrefabs[i]), "testName_" + i);
			}
			EditorUtility.DisplayProgressBar("进度", i + "/" + myPrefabs.Count + "已经完成", (float)i/myPrefabs.Count);
		}
		//EditorUtility.ClearProgressBar();
	}

	private void OnFocus()
	{
		//Debug.Log("OnWizardFocus");
	}

	private void OnLostFocus()
	{
		//Debug.Log("OnWizardLostFocus");
	}

	private void OnWizardUpdate()
	{
//		Debug.Log("OnWizardUpdate");
		if (EditorPrefs.GetString(My_Editor_Prefs_Key) != null)
		{
			if (myEditorPrefsKey != EditorPrefs.GetString(My_Editor_Prefs_Key))
			{
				EditorPrefs.SetString(My_Editor_Prefs_Key, myEditorPrefsKey);
			}
			else
			{
				Debug.Log("值没有改变");
			}
		}
		else
		{
			Debug.Log("没有找到editor prefs值， 生成一个");
			EditorPrefs.SetString(My_Editor_Prefs_Key, myEditorPrefsKey);
		}
	}

	private void OnEnable()
	{
		myEditorPrefsKey = EditorPrefs.GetString(My_Editor_Prefs_Key);
	}

	private void OnSelectionChange()
	{
		//Debug.Log("OnWizardSelectionChange");
	}

	private void OnWizardOtherButton()
	{
		//Debug.Log("取消按钮被点击了");
		
		//发送消息
		ShowNotification(new GUIContent("使用ShowNotification发送消息:" + Selection.objects.Length + "个游戏物体被修改了"));
		
		//显示进度条
		EditorUtility.DisplayProgressBar("进度：", "0/" + myPrefabs.Count + "已经完成", 0);
		for (int i = 0; i < myPrefabs.Count; i++)
		{
			if (myPrefabs[i] != null)
			{
				myPrefabs[i].transform.localPosition = myPosition;
				myPrefabs[i].transform.localRotation = Quaternion.Euler(myRotation);
				myPrefabs[i].transform.localScale = myScale;
				//AssetDatabase.GetAssetPath(Object)
				//可以获取到Object在assets下的路径
				//Debug.Log(AssetDatabase.GetAssetPath(myPrefabs[i]));
				AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(myPrefabs[i]), "testName_" + i);
			}
			EditorUtility.DisplayProgressBar("进度", (i + 1) + "/" + myPrefabs.Count + "已经完成", (float)(i+1)/myPrefabs.Count);
		}
		//关闭进度条显示
		//EditorUtility.ClearProgressBar();
	}
}