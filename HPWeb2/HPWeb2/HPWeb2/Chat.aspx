<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True"
    CodeBehind="Chat.aspx.cs" Inherits="HPWeb2.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
        <AnonymousTemplate>
            [ <a href="~/Account/Login.aspx" id="HeadLoginStatus" runat="server">Log In</a>
            ]
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:LoginName ID="HeadLoginName" runat="server" />
            <asp:TextBox ID="TBMsg" runat="server">
            </asp:TextBox>
            <asp:Button ID="BtnSend" runat="server" Text="Send" onclick="BtnSend_Click" />

        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
