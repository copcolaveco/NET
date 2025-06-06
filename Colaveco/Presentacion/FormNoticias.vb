﻿Public Class FormNoticias
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        limpiar()
    End Sub

#End Region
    Public Sub cargarLista()
        Dim n As New dNoticias
        Dim lista As New ArrayList
        lista = n.listar
        ListNoticias.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    ListNoticias.Items.Add(n)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextDescripcion.Text = ""
        DateFecha.Value = Now
    End Sub

    Private Sub ListNoticias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListNoticias.SelectedIndexChanged
        If ListNoticias.SelectedItems.Count = 1 Then
            Dim noti As dNoticias = CType(ListNoticias.SelectedItem, dNoticias)
            TextId.Text = noti.ID
            TextDescripcion.Text = noti.DESCRIPCION
            DateFecha.Value = noti.FECHA
            TextDescripcion.Focus()
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim descripcion As String = TextDescripcion.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If Not ListNoticias.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextDescripcion.Text.Trim.Length > 0 Then
                Dim noti As New dNoticias()
                Dim id As Long = TextId.Text.Trim
                noti.ID = id
                noti.DESCRIPCION = descripcion
                Dim fec As String
                fec = Format(fecha, "yyyy-MM-dd")
                noti.FECHA = fec
                If (noti.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextDescripcion.Text.Trim.Length > 0 Then
                Dim noti As New dNoticias()
                noti.DESCRIPCION = descripcion
                Dim fec As String
                fec = Format(fecha, "yyyy-MM-dd")
                noti.FECHA = fec
                If (noti.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub
End Class