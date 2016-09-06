using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unitec.CRUD.Business;
using Unitec.CRUD.Business.Entity;

public partial class UnitecMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        EntUsuario ent = new BusAlumno().ValidarAlumno(txtMail.Text, txtPassword.Text);
        if (ent != null)
        {
            lblUsuario.Text = "Bienvenido" + ent.nombre;
            lnkEntrar.Text = "";
        }
        else
            lnkEntrar.Text = "Login";

    }
    protected void lnkSalir_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }
        catch (Exception ex)
        {
            
            MostrarMensage(ex.Message);
        }
    }

    private void MostrarMensage(string mensaje)
    {
        string alerta = mensaje.Replace("\n","").Replace("\r","").Replace("'","");
        alerta = "alert('" + alerta + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
    }
}
