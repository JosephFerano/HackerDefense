using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Command
{
	public Category category;
	public Parameter parameter;
	public Execution execution;

	public Command(Category category, Execution execution, Parameter parameter) {
		this.category = category;
		this.execution = execution;
		this.parameter = parameter;
	}

}
