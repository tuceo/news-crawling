<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="WebApplication1.NewsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        #form1 {
            margin: 10px 150px;
        }

        #Title {
            font-size: 40px;
            color: white;
            text-align: center;
            display: block;
        }

        #Image {
            display: block;
            width: auto;
            height: 300px;
            text-align: center;
            margin-left: auto;
            margin-right: auto;
        }

        #titleback {
            background-color: #5D7B9D;
            height: 40px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Category" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <div id="titleback">
                <asp:Label ID="Title" runat="server" Text="Label"></asp:Label>
            </div>
            <br />
            <br />
            <asp:Image ID="Image" runat="server" />
            <br />
            <br />
            <asp:Label ID="PubDate" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Description" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
