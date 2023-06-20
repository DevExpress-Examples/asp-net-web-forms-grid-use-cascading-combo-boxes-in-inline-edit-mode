<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MultiCombo._Default" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>

            <asp:SqlDataSource ID="dsData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [Data] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Data] ([Title], [Description], [Category1ID], [Category2ID], [Category3ID], [Category4ID]) VALUES (@Title, @Description, @Category1ID, @Category2ID, @Category3ID, @Category4ID)" SelectCommand="SELECT * FROM [Data]"
                UpdateCommand="UPDATE [Data] SET [Title] = @Title, [Description] = @Description, [Category1ID] = @Category1ID, [Category2ID] = @Category2ID, [Category3ID] = @Category3ID, [Category4ID] = @Category4ID WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Category1ID" Type="Int32" />
                    <asp:Parameter Name="Category2ID" Type="Int32" />
                    <asp:Parameter Name="Category3ID" Type="Int32" />
                    <asp:Parameter Name="Category4ID" Type="Int32" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Category1ID" Type="Int32" />
                    <asp:Parameter Name="Category2ID" Type="Int32" />
                    <asp:Parameter Name="Category3ID" Type="Int32" />
                    <asp:Parameter Name="Category4ID" Type="Int32" />
                </InsertParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="dsCategory1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                SelectCommand="SELECT * FROM [Category1]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="dsCategory2All" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>"
                SelectCommand="SELECT ID, Name FROM Category2 ORDER BY Name"></asp:SqlDataSource>

            <asp:SqlDataSource ID="dsCategory3All" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>"
                SelectCommand="SELECT [ID], [Name] FROM [Category3] ORDER BY [Name]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="dsCategory4All" runat="server" EnableCaching="True" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
                SelectCommand="SELECT [ID], [Name] FROM [Category4] ORDER BY [Name]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsCategory3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>"
                SelectCommand="SELECT [ID], [Name] FROM [Category3] WHERE ([Category2ID] = @Category2ID) ORDER BY [Name]">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="Category2ID" SessionField="Cat2ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="dsCategory2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>"
                SelectCommand="SELECT ID, Name FROM Category2 WHERE (Category1ID = @Category1ID) ORDER BY Name">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="Category1ID" SessionField="Cat1ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="dsCategory4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>"
                SelectCommand="SELECT [ID], [Name] FROM [Category4] WHERE ([Category3ID] = @Category3ID) ORDER BY [Name]">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="Category3ID" SessionField="Cat3ID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
       
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False"
                        DataSourceID="dsData" KeyFieldName="ID" OnStartRowEditing="grid_StartRowEditing"
                        OnHtmlRowCreated="grid_HtmlRowCreated" OnRowUpdating="grid_RowUpdating"
                        OnRowInserting="grid_RowInserting" EnableCallBacks="False">
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true" ShowNewButton="true" ShowDeleteButton="true" />
                            <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="2" />
                            <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3" />
                            <dx:GridViewDataComboBoxColumn FieldName="Category1ID" VisibleIndex="4">
                                <PropertiesComboBox DataSourceID="dsCategory1" TextField="Name" ValueField="ID" ValueType="System.Int32" />
                                <EditItemTemplate>
                                    <dx:ASPxComboBox ID="Cat1" runat="server"
                                        DataSourceID="dsCategory1" TextField="Name" ValueField="ID" Value='<%# Bind("Category1ID") %>'
                                        AutoPostBack="true" OnSelectedIndexChanged="Cat1_SelectedIndexChanged" ValueType="System.Int32">
                                    </dx:ASPxComboBox>
                                </EditItemTemplate>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="Category2ID" VisibleIndex="5">
                                <PropertiesComboBox DataSourceID="dsCategory2All" TextField="Name" ValueField="ID"
                                    ValueType="System.Int32" />
                                <EditItemTemplate>
                                    <dx:ASPxComboBox ID="Cat2" runat="server"
                                        DataSourceID="dsCategory2" TextField="Name" ValueField="ID"
                                        AutoPostBack="true" OnSelectedIndexChanged="Cat2_SelectedIndexChanged" ValueType="System.Int32">
                                    </dx:ASPxComboBox>
                                </EditItemTemplate>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="Category3ID" VisibleIndex="6">
                                <PropertiesComboBox DataSourceID="dsCategory3All" TextField="Name" ValueField="ID"
                                    ValueType="System.Int32" />
                                <EditItemTemplate>
                                    <dx:ASPxComboBox ID="Cat3" runat="server"
                                        DataSourceID="dsCategory3" TextField="Name" ValueField="ID"
                                        AutoPostBack="true" OnSelectedIndexChanged="Cat3_SelectedIndexChanged" ValueType="System.Int32">
                                    </dx:ASPxComboBox>
                                </EditItemTemplate>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="Category4ID" VisibleIndex="7">
                                <PropertiesComboBox DataSourceID="dsCategory4All" TextField="Name" ValueField="ID"
                                    ValueType="System.Int32" />
                                <EditItemTemplate>
                                    <dx:ASPxComboBox ID="Cat4" runat="server"
                                        DataSourceID="dsCategory4" TextField="Name" ValueField="ID"
                                        AutoPostBack="true" ValueType="System.Int32">
                                    </dx:ASPxComboBox>
                                </EditItemTemplate>
                            </dx:GridViewDataComboBoxColumn>
                        </Columns>
                        <SettingsEditing Mode="Inline" />
                    </dx:ASPxGridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
