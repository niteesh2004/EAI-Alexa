<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EAIWebTest.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link href="bootstrap.css" rel="stylesheet" />

    <link href="bootstrap.min.css" rel="stylesheet" />
    
    <!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h3 style="padding-left:450px"><i>List of Top 97 Domains </i></h3>
    <div style="padding-top:40px">
        
        <asp:GridView ID="GridDomains" runat="server" HorizontalAlign="Center" HeaderStyle-BackColor="cadetblue" BorderColor="wheat"></asp:GridView>
    </div>
    </form>
</body>
</html>
