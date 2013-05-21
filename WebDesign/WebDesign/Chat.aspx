<%@ Page Title="Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True"
    CodeBehind="Chat.aspx.cs" Inherits="WebDesign.Chat" %>

<asp:Content ID="ChatMainContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView" runat="server">

        <asp:View ID="View1" runat="server">

            <asp:Label ID="logInLb" Text="Velg brukernavn" runat="server" />

            <asp:TextBox ID="tbName" runat="server" />
            <asp:Button ID="btnSaveToCookie" Text="Save!" runat="server" OnClick="btnSaveToCookie_Click" />
        </asp:View>

        <asp:View ID="View2" runat="server">

            <asp:Label ID="lbName" runat="server" />
            <asp:TextBox ID="TBMsg" runat="server" />
            <asp:Button ID="BtnSend" runat="server" Text="Send" OnClick="BtnSend_Click" />
            <asp:Button ID="BtnLogOut" runat="server" Text="Log out" OnClick="BtnLogOut_Click" />
        </asp:View>

    </asp:MultiView>
    <div class="message-error">
        <asp:Label ID="LbError" runat="server" />
    </div>

</asp:Content>
