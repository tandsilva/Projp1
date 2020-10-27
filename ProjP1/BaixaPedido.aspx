<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaixaPedido.aspx.cs" Inherits="ProjP1.BaixaPedido" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
    <title>Funcionários - CRUD - GridView - MySQL</title>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <h2>Macoratti .net</h2>
    <hr/>
    <div class="table-striped">
    <asp:Panel ID="PanelFunci" runat="server" Width="810px">  
        <br />  
        <table class="table">  
            <tr>  
                <td>Funcionário</td>  
                <td>  
                    <asp:TextBox ID="txtNome" runat="server" Width="210px"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="vg1" ControlToValidate="txtNome"></asp:RequiredFieldValidator>  
                </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td>Salário</td>  
                <td>  
                    <asp:TextBox ID="txtSalario" runat="server"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="vg1" ControlToValidate="txtSalario"></asp:RequiredFieldValidator>  
                </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td>Cargo</td>  
                <td>  
                    <asp:TextBox ID="txtCargo" runat="server" Width="216px"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="vg1" ControlToValidate="txtCargo"></asp:RequiredFieldValidator>  
                </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td colspan="3">  
                    <asp:Button type="button" CssClass="btn btn-success" ID="btnSalvar" runat="server" Text="Salvar" ValidationGroup="vg1" OnClick="btnSalvar_Click" />  
                    <asp:Button type="button" CssClass="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" ValidationGroup="vg2" OnClick="btnCancelar_Click" />  
                </td>  
            </tr>  
        </table>  
        <asp:GridView ID="grdFuncionarios" runat="server" AutoGenerateColumns="False" OnRowEditing="grdFuncionarios_RowEditing" OnRowCancelingEdit="grdFuncionarios_RowCancelingEdit" 
OnRowUpdating="grdFuncionarios_RowUpdating" OnRowDeleting="grdFuncionarios_RowDeleting" Height="225px" Width="676px">  
            <Columns>  
                <asp:TemplateField HeaderText="Funcionario">  
                    <ItemTemplate>  
                        <asp:HiddenField ID="hfFunciId" Value='<% #Eval("id") %>' runat="server" />  
                        <asp:Label ID="lblNome" runat="server" Text='<% #Bind("nome") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:HiddenField ID="hfFunciId" Value='<% #Eval("id") %>' runat="server" />  
                        <asp:TextBox ID="txtGridNome" runat="server" Text='<% #Bind("nome") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Salario">  
                    <ItemTemplate>  
                        <asp:Label ID="lblSalario" runat="server" Text='<% #Bind("salario") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txtGridSalario" runat="server" Text='<% #Bind("salario") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                      <asp:TemplateField HeaderText="Cargo">  
                    <ItemTemplate>  
                        <asp:Label ID="lblCargo" runat="server" Text='<% #Bind("cargo") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txtGridCargo" runat="server" Text='<% #Bind("cargo") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                 <asp:CommandField ShowEditButton="true" ButtonType ="Image" EditImageUrl="Imagens/editar.jpg" UpdateImageUrl="Imagens/aceitar.jpg" CancelImageUrl="Imagens/erro.jpg" HeaderText="Editar" >
                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:CommandField>
                 <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="Imagens/erro.jpg" HeaderText="Deletar" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:CommandField>
            </Columns>  
        </asp:GridView>  
    </asp:Panel>  
    </div>
    </form>
</body>
</html>
