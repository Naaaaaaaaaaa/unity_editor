using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Myeditor :  EditorWindow{

	[MenuItem("Tools/显示unity编辑按钮")]
	static void ShowEditorButton()
	{
		Debug.Log("这是unity editor的按钮");
	}

	//可以根据priority属性的值来队按钮进行排序
	[MenuItem("Tools/顺序排列/Oder2", false, 2)]
	static void Oder2()
	{
		Debug.Log("这是第二顺序");
	}
	
	[MenuItem("Tools/顺序排列/Oder3", false, 3)]
	static void Oder3()
	{
		Debug.Log("这是第三顺序");
	}
	
	[MenuItem("Tools/顺序排列/Oder1", false, 1)]
	static void Oder1()
	{
		Debug.Log("这是第一顺序");
	}

	/// <summary>
	/// 在project面板右击显示的方法,需要将路径设置在Assets下
	/// </summary>
	[MenuItem("Assets/右键菜单栏")]
	static void SetRightClickFunc()
	{
		Debug.Log("这是右击显示的方法，需要放在Assets路径下");
	}

	/// <summary>
	/// 格式：	CONTEXT/组件名/方法名
	/// 	可以在组件右击时获得到对应的方法
	/// </summary>
	/// <param name="command">可以通过command.context或得到 对应的组件</param>
	[MenuItem("CONTEXT/Transform/设置transform默认值")]
	static void SetModelToDefaultTransform(MenuCommand command)
	{
		Transform tran = command.context as Transform;
		if (tran == null)
		{
			Debug.Log("该物体为空指针");
		}
		else
		{
			tran.localPosition = Vector3.zero;
			tran.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
			tran.localScale = Vector3.one;
		}
	}

	/// <summary>
	/// 通过Selection可以获取选择的物体
	/// </summary>
	[MenuItem("Tools/选中单个物体")]
	static void SelectionSingleFunc()
	{
		if (!Selection.activeGameObject)
		{
			Debug.Log("你没有选择单个物体");
		}
		else
		{
			Debug.Log(string.Format("你已经选中了单个物体：{0}", Selection.activeGameObject.name));
		}
	}
	
	[MenuItem("Tools/选中多个物体")]
	static void SelectionAllFunc()
	{
		if (Selection.objects.Length == 0)
		{
			Debug.Log("你没有选择物体");
		}
		else
		{
			foreach (var obj in Selection.objects)
			{
				Debug.Log(string.Format("你已经选中了物体：{0}", obj));
			}
		}
	}

	[MenuItem("Tools/删除已经选中的物体（无法撤回）")]
	static void DeleteObjectsCanntUndo()
	{
		if (Selection.objects.Length == 0)
		{
			Debug.Log("你没有选中要删除的物体");
		}
		else
		{
			foreach (var obj in Selection.objects)
			{
				Debug.Log(string.Format("你已经删除了物体：{0}，且无法撤回", obj));
				//该方法无法撤回删除的物体
				GameObject.DestroyImmediate(obj);
			}
		}
	}
	
	[MenuItem("Tools/删除已经选中的物体（可以撤回）")]
	static void DeleteObjectsCanUndo()
	{
		if (Selection.objects.Length == 0)
		{
			Debug.Log("你没有选中要删除的物体");
		}
		else
		{
			foreach (var obj in Selection.objects)
			{
				Debug.Log(string.Format("你已经删除了物体：{0}，可以撤回", obj));
				//该方法可以撤回删除的物体
				Undo.DestroyObjectImmediate(obj);
			}
		}
	}

	/// <summary>
	/// 设置单个快捷键格式： 需要在路径后面 （空格_单个字母）
	/// </summary>
	[MenuItem("Tools/设置单个快捷键M #m")]
	static void SetSingleShortcuts()
	{
		Debug.Log("这里是单个快捷键M");
	}

	[MenuItem("Tools/设置单个快捷键M _m", true)]
	static bool SetSingleShortcutsEnable()
	{
		if (Selection.objects.Length == 0) return true;
		return false;
	}

	/// <summary>
	/// 设置多个快捷键
	/// %代表ctrl #代表shift &代表alt
	/// </summary>
	[MenuItem("Tools/设置多个快捷键Ctrl+Shift+Alt+M #%&m")]
	static void SetAllShortcuts()
	{
		Debug.Log("这里是多个快捷键 Ctrl+Shift+Alt+M");
	}

	/// <summary>
	/// 选中了transform物体才会启用该按钮
	/// 设置菜单栏是否启用
	/// 	需要将SetMenuEnableShow与SetMenuEnable的路径设置成同一个路径，否则无法生效
	/// 	需要在SetMenuEnable返回一个bool类型的参数，如果返回true则显示，如果返回false则不显示
	/// 	需要在SetMenuEnable将isValidateFunction属性设置为true
	/// </summary>
	[MenuItem("Tools/设置菜单栏是否启用")]
	static void SetMenuEnableShow()
	{
		Debug.Log("该菜单栏已经启用");
	}

	[MenuItem("Tools/设置菜单栏是否启用", true)]
	static bool SetMenuEnable()
	{
		if (!Selection.activeTransform) return false;
		return true;
	}

	/// <summary>
	/// 创建对话框
	/// </summary>
	[MenuItem("Tools/创建对话框")]
	static void CreateWizard()
	{
		ScriptableWizard.DisplayWizard<ChangeTransform>("修改GameObject的Transform属性", "确定", "取消");
	}
}
