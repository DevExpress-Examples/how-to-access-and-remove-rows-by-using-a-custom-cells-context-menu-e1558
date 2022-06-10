Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace DXGrid_CreateCellContextMenu

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = AccountList.GetData()
        End Sub

        Private Sub OnCopyRow(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            Dim menuInfo As GridCellMenuInfo = Nothing
            If CSharpImpl.__Assign(menuInfo, TryCast(Me.view.GridMenu.MenuInfo, GridCellMenuInfo)) IsNot Nothing AndAlso menuInfo.Row IsNot Nothing Then
                Me.grid.CopyCurrentItemToClipboard()
            End If
        End Sub

        Private Sub OnDeleteRow(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            Dim menuInfo As GridCellMenuInfo = Nothing
            If CSharpImpl.__Assign(menuInfo, TryCast(Me.view.GridMenu.MenuInfo, GridCellMenuInfo)) IsNot Nothing AndAlso menuInfo.Row IsNot Nothing Then Me.view.DeleteRow(menuInfo.Row.RowHandle.Value)
        End Sub

        Private Class CSharpImpl

            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class

    Public Class AccountList

        Public Shared Function GetData() As ObservableCollection(Of Account)
            Dim list As ObservableCollection(Of Account) = New ObservableCollection(Of Account)()
            list.Add(New Account() With {.UserName = "Nick White", .CanBeDeleted = False, .RegistrationDate = Date.Today})
            list.Add(New Account() With {.UserName = "Jack Rodman", .CanBeDeleted = True, .RegistrationDate = New DateTime(2009, 5, 10)})
            list.Add(New Account() With {.UserName = "Sandra Sherry", .CanBeDeleted = False, .RegistrationDate = New DateTime(2008, 12, 22)})
            list.Add(New Account() With {.UserName = "Sabrina Vilk", .CanBeDeleted = True, .RegistrationDate = Date.Today})
            list.Add(New Account() With {.UserName = "Mike Pearson", .CanBeDeleted = True, .RegistrationDate = New DateTime(2008, 10, 18)})
            Return list
        End Function
    End Class

    Public Class Account

        Public Property UserName As String

        Public Property RegistrationDate As Date

        Public Property CanBeDeleted As Boolean
    End Class
End Namespace
