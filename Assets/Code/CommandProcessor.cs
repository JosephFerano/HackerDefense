using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandProcessor : MonoX
{
	[SerializeField] private string[] commands;
	[SerializeField] private string[] options;
	[SerializeField] private string[] actions;
}
