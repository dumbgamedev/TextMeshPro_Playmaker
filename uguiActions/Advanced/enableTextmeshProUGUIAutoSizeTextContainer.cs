// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("TextMesh Pro UGUI Advanced")]
	[Tooltip("Enable Text Mesh Pro auto size text UGUI container.")]

	public class  enableTextmeshProUGUIAutoSizeTextContainer : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(TextMeshProUGUI))]
		[Tooltip("Textmesh Pro component is required.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[TitleAttribute("Enable Auto Size Text Container")]
		[Tooltip("Enable Auto Size Text Container.")]
		public FsmBool autoSizeText;

		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

		TextMeshProUGUI meshproScript;

		public override void Reset()
		{

			gameObject = null;
			autoSizeText = false;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			meshproScript = go.GetComponent<TextMeshProUGUI>();
			
			DoMeshChange();


			if (!everyFrame.Value)
			{
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoMeshChange();
			}
		}

		void DoMeshChange()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			if (meshproScript == null)
			{
				Debug.LogError("No textmesh pro ugui component was found on " + go);
				return;
			}

			meshproScript.autoSizeTextContainer = autoSizeText.Value;

		}

	}
}