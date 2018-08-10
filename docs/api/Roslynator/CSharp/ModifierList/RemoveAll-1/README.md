# ModifierList\.RemoveAll Method

**Namespace**: [Roslynator.CSharp](../../README.md)

**Assembly**: Roslynator\.CSharp\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [RemoveAll\<TNode>(TNode)](#Roslynator_CSharp_ModifierList_RemoveAll__1___0_) | Creates a new node with all modifiers removed\. |
| [RemoveAll\<TNode>(TNode, Func\<SyntaxToken, Boolean>)](#Roslynator_CSharp_ModifierList_RemoveAll__1___0_System_Func_Microsoft_CodeAnalysis_SyntaxToken_System_Boolean__) | Creates a new node with modifiers that matches the predicate removed\. |

## RemoveAll\<TNode>\(TNode\)<a name="Roslynator_CSharp_ModifierList_RemoveAll__1___0_"></a>

### Summary

Creates a new node with all modifiers removed\.

```csharp
public static TNode RemoveAll<TNode>(TNode node) where TNode : Microsoft.CodeAnalysis.SyntaxNode
```

#### Type Parameters

| Name | Summary |
| ---- | ------- |
| TNode | |

#### Parameters

| Name | Summary |
| ---- | ------- |
| node | |

#### Returns

TNode

## RemoveAll\<TNode>\(TNode, Func\<SyntaxToken, Boolean>\)<a name="Roslynator_CSharp_ModifierList_RemoveAll__1___0_System_Func_Microsoft_CodeAnalysis_SyntaxToken_System_Boolean__"></a>

### Summary

Creates a new node with modifiers that matches the predicate removed\.

```csharp
public static TNode RemoveAll<TNode>(TNode node, Func<SyntaxToken, bool> predicate) where TNode : Microsoft.CodeAnalysis.SyntaxNode
```

#### Type Parameters

| Name | Summary |
| ---- | ------- |
| TNode | |

#### Parameters

| Name | Summary |
| ---- | ------- |
| node | |
| predicate | |

#### Returns

TNode
