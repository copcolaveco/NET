﻿Public Class FormControlDeMedios
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
        RadioEnUso.Checked = True
        listarenuso()
        'limpiar()
    End Sub

#End Region
    Private Sub listarenuso()
        Dim p As New dProductos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = p.listarmedios()
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    Dim producto As Long = 0
                    producto = p.ID
                    Dim lc As New dLineaCompra
                    lista2 = lc.listarenuso(producto)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            For Each lc In lista2
                                DataGridView1(columna, fila).Value = lc.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.PRODUCTO
                                columna = columna + 1
                                Dim pro As New dProductos
                                pro.ID = lc.PRODUCTO
                                pro = pro.buscar
                                If Not pro Is Nothing Then
                                    DataGridView1(columna, fila).Value = pro.NOMBRE
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = ""
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.LOTE
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.VENCIMIENTO
                                columna = columna + 1
                                If lc.APERTURA = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHAAPERTURA
                                columna = columna + 1
                                If lc.CONSUMIDO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHACONSUMIDO
                                columna = columna + 1
                                If lc.DESCARTADO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHADESCARTADO
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
                            'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarsinabrir()
        Dim p As New dProductos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = p.listarmedios()
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    Dim producto As Long = 0
                    producto = p.ID
                    Dim lc As New dLineaCompra
                    lista2 = lc.listarsinabrir(producto)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            For Each lc In lista2
                                DataGridView1(columna, fila).Value = lc.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.PRODUCTO
                                columna = columna + 1
                                Dim pro As New dProductos
                                pro.ID = lc.PRODUCTO
                                pro = pro.buscar
                                If Not pro Is Nothing Then
                                    DataGridView1(columna, fila).Value = pro.NOMBRE
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = ""
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.LOTE
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.VENCIMIENTO
                                columna = columna + 1
                                If lc.APERTURA = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHAAPERTURA
                                columna = columna + 1
                                If lc.CONSUMIDO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHACONSUMIDO
                                columna = columna + 1
                                If lc.DESCARTADO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHADESCARTADO
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarconsumidos()
        Dim p As New dProductos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = p.listarmedios()
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    Dim producto As Long = 0
                    producto = p.ID
                    Dim lc As New dLineaCompra
                    lista2 = lc.listarconsumidos(producto)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            For Each lc In lista2
                                DataGridView1(columna, fila).Value = lc.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.PRODUCTO
                                columna = columna + 1
                                Dim pro As New dProductos
                                pro.ID = lc.PRODUCTO
                                pro = pro.buscar
                                If Not pro Is Nothing Then
                                    DataGridView1(columna, fila).Value = pro.NOMBRE
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = ""
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.LOTE
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.VENCIMIENTO
                                columna = columna + 1
                                If lc.APERTURA = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHAAPERTURA
                                columna = columna + 1
                                If lc.CONSUMIDO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHACONSUMIDO
                                columna = columna + 1
                                If lc.DESCARTADO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHADESCARTADO
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listardescartados()
        Dim p As New dProductos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        lista = p.listarmedios()
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    Dim producto As Long = 0
                    producto = p.ID
                    Dim lc As New dLineaCompra
                    lista2 = lc.listardescartados(producto)
                    If Not lista2 Is Nothing Then
                        If lista2.Count > 0 Then
                            For Each lc In lista2
                                DataGridView1(columna, fila).Value = lc.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.PRODUCTO
                                columna = columna + 1
                                Dim pro As New dProductos
                                pro.ID = lc.PRODUCTO
                                pro = pro.buscar
                                If Not pro Is Nothing Then
                                    DataGridView1(columna, fila).Value = pro.NOMBRE
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = ""
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.LOTE
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = lc.VENCIMIENTO
                                columna = columna + 1
                                If lc.APERTURA = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHAAPERTURA
                                columna = columna + 1
                                If lc.CONSUMIDO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHACONSUMIDO
                                columna = columna + 1
                                If lc.DESCARTADO = 1 Then
                                    DataGridView1(columna, fila).Value = "Si"
                                    columna = columna + 1
                                Else
                                    DataGridView1(columna, fila).Value = "No"
                                    columna = columna + 1
                                End If
                                DataGridView1(columna, fila).Value = lc.FECHADESCARTADO
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub RadioEnUso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEnUso.CheckedChanged
        listarenuso()
    End Sub

    Private Sub RadioSinAbrir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSinAbrir.CheckedChanged
        listarsinabrir()
    End Sub

    Private Sub RadioConsumidos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioConsumidos.CheckedChanged
        listarconsumidos()
    End Sub

    Private Sub RadioDescartados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDescartados.CheckedChanged
        listardescartados()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim lc As New dLineaCompra
            id = row.Cells("Id").Value
            lc.ID = id
            lc = lc.buscar
            If Not lc Is Nothing Then
                TextId.Text = lc.ID
                If lc.APERTURA = 1 Then
                    CheckApertura.Checked = True
                    DateApertura.Value = lc.FECHAAPERTURA
                    DateApertura.Enabled = True
                Else
                    CheckApertura.Checked = False
                    DateApertura.Value = lc.FECHAAPERTURA
                    DateApertura.Enabled = False
                End If
                If lc.CONSUMIDO = 1 Then
                    CheckConsumido.Checked = True
                    DateConsumido.Value = lc.FECHACONSUMIDO
                    DateConsumido.Enabled = True
                Else
                    CheckConsumido.Checked = False
                    DateConsumido.Value = lc.FECHACONSUMIDO
                    DateConsumido.Enabled = False
                End If
                If lc.DESCARTADO = 1 Then
                    CheckDescartado.Checked = True
                    DateDescartado.Value = lc.FECHADESCARTADO
                    DateDescartado.Enabled = True
                Else
                    CheckDescartado.Checked = False
                    DateDescartado.Value = lc.FECHADESCARTADO
                    DateDescartado.Enabled = False
                End If
                DateVencimiento.Value = lc.VENCIMIENTO
                TextObservaciones.Text = lc.OBSERVACIONES
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        If TextId.Text.Length > 0 Then
            Dim apertura As Integer = 0
            Dim consumido As Integer = 0
            Dim descartado As Integer = 0
            Dim fechaapertura As Date = DateApertura.Value.ToString("yyyy-MM-dd")
            Dim fechaconsumido As Date = DateConsumido.Value.ToString("yyyy-MM-dd")
            Dim fechadescartado As Date = DateDescartado.Value.ToString("yyyy-MM-dd")
            Dim fechavencimiento As Date = DateVencimiento.Value.ToString("yyyy-MM-dd")
            If CheckApertura.Checked = True Then
                apertura = 1
            End If
            If CheckConsumido.Checked = True Then
                consumido = 1
            End If
            If CheckDescartado.Checked = True Then
                descartado = 1
            End If
            Dim observaciones As String = ""
            If TextObservaciones.Text <> "" Then
                observaciones = TextObservaciones.Text.Trim
            End If

            Dim lc As New dLineaCompra
            Dim id As Long = TextId.Text.Trim
            Dim fecapertura As String
            Dim fecconsumido As String
            Dim fecdescartado As String
            Dim fecvencimiento As String
            fecapertura = Format(fechaapertura, "yyyy-MM-dd")
            fecconsumido = Format(fechaconsumido, "yyyy-MM-dd")
            fecdescartado = Format(fechadescartado, "yyyy-MM-dd")
            fecvencimiento = Format(fechavencimiento, "yyyy-MM-dd")
            lc.ID = id
            lc.VENCIMIENTO = fecvencimiento
            lc.APERTURA = apertura
            lc.FECHAAPERTURA = fecapertura
            lc.CONSUMIDO = consumido
            lc.FECHACONSUMIDO = fecconsumido
            lc.DESCARTADO = descartado
            lc.FECHADESCARTADO = fecdescartado
            lc.OBSERVACIONES = observaciones
            If (lc.modificar3(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub limpiar()
        CheckApertura.Checked = False
        CheckConsumido.Checked = False
        CheckDescartado.Checked = False
        DateApertura.Value = Now
        DateConsumido.Value = Now
        DateDescartado.Value = Now
        DateVencimiento.Value = Now
        TextId.Text = ""
        TextObservaciones.Text = ""
        RadioEnUso.Checked = True
        listarenuso()

    End Sub
    Private Sub habilitarcontroles()
        If CheckApertura.Checked = True Then
            DateApertura.Enabled = True
        Else
            DateApertura.Enabled = False
        End If
        If CheckConsumido.Checked = True Then
            DateConsumido.Enabled = True
        Else
            DateConsumido.Enabled = False
        End If
        If CheckDescartado.Checked = True Then
            DateDescartado.Enabled = True
        Else
            DateDescartado.Enabled = False
        End If
    End Sub

    Private Sub CheckApertura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckApertura.CheckedChanged
        habilitarcontroles()
    End Sub

    Private Sub CheckConsumido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckConsumido.CheckedChanged
        habilitarcontroles()
    End Sub

    Private Sub CheckDescartado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDescartado.CheckedChanged
        habilitarcontroles()
    End Sub
End Class