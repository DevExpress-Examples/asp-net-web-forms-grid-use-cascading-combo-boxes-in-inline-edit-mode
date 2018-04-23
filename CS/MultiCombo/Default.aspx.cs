using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxEditors;
using System.Collections.Generic;
using System.Collections.Specialized;
using DevExpress.Web.ASPxGridView;

namespace MultiCombo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBox combo1 = (ASPxComboBox)sender;
            object oldCat1 = Session["Cat1ID"];
            if (oldCat1 != null && oldCat1.Equals(combo1.Value)) return;
            Session["Cat1ID"] = combo1.Value;
            ASPxComboBox combo2 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                grid.Columns["Category2ID"] as GridViewDataComboBoxColumn, "Cat2"));
            combo2.Value = null;
            Cat2_SelectedIndexChanged(combo2, EventArgs.Empty);
        }
        protected void Cat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBox combo2 = (ASPxComboBox)sender;
            object oldCat2 = Session["Cat2ID"];
            if (oldCat2 != null && oldCat2.Equals(combo2.Value)) return;
            Session["Cat2ID"] = combo2.Value;
            ASPxComboBox combo3 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                grid.Columns["Category3ID"] as GridViewDataComboBoxColumn, "Cat3"));
            combo3.Value = null;
            Cat3_SelectedIndexChanged(combo3, EventArgs.Empty);
        }

        protected void Cat3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBox combo3 = (ASPxComboBox)sender;
            object oldCat3 = Session["Cat3ID"];
            if(oldCat3 != null && oldCat3.Equals(combo3.Value)) return;
            Session["Cat3ID"] = combo3.Value;
            ASPxComboBox combo4 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                grid.Columns["Category4ID"] as GridViewDataComboBoxColumn, "Cat4"));
            combo4.Value = null;
        }

        protected void grid_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if ((e.RowType == GridViewRowType.InlineEdit)) {
                ASPxComboBox combo2 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                    grid.Columns["Category2ID"] as GridViewDataComboBoxColumn, "Cat2"));
                if (Request.Params[combo2.UniqueID] != null) return;

                if (!grid.IsNewRowEditing) {
                    object[] vals = (object[])grid.GetRowValues(grid.EditingRowVisibleIndex,
                    new string[] { "Category2ID", "Category3ID", "Category4ID" });
                    ASPxComboBox combo4 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                    grid.Columns["Category4ID"] as GridViewDataComboBoxColumn, "Cat4"));
                    ASPxComboBox combo3 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                    grid.Columns["Category3ID"] as GridViewDataComboBoxColumn, "Cat3"));
                    combo2.Value = vals[0];
                    combo3.Value = vals[1];
                    combo4.Value = vals[2];
                }

            }
        }

        protected void grid_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            object[] vals = (object[]) grid.GetRowValuesByKeyValue(e.EditingKeyValue, 
                new string[] {"Category1ID", "Category2ID", "Category3ID" });
            Session["Cat1ID"] = vals[0];
            Session["Cat2ID"] = vals[1];
            Session["Cat3ID"] = vals[2];
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            SaveOrInsertData(e.NewValues);
        }

        private void SaveOrInsertData(OrderedDictionary NewValues)
        {
            object cat1 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                grid.Columns["Category1ID"] as GridViewDataComboBoxColumn, "Cat1")).Value;
            NewValues["Category1ID"] = cat1;
            object cat2 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                grid.Columns["Category2ID"] as GridViewDataComboBoxColumn, "Cat2")).Value;
            NewValues["Category2ID"] = cat2;
            object cat3 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                grid.Columns["Category3ID"] as GridViewDataComboBoxColumn, "Cat3")).Value;
            NewValues["Category3ID"] = cat3;
            object cat4 = ((ASPxComboBox)grid.FindEditRowCellTemplateControl(
                grid.Columns["Category4ID"] as GridViewDataComboBoxColumn, "Cat4")).Value;
            NewValues["Category4ID"] = cat4;
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            SaveOrInsertData(e.NewValues);
        }

    }
}
