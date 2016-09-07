using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unitec.CRUD.Business;
using Unitec.CRUD.Business.Entity;

public partial class GridAlumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CargarGridAlumnos();
            }
        }
        catch (Exception ex)
        {

            MostraMensaje(ex.Message);
        }
    }

    private void CargarGridAlumnos()
    {
        EntTodo todo = new BusAlumno().ObtenerAlumnos();
        gvAlumnos.DataSource = todo.Alumnos;
        gvAlumnos.DataBind();
        int contador = 0;
        foreach (GridViewRow gvAl in gvAlumnos.Rows)
        {
            Label lbl = (Label)gvAlumnos.Rows[contador].FindControl("ITlblTelefono");
            foreach (EntTelefono tel in todo.Telefonos)
            {
                if ((gvAlumnos.DataKeys[contador].Values["id"]).ToString() == tel.alumnoId.ToString())
                {
                    lbl.Text += tel.numero.ToString() + "<br />";
                }
            }
            contador++;   
        }

        DropDownList ddlSexo = (DropDownList)gvAlumnos.FooterRow.FindControl("FTddlSexo");
        ddlSexo.DataSource = new BusAlumno().ObtenerSexo();
        ddlSexo.DataTextField = "nombre";
        ddlSexo.DataValueField = "id";
        ddlSexo.DataBind();
    }

    private void MostraMensaje(string mensaje)
    {
        string alerta = mensaje.Replace("\r","").Replace("\n","").Replace("'","");
        alerta = "alert('" + alerta + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta ,true);

    }
    protected void gvAlumnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvAlumnos.EditIndex = -1;
            CargarGridAlumnos();
        }
        catch (Exception ex)
        {

            MostraMensaje(ex.Message);
        }
    }
    protected void gvAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

            MostraMensaje(ex.Message);
        }
    }
    protected void gvAlumnos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvAlumnos.EditIndex = e.NewEditIndex;
            CargarGridAlumnos();
            DropDownList ddlSexo = (DropDownList)gvAlumnos.Rows[e.NewEditIndex].FindControl("EITddlSexo");
            ddlSexo.DataSource = new BusAlumno().ObtenerSexo();
            ddlSexo.DataTextField = "nombre";
            ddlSexo.DataValueField = "id";
            ddlSexo.DataBind();
            ddlSexo.SelectedValue = gvAlumnos.DataKeys[e.NewEditIndex].Values["sexoId"].ToString();
        }
        catch (Exception ex)
        {

            MostraMensaje(ex.Message);
        }
    }
    protected void gvAlumnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

            MostraMensaje(ex.Message);
        }
    }
}