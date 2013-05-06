<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jukebox.aspx.cs" Inherits="WebDesign.Jukebox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  
        <asp:DropDownList ID="songList" runat="server" OnSelectedIndexChanged="songList_SelectedIndexChanged" Width="150px" ></asp:DropDownList>
    
        <asp:Button ID="voteBtn" runat="server" Height="29px" Style="margin-top: 0px" Text="Stem" Width="54px" OnClick="voteBtn_Click" />
    
</asp:Content>
