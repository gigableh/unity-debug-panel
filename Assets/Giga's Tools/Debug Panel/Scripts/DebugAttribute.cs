using System;

[AttributeUsage(
	AttributeTargets.Field |
	AttributeTargets.Method )]
public class DebugAttribute : Attribute
{
	public string group;

	public DebugAttribute(string group="")
	{
		this.group = group;
	}
}