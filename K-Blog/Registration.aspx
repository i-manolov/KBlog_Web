<%@ Page Title="" Language="C#" MasterPageFile="~/Guest.Master" AutoEventWireup="true"
    CodeBehind="Registration.aspx.cs" Inherits="K_Blog.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin: 10px;" runat="server" id="sign_up_div" visible="true">
        <div class="row" style='border-bottom-style: ridge; border-botton-width: 2px;'>
            <h2>
                New Registration</h2>
        </div>
        <br />
        <div class="form-group">
            <div class='col-md-4'>
            </div>
            <div class="col-md-4">
                <input runat="server" type="text" class="form-control" id="firstname" placeholder="Enter First Name"
                    required />
            </div>
            <div class='col-md-4'>
            </div>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class='col-md-4'>
            </div>
            <div class="col-md-4">
                <input runat="server" type="text" class="form-control" id="lastname" placeholder="Enter Last Name"
                    required />
            </div>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class='col-md-4'>
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" class="form-control" ID="emailaddress" placeholder="Enter email address : yourname@domain.com"
                    required OnTextChanged='CheckEmail'></asp:TextBox>
            </div>
            <asp:Label runat="server" ID='emailExistsLbl' Text='Email Already Exists in Database'
                ForeColor='red' Font-Bold="True" Visible="false"></asp:Label>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class='col-md-4'>
            </div>
            <div class="col-md-4">
                <input runat="server" type="password" class="form-control" id="password" placeholder="Enter Password"
                    required />
            </div>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class='col-md-4'>
            </div>
            <div class="col-md-4">
                <input runat="server" type="password" class="form-control" id="passwordagain" placeholder="Enter Password Again"
                    data-validation-matches-match="password" data-validation-matches-message="Must match password entered above"
                    required />
            </div>
            <div class='col-md-4'>
            </div>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class='col-md-4'>
            </div>
            <div class="col-md-4">
                <label class='help-block' for='isprivatecb' style='display:inline;'>Make your Account Private?  </label>
                <input runat="server" type="checkbox" class="'checkbox-inline " id="isprivatecb" />
            </div>
            <div class='col-md-4'>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-5" style='position: absolute; left: 40%;'>
                <asp:Button ID='registerBtn' runat="server" class="btn btn-info" Text='Register'
                    OnClick="registerBtn_Click" />
            </div>
        </div>
        <br />
    </div>
    <div id='successfull_login_div' runat="server" visible="false" class='jumbotron'>
        <label runat="server" id='successLbl' class='label, h2' style='color:Black' >You have successfully signed up</label>
        <br />
        <label runat="server" id="Label1" class='label' style='color:Black'>Use the following Kinect GUID to login into your Kinect App and start uploading your media: </label>
        <label runat="server" id="kinectGUIDLbl" class='label' style='color:Black'></label>
    </div>
</asp:Content>
