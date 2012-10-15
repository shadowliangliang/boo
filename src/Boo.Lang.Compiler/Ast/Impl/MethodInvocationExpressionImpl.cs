#region license
// Copyright (c) 2009 Rodrigo B. de Oliveira (rbo@acm.org)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Rodrigo B. de Oliveira nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by astgen.boo.
//
namespace Boo.Lang.Compiler.Ast
{	
	using System.Collections;
	using System.Runtime.Serialization;
	
	[System.Serializable]
	public partial class MethodInvocationExpression : Expression, INodeWithArguments
	{
		protected Expression _target;

		protected ExpressionCollection _arguments;

		protected ExpressionPairCollection _namedArguments;


		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public MethodInvocationExpression CloneNode()
		{
			return (MethodInvocationExpression)Clone();
		}
		
		/// <summary>
		/// <see cref="Node.CleanClone"/>
		/// </summary>
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public MethodInvocationExpression CleanClone()
		{
			return (MethodInvocationExpression)base.CleanClone();
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public NodeType NodeType
		{
			get { return NodeType.MethodInvocationExpression; }
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public void Accept(IAstVisitor visitor)
		{
			visitor.OnMethodInvocationExpression(this);
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Matches(Node node)
		{	
			if (node == null) return false;
			if (NodeType != node.NodeType) return false;
			var other = ( MethodInvocationExpression)node;
			if (!Node.Matches(_target, other._target)) return NoMatch("MethodInvocationExpression._target");
			if (!Node.AllMatch(_arguments, other._arguments)) return NoMatch("MethodInvocationExpression._arguments");
			if (!Node.AllMatch(_namedArguments, other._namedArguments)) return NoMatch("MethodInvocationExpression._namedArguments");
			return true;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}
			if (_target == existing)
			{
				this.Target = (Expression)newNode;
				return true;
			}
			if (_arguments != null)
			{
				Expression item = existing as Expression;
				if (null != item)
				{
					Expression newItem = (Expression)newNode;
					if (_arguments.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_namedArguments != null)
			{
				ExpressionPair item = existing as ExpressionPair;
				if (null != item)
				{
					ExpressionPair newItem = (ExpressionPair)newNode;
					if (_namedArguments.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			return false;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public object Clone()
		{
			MethodInvocationExpression clone = (MethodInvocationExpression)FormatterServices.GetUninitializedObject(typeof(MethodInvocationExpression));
			clone._lexicalInfo = _lexicalInfo;
			clone._endSourceLocation = _endSourceLocation;
			clone._documentation = _documentation;
			clone._isSynthetic = _isSynthetic;
			clone._entity = _entity;
			if (_annotations != null) clone._annotations = (Hashtable)_annotations.Clone();
		
			clone._expressionType = _expressionType;
			if (null != _target)
			{
				clone._target = _target.Clone() as Expression;
				clone._target.InitializeParent(clone);
			}
			if (null != _arguments)
			{
				clone._arguments = _arguments.Clone() as ExpressionCollection;
				clone._arguments.InitializeParent(clone);
			}
			if (null != _namedArguments)
			{
				clone._namedArguments = _namedArguments.Clone() as ExpressionPairCollection;
				clone._namedArguments.InitializeParent(clone);
			}
			return clone;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override internal void ClearTypeSystemBindings()
		{
			_annotations = null;
			_entity = null;
			_expressionType = null;
			if (null != _target)
			{
				_target.ClearTypeSystemBindings();
			}
			if (null != _arguments)
			{
				_arguments.ClearTypeSystemBindings();
			}
			if (null != _namedArguments)
			{
				_namedArguments.ClearTypeSystemBindings();
			}

		}
	

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Expression Target
		{
			
			get { return _target; }
			set
			{
				if (_target != value)
				{
					_target = value;
					if (null != _target)
					{
						_target.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlArray]
		[System.Xml.Serialization.XmlArrayItem(typeof(Expression))]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public ExpressionCollection Arguments
		{
			

			get { return _arguments ?? (_arguments = new ExpressionCollection(this)); }
			set
			{
				if (_arguments != value)
				{
					_arguments = value;
					if (null != _arguments)
					{
						_arguments.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlArray]
		[System.Xml.Serialization.XmlArrayItem(typeof(ExpressionPair))]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public ExpressionPairCollection NamedArguments
		{
			

			get { return _namedArguments ?? (_namedArguments = new ExpressionPairCollection(this)); }
			set
			{
				if (_namedArguments != value)
				{
					_namedArguments = value;
					if (null != _namedArguments)
					{
						_namedArguments.InitializeParent(this);
					}
				}
			}

		}
		

	}
}

