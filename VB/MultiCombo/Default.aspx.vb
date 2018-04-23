Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxEditors
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports DevExpress.Web.ASPxGridView

Namespace MultiCombo
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Cat1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim combo1 As ASPxComboBox = CType(sender, ASPxComboBox)
			Dim oldCat1 As Object = Session("Cat1ID")
			If oldCat1 IsNot Nothing AndAlso oldCat1.Equals(combo1.Value) Then
				Return
			End If
			Session("Cat1ID") = combo1.Value
			Dim combo2 As ASPxComboBox = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category2ID"), GridViewDataComboBoxColumn), "Cat2"), ASPxComboBox))
			combo2.Value = Nothing
			Cat2_SelectedIndexChanged(combo2, EventArgs.Empty)
		End Sub
		Protected Sub Cat2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim combo2 As ASPxComboBox = CType(sender, ASPxComboBox)
			Dim oldCat2 As Object = Session("Cat2ID")
			If oldCat2 IsNot Nothing AndAlso oldCat2.Equals(combo2.Value) Then
				Return
			End If
			Session("Cat2ID") = combo2.Value
			Dim combo3 As ASPxComboBox = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category3ID"), GridViewDataComboBoxColumn), "Cat3"), ASPxComboBox))
			combo3.Value = Nothing
			Cat3_SelectedIndexChanged(combo3, EventArgs.Empty)
		End Sub

		Protected Sub Cat3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim combo3 As ASPxComboBox = CType(sender, ASPxComboBox)
			Dim oldCat3 As Object = Session("Cat3ID")
			If oldCat3 IsNot Nothing AndAlso oldCat3.Equals(combo3.Value) Then
				Return
			End If
			Session("Cat3ID") = combo3.Value
			Dim combo4 As ASPxComboBox = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category4ID"), GridViewDataComboBoxColumn), "Cat4"), ASPxComboBox))
			combo4.Value = Nothing
		End Sub

		Protected Sub grid_HtmlRowCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs)
			If (e.RowType = GridViewRowType.InlineEdit) Then
				Dim combo2 As ASPxComboBox = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category2ID"), GridViewDataComboBoxColumn), "Cat2"), ASPxComboBox))
				If Request.Params(combo2.UniqueID) IsNot Nothing Then
					Return
				End If

				If (Not grid.IsNewRowEditing) Then
					Dim vals() As Object = CType(grid.GetRowValues(grid.EditingRowVisibleIndex, New String() { "Category2ID", "Category3ID", "Category4ID" }), Object())
					Dim combo4 As ASPxComboBox = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category4ID"), GridViewDataComboBoxColumn), "Cat4"), ASPxComboBox))
					Dim combo3 As ASPxComboBox = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category3ID"), GridViewDataComboBoxColumn), "Cat3"), ASPxComboBox))
					combo2.Value = vals(0)
					combo3.Value = vals(1)
					combo4.Value = vals(2)
				End If

			End If
		End Sub

		Protected Sub grid_StartRowEditing(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxStartRowEditingEventArgs)
			Dim vals() As Object = CType(grid.GetRowValuesByKeyValue(e.EditingKeyValue, New String() {"Category1ID", "Category2ID", "Category3ID" }), Object())
			Session("Cat1ID") = vals(0)
			Session("Cat2ID") = vals(1)
			Session("Cat3ID") = vals(2)
		End Sub

		Protected Sub grid_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
			SaveOrInsertData(e.NewValues)
		End Sub

		Private Sub SaveOrInsertData(ByVal NewValues As OrderedDictionary)
			Dim cat1 As Object = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category1ID"), GridViewDataComboBoxColumn), "Cat1"), ASPxComboBox)).Value
			NewValues("Category1ID") = cat1
			Dim cat2 As Object = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category2ID"), GridViewDataComboBoxColumn), "Cat2"), ASPxComboBox)).Value
			NewValues("Category2ID") = cat2
			Dim cat3 As Object = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category3ID"), GridViewDataComboBoxColumn), "Cat3"), ASPxComboBox)).Value
			NewValues("Category3ID") = cat3
			Dim cat4 As Object = (CType(grid.FindEditRowCellTemplateControl(TryCast(grid.Columns("Category4ID"), GridViewDataComboBoxColumn), "Cat4"), ASPxComboBox)).Value
			NewValues("Category4ID") = cat4
		End Sub

		Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
			SaveOrInsertData(e.NewValues)
		End Sub

	End Class
End Namespace
