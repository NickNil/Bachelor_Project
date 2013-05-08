<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jukebox.aspx.cs" Inherits="WebDesign.Jukebox" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;

        <asp:Label ID="LbJukebox" runat="server" Text=" Stem på en sang!"></asp:Label>
       

    <div>
        <asp:DropDownList ID="songList" runat="server" OnSelectedIndexChanged="songList_SelectedIndexChanged" Width="150px"></asp:DropDownList>
    </div>
    <asp:Button ID="voteBtn" runat="server" Height="29px" Style="margin-top: 0px" Text="Stem" Width="54px" OnClick="voteBtn_Click" />
</asp:Content>
