<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Thi_SV.DangNhap" %>
<asp:Content ID="Style" ContentPlaceHolderID="MainStyle" runat="server">
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        button {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
        }

        button:hover {
            opacity: 0.8;
        }

        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .container {
            padding: 16px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cancelbtn {
                width: 100%;
            }
        }

        #wrapper {
            width: 50%;
            margin: 50px auto;
            background-color:aliceblue;
        }

    </style>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
        <div class="imgcontainer">
            <img src="/Images/Nuce/img_avatar2.png" alt="Avatar" class="avatar" />
        </div>

        <div class="container">
            <label for="uname"><b>Username</b></label>
            <input type="text" placeholder="Enter Username" name="uname" id="unname" required="required" />

            <label for="psw"><b>Password</b></label>
            <input type="password" placeholder="Enter Password" name="psw" id="psw" required="required" />

            <button type="button" onclick="Login.login();">Login</button>
            <div id="divThongBao" style="color:red;font-weight:bold;"></div>
        </div>
        
    </div>
    <div id="ContentPane" runat="server"></div>
    <div id="dnn_ContentPane" class="cb DNNEmptyPane"></div>
    <script>
        var Login = {
            ID: -1,
            url: "/handler/nuce.thichungchi/",
            init: function () {
                $.getJSON(this.url + "tcc_check/", function (data) {
                    if (data == 1) {
                        window.location.href = "/Thi/DanhSachKiThi";
                    }
                });
            },
            login: function () {
                //Update
                console.log(1);
                var username = $('#unname').val();
                var pass = $('#psw').val();
                $.getJSON(this.url + "tcc_checklogin?ma=" + username + "&&pass=" + pass, function (data) {
                    if (data == 1) {
                        window.location.href = "/Thi/DanhSachKiThi";
                    }
                    else {
                        $('#divThongBao').html("Đăng nhập thất bại");
                    }
                });
            }
        };
        Login.init();
    </script>
</asp:Content>
