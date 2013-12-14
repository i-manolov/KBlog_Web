<%@ Page Title="" Language="C#" MasterPageFile="~/Guest.Master" AutoEventWireup="true"
    CodeBehind="GuestHome.aspx.cs" Inherits="K_Blog.GuestHome2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main jumbotron for a primary marketing message or call to action -->
    <div style='border-style: ridge; border-bottom-width: 5px; box-shadow: 10px 10px 5px #888888;'>
        <div class="container">
            <h1>
                Welcome to K-Blog!</h1>
            <img src="img/kinect.jpg" style='float: right; z-index: -1; width: 50%;'>
            <p style='font-size: 1.3em;'>
                <br />
                The first and only blog that let's you upload media recorded from your Kinect for
                the XBox 360.</p>
            <p>
                <a href='Registration.aspx' class="btn btn-primary btn-lg">Sign Up &raquo;</a></p>
        </div>
    </div>
    <br />
    <br /><br />
    <div class="container">
        <!-- Example row of columns -->
        <div class="row">
            <div class="col-lg-6">
                <h3>
                    Capture Color, Black & White, Infrared Photos</h3>
                <p>
                    Ever felt the need to snap a photo quickly? K-Blog allows you to without
                    moving away the TV. Capture the photo for your need. If it's dark and you 
                    do not want to turn on the lights and wake up every one, then use the infrared
                    mode. Need a colorful or a black and white photo? K-Blog lets you do that as well
                </p>
            </div>
            <div class="col-lg-6">
                <h3>
                    Record Audio</h3>
                <p>
                   Record audio clips whenever you want with k-blog. It allows you to use your Kinect XBox 360
                   as a microphone and record your thoughts, to do lists, or anything else
                   you'd want to share with anyone.
                </p>

            </div>
           
        </div>
    </div>
</asp:Content>
