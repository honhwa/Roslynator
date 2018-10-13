' Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

Imports System

#Disable Warning CS0219 ' Variable is assigned but its value is never used

Namespace Roslynator.CommandLine
    ''' <summary>
    ''' Foo
    ''' </summary>
    Public Class Foo 'x

#If DEBUG Then
        ''' <summary>
        ''' Bar
        ''' </summary>
        Public Shared Sub Bar() REM x
            'x
            Dim s As String = "

"
            Bar()

            Bar()

        End Sub
#End If

    End Class
End Namespace
