<%@ Page Title="Memory Game" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Reto_Memoria.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Memory Game</h2>
    <asp:Panel ID="pnlCards" runat="server" CssClass="card-grid">
        <asp:Repeater ID="rptCards" runat="server">
            <ItemTemplate>
                <div class="card" onclick="flipCard(this)">
                    <img class="front" src='<%# Eval("ImagePath") %>' style="display: none;" />
                    <img class="back" src="Images/back.jpg" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>

    <asp:Button ID="btnReset" runat="server" Text="Reiniciar Juego" OnClick="btnReset_Click" CssClass="reset-button" />
</asp:Content>