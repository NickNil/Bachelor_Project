<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebDesign._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1> Velkommen til Jernet! </h1>
       
            </hgroup>
            <p>
                Her kan du Chatte og velge sanger selv!
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Cool Peoples:</h3>
    <ol class="round">
        <li class="one">
            <h5>Jehson Go</h5>
        </li>
        <li class="two">
            <h5>Nicklas Nilsen</h5>
        </li>
        <li class="three">
            <h5>Gisle Kvalvik</h5>
        </li>
    </ol>
</asp:Content>
