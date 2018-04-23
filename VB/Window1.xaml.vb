Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Documents
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Bars

Namespace DXGrid_CreateCellContextMenu

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = New AccountList().GetData()
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
			list.Add(New Account() With {.UserName = "Nick White", .RegistrationDate = DateTime.Today})
			list.Add(New Account() With {.UserName = "Jack Rodman", .RegistrationDate = New DateTime(2009, 5, 10)})
			list.Add(New Account() With {.UserName = "Sandra Sherry", .RegistrationDate = New DateTime(2008, 12, 22)})
			list.Add(New Account() With {.UserName = "Sabrina Vilk", .RegistrationDate = DateTime.Today})
			list.Add(New Account() With {.UserName = "Mike Pearson", .RegistrationDate = New DateTime(2008, 10, 18)})
			Return list
		End Function
	End Class

	Public Class Account
		Private privateUserName As String
		Public Property UserName() As String
			Get
				Return privateUserName
			End Get
			Set(ByVal value As String)
				privateUserName = value
			End Set
		End Property
		Private privateRegistrationDate As DateTime
		Public Property RegistrationDate() As DateTime
			Get
				Return privateRegistrationDate
			End Get
			Set(ByVal value As DateTime)
				privateRegistrationDate = value
			End Set
		End Property
	End Class
	#End Region
End Namespace
