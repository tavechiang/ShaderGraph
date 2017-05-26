using System;
using System.Collections.Generic;
using RMGUI.GraphView;
using UnityEditor.Graphing.Drawing;
using UnityEngine.MaterialGraph;
using UnityEngine;

namespace UnityEditor.MaterialGraph.Drawing
{
    class TransformControlPresenter : GraphControlPresenter
    {

        public override void OnGUIHandler()
        {
            base.OnGUIHandler();

            var tNode = node as TransformNode;
            if (tNode == null)
                return;

			//EditorGUILayout.BeginHorizontal ();
			tNode.spaceFrom = (SimpleMatrixType)EditorGUILayout.EnumPopup ("From", tNode.spaceFrom);
			tNode.spaceTo = (SimpleMatrixType)EditorGUILayout.EnumPopup ("To", tNode.spaceTo);
			//EditorGUILayout.BeginHorizontal ();
        }

        public override float GetHeight()
        {
			return (EditorGUIUtility.singleLineHeight + 6 * EditorGUIUtility.standardVerticalSpacing) + EditorGUIUtility.standardVerticalSpacing;
        }
    }

    [Serializable]
    public class TransformNodePresenter : PropertyNodePresenter
    {
        protected override IEnumerable<GraphElementPresenter> GetControlData()
        {
            var instance = CreateInstance<TransformControlPresenter>();
            instance.Initialize(node);
            return new List<GraphElementPresenter>(base.GetControlData()) { instance };
        }
    }
}