using UnityEngine;
using System.Collections;

public class GameLinkItemExtend : GameLinkItem
{
	public SysFontText labelFullName;
	public SysFontText labelDetail;
	
	protected override void OnClick()
	{
		base.OnClick();
	}

	protected override void SetData()
	{
		base.SetData();
		
		SetFullNameByLanguage();
		SetDetailByLanguage();
	}
	
	protected override void SetNameByLanguage()
	{
		base.SetNameByLanguage();
	}	
	
	protected void SetFullNameByLanguage()
	{
	}
	
	protected void SetDetailByLanguage()
	{
	}
}
