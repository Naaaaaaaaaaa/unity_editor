using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyTestWindow : EditorWindow
{
	private string _title = "MyWindow";
	private bool _isEnable;
	private bool _myBool;
	private float _myFloat = 0.5f;
	private Transform _myTran;
	private Rect _rect;
	
	
	[MenuItem("Tools/MyTestWindow")]
	static void Init()
	{
		MyTestWindow window = EditorWindow.GetWindow(typeof(MyTestWindow), false, "我的窗口", true) as MyTestWindow;
		window.Show();
	}

	private void OnGUI()
	{
		GUILayout.Label("GUILayout label", EditorStyles.label);
		EditorGUILayout.LabelField("EditorGUILayout label");

//		_title = EditorGUILayout.TextField("窗口名称", _title);
//		if ((Event.current.type == EventType.DragUpdated  
//		     || Event.current.type == EventType.DragExited))  
//		{  
//			//改变鼠标的外表  
//			DragAndDrop.visualMode = DragAndDropVisualMode.Generic;  
//			if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)  
//			{  
//				_title = DragAndDrop.paths[0]; 
//			}  
//		}

		_rect = EditorGUILayout.GetControlRect(GUILayout.Width(400));
		_title = EditorGUI.TextField(_rect, _title);
		if ((Event.current.type == EventType.DragUpdated  
			 || Event.current.type == EventType.DragExited)
			 && _rect.Contains(Event.current.mousePosition))  
		{  
			//改变鼠标的外表  
			DragAndDrop.visualMode = DragAndDropVisualMode.Generic;  
			if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)  
			{  
				_title = DragAndDrop.paths[0]; 
			}  
		}

		_isEnable = EditorGUILayout.BeginToggleGroup("是否开启下列选项", _isEnable);
		_myBool = EditorGUILayout.Toggle("MyToggle", _myBool);
		_myFloat = EditorGUILayout.Slider("MySlider", _myFloat, 0, 1, null);
		EditorGUILayout.EndToggleGroup();

		_myTran = EditorGUILayout.ObjectField("Transform", _myTran, typeof(Transform)) as Transform; 
		
		
	}
}
