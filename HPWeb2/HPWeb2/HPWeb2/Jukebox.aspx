<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jukebox.aspx.cs" Inherits="HPWeb2.Jukebox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<asp:ListBox ID="songList" runat="server" Width="304px" Height="219px" OnSelectedIndexChanged="songList_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="voteBtn" runat="server" Height="29px" style="margin-top: 0px" Text="Stem" Width="54px" OnClick="voteBtn_Click" />
    </asp:Content>
