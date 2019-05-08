<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="refresh" content="30"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="NewsID" HorizontalAlign="Center" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ImageField DataImageUrlField="ImageUrl" DataImageUrlFormatString="{0}" ControlStyle-Width="50" ControlStyle-Height="50" />
                    <asp:HyperLinkField DataTextField="Title" SortExpression="Title" DataNavigateUrlFields="NewsID" DataNavigateUrlFormatString="~/NewsDetail.aspx?NewsID={0}" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebBT_ProjectConnectionString1 %>" DeleteCommand="DELETE FROM [News] WHERE [NewsID] = @NewsID" InsertCommand="INSERT INTO [News] ([NewsID], [Title], [Description], [Category], [Author], [PubDate], [ImageUrl]) VALUES (@NewsID, @Title, @Description, @Category, @Author, @PubDate, @ImageUrl)" ProviderName="<%$ ConnectionStrings:WebBT_ProjectConnectionString1.ProviderName %>" SelectCommand="SELECT [NewsID], [Title], [Description], [Category], [Author], [PubDate], [ImageUrl] FROM [News]" UpdateCommand="UPDATE [Newsf] SET [Title] = @Title, [Description] = @Description, [Category] = @Category, [Author] = @Author, [PubDate] = @PubDate, [ImageUrl] = @ImageUrl WHERE [NewsID] = @NewsID">
                <DeleteParameters>
                    <asp:Parameter Name="NewsID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="NewsID" Type="Int32" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Category" Type="String" />
                    <asp:Parameter Name="Author" Type="String" />
                    <asp:Parameter Name="PubDate" Type="String" />
                    <asp:Parameter Name="ImageUrl" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Category" Type="String" />
                    <asp:Parameter Name="Author" Type="String" />
                    <asp:Parameter Name="PubDate" Type="String" />
                    <asp:Parameter Name="ImageUrl" Type="String" />
                    <asp:Parameter Name="NewsID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
