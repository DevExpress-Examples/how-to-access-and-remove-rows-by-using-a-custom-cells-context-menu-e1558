Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Windows

Namespace DXGrid_CreateCellContextMenu

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = (New AccountList()).GetData()
		End Sub

		#Region "#RowCellMenuCustomization"
		Private Sub copyCellDataItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			Dim menuInfo As GridCellMenuInfo = TryCast(view.GridMenu.MenuInfo, GridCellMenuInfo)
			If menuInfo IsNot Nothing AndAlso menuInfo.Row IsNot Nothing Then
				Dim text As String = "" & grid.GetCellValue(menuInfo.Row.RowHandle.Value, TryCast(menuInfo.Column, GridColumn)).ToString()
				Clipboard.SetText(text)
			End If
		End Sub

		Private Sub deleteRowItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			Dim menuInfo As GridCellMenuInfo = TryCast(view.GridMenu.MenuInfo, GridCellMenuInfo)
			If menuInfo IsNot Nothing AndAlso menuInfo.Row IsNot Nothing Then
				view.DeleteRow(menuInfo.Row.RowHandle.Value)
			End If
		End Sub
		#End Region ' #RowCellMenuCustomization
	End Class

	#Region "Account classes"
	Public Class AccountList
		Public Function GetData() As List(Of Account)
			Return CreateAccounts()
		End Function
		Private Function CreateAccounts() As List(Of Account)
			Dim list As New List(Of Account)()
			list.Add(New Account() With {
				.UserName = "Nick White",
				.CanBeDeleted = False,
				.RegistrationDate = DateTime.Today
			})
			list.Add(New Account() With {
				.UserName = "Jack Rodman",
				.CanBeDeleted = True,
				.RegistrationDate = New DateTime(2009, 5, 10)
			})
			list.Add(New Account() With {
				.UserName = "Sandra Sherry",
				.CanBeDeleted = False,
				.RegistrationDate = New DateTime(2008, 12, 22)
			})
			list.Add(New Account() With {
				.UserName = "Sabrina Vilk",
				.CanBeDeleted = True,
				.RegistrationDate = DateTime.Today
			})
			list.Add(New Account() With {
				.UserName = "Mike Pearson",
				.CanBeDeleted = True,
				.RegistrationDate = New DateTime(2008, 10, 18)
			})
			Return list
		End Function
	End Class

	Public Class Account
		Public Property UserName() As String
		Public Property RegistrationDate() As DateTime
		Public Property CanBeDeleted() As Boolean
	End Class
	#End Region
End Namespace
