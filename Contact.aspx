<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LegacyWebForms.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your contact page.</h3>
        <address>
            One Microsoft Way<br />
            Redmond, WA 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
        </address>

        <hr />
        
        <h3>Contact Form</h3>
        
        <asp:Panel ID="pnlForm" runat="server">
            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <label for="txtFrom" class="form-label">From:</label>
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" placeholder="Your name"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="your.email@example.com"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtMessage" class="form-label">Message:</label>
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Your message"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlSubmittedValues" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <strong>From:</strong><br />
                        <asp:Label ID="lblFromValue" runat="server"></asp:Label>
                    </div>
                    <div class="mb-3">
                        <strong>Email:</strong><br />
                        <asp:Label ID="lblEmailValue" runat="server"></asp:Label>
                    </div>
                    <div class="mb-3">
                        <strong>Message:</strong><br />
                        <asp:Label ID="lblMessageValue" runat="server"></asp:Label>
                    </div>
                    <asp:Label ID="lblSuccessMessage" runat="server" CssClass="text-success" Text="Message sent. Thank you!"></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </main>
</asp:Content>
