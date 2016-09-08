<%@ Page Title="" Language="C#" MasterPageFile="~/UnitecMaster.master" AutoEventWireup="true" CodeFile="GridAlumnos.aspx.cs" Inherits="GridAlumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="row" >
        <div class="col-xs-12" style="overflow:scroll">
            <asp:GridView runat="server" ID="gvAlumnos" CssClass="table table-responsive table-hover" ShowFooter="True" AutoGenerateColumns="False" DataKeyNames="id, sexoId" OnRowCancelingEdit="gvAlumnos_RowCancelingEdit" OnRowDeleting="gvAlumnos_RowDeleting" OnRowEditing="gvAlumnos_RowEditing" OnRowUpdating="gvAlumnos_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="[Nombre]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtNombre" runat="server" placeholder="Nombre Completo" Text='<%# Bind("nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="FTtxtNombre" placeholder="Nombre"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Fecha]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtFecha" runat="server" Text='<%# Bind("fecha", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate> 
                        <FooterTemplate>
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox runat="server" ID="FTtxtFecha" Width="150" class="form-control" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div> 
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Estatus]">
                        <EditItemTemplate>
                            <asp:CheckBox ID="EITchkEstatus" runat="server"  Checked='<%# Bind("estatus") %>'></asp:CheckBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="Label3" runat="server" Enabled="false" Checked='<%# Bind("estatus") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox runat="server" ID="FTchkEstatus" Text="&nbsp Estatus"/>       
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Promedio]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtPromedio" runat="server" placeholder="Promedio " Text='<%# Bind("promedio") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("promedio") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="FTtxtPromedio" placeholder="Promedio"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Sexo]">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="EITddlSexo" AppendDataBoundItems="true">
                                <asp:ListItem Text="Sexo" Value="0" />                                
                            </asp:DropDownList> 
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("sexo.nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList runat="server" ID="FTddlSexo" AppendDataBoundItems="true">
                                <asp:ListItem Text="Sexo" Value="0" />                                
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Foto]">
                        <EditItemTemplate>
                            <asp:FileUpload runat="server" ID="EITfuFoto"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("foto") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:FileUpload runat="server" ID="FTfuFoto" />  
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Telefono]">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Placeholder="Telefono" Text='<%# Bind("telefono") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ITlblTelefono" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate >
                            <asp:TextBox runat="server" ID="FTtxtTelefono" placeholder="Telefono"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Editar]" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="EITlnkActualizar" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="EITlnkCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="ITlnkEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Eliminar]" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="ITlnkEliminar" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
    <script src="js/moment-with-locales.js"></script>
    <script src="js/bootstrap-datetimepicker.js"></script>
    <script>
        $(document).ready(function () {
            $('#body_gvPeliculas_FTtxtFecha').datetimepicker({
                format: 'L',
                locale: 'es'
            });
        });
    </script>
</asp:Content>
