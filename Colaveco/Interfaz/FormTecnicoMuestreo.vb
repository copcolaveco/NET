Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Imports Newtonsoft.Json

Public Class FormTecnicoMuestreo
    Private _dUsuario As dUsuario

    Public Sub New(dUsuario As dUsuario)
        ' TODO: Complete member initialization 
        _dUsuario = dUsuario

        InitializeComponent()
        listar()
    End Sub

    Private Sub listar()
        Dim l As New dTecnicoMuestreo
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listarTodos()
        dgvTecnicos.Rows.Clear()
        dgvTecnicos.Rows.Add(lista.Count)
        
        If Not lista Is Nothing Then
            For Each l In lista
                
                dgvTecnicos(columna, fila).Value = l.TECNICO_MUESTREO_ID
                columna = columna + 1
                dgvTecnicos(columna, fila).Value = l.NOMBRE
                columna = columna + 1
                dgvTecnicos(columna, fila).Value = l.APELLIDO
                columna = 0
                fila = fila + 1
                
            Next
        End If
    End Sub

    Private Sub dgvTecnicos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTecnicos.CellContentClick
        If dgvTecnicos.Columns(e.ColumnIndex).Name = "Editar" Then
            Dim row As DataGridViewRow = dgvTecnicos.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim d As New dTecnicoMuestreo
            id = row.Cells("Id").Value
            d.TECNICO_MUESTREO_ID = id
            d = d.buscarById
            If Not d Is Nothing Then
                txtId.Text = d.TECNICO_MUESTREO_ID
                txtNombre.Text = d.NOMBRE
                txtApellido.Text = d.APELLIDO
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        Dim nombre As String
        Dim apellido As String

        If Not txtNombre.Text Is Nothing Then
            nombre = txtNombre.Text
        Else
            MsgBox("Agregar Nombre", MsgBoxStyle.Information, "Atención")
        End If

        If Not txtApellido.Text Is Nothing Then
            apellido = txtApellido.Text
        Else
            MsgBox("Agregar Apellido", MsgBoxStyle.Information, "Atención")
        End If

        Dim d As New dTecnicoMuestreo
        d.NOMBRE = nombre
        d.APELLIDO = apellido
        d.ESTATUS = 2

        If (d.guardar(_dUsuario)) Then
            MsgBox("Tecnico guardado", MsgBoxStyle.Information, "Atención")
            listar()
            Limpiar()
        Else
            MsgBox("Error al guardar", MsgBoxStyle.Critical, "Atención")
        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim nombre As String
        Dim apellido As String
        Dim id As Long = 0

        If Not txtNombre.Text Is Nothing Then
            nombre = txtNombre.Text
        Else
            MsgBox("Agregar Nombre", MsgBoxStyle.Information, "Atención")
        End If

        If Not txtApellido.Text Is Nothing Then
            apellido = txtApellido.Text
        Else
            MsgBox("Agregar Apellido", MsgBoxStyle.Information, "Atención")
        End If

        Dim d As New dTecnicoMuestreo

        If Not txtId.Text Is Nothing Then
            id = txtId.Text
            d.TECNICO_MUESTREO_ID = id

            d = d.buscarById()

            d.NOMBRE = nombre
            d.APELLIDO = apellido

            If (d.modificar(_dUsuario)) Then
                MsgBox("Tecnico modificado", MsgBoxStyle.Information, "Atención")
                listar()
                Limpiar()
            Else
                MsgBox("Error al modificar", MsgBoxStyle.Critical, "Atención")
            End If

        Else
            MsgBox("Seleccione un Tècnico para continuar", MsgBoxStyle.Information, "Atención")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim id As Long = 0
        Dim d As New dTecnicoMuestreo

        If txtId.Text <> "" Then
            id = txtId.Text
            d.TECNICO_MUESTREO_ID = id

            d = d.buscarById()
            d.ESTATUS = 1

            If (d.eliminar(_dUsuario)) Then
                MsgBox("Tecnico eliminado", MsgBoxStyle.Information, "Atención")
                listar()
                Limpiar()
            Else
                MsgBox("Error al eliminar", MsgBoxStyle.Critical, "Atención")
            End If

        Else
            MsgBox("Seleccione un Tècnico para continuar", MsgBoxStyle.Information, "Atención")
        End If
    End Sub

    Public Sub Limpiar()
        txtId.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
End Class