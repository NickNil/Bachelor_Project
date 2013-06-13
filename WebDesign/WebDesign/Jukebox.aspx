<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jukebox.aspx.cs" Inherits="WebDesign.Jukebox" %>

<asp:Content ID="JukeboxMainContent" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;
    <asp:MultiView ID="MultiView2" runat="server">

        <asp:View ID="View1" runat="server">
            <asp:Label ID="LbJukebox" runat="server" Text=" Stem på en sang!"></asp:Label>
            <div>
                <asp:DropDownList ID="songList" enableViewstate="false" runat="server" OnSelectedIndexChanged="songList_SelectedIndexChanged" Width="150px"></asp:DropDownList>
            </div>
            <asp:Button ID="voteBtn" runat="server" Height="29px" Style="margin-top: 0px" Text="Stem" Width="54px" OnClick="voteBtn_Click" />
        </asp:View>
        
        <asp:View ID="View2" runat="server">
            <p>
                Stem på en annen sang etter 5 minutter!
            </p>
        </asp:View>
        
    </asp:MultiView>
</asp:Content>
