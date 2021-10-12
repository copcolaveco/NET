Public Class FormRecibirCompra
    Private completada As Integer
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
        listarcompras()
        'limpiar()
    End Sub

#End Region
    Private Sub listarcompras()
        Dim c As New dCompras

        Dim lista As New ArrayList
        lista = c.listarsinrecibir
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    Dim lc As New dLineaCompra
                    lc.IDCOMPRA = c.ID
                    lc = lc.buscarxidcompra
                    If Not lc Is Nothing Then
                        DataGridView1(columna, fila).Value = c.ID
                        columna = columna + 1
                        Dim pro As New dProveedores
                        pro.ID = c.PROVEEDOR
                        pro = pro.buscar
                        If Not pro Is Nothing Then
                            DataGridView1(columna, fila).Value = pro.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = c.FECHA
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "IdCompra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("IdCompra").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                DateFecha.Value = c.FECHA
                Dim r As New dUsuario
                r.ID = c.USUARIOCREADOR
                r = r.buscar
                If Not r Is Nothing Then
                    TextResponsable.Text = r.NOMBRE
                End If
                Dim p As New dProveedores
                p.ID = c.PROVEEDOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProveedor.Text = p.NOMBRE
                End If
                TextObservaciones.Text = c.OBSERVACIONES
            End If
            listarlineas()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Proveedor" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("IdCompra").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                DateFecha.Value = c.FECHA
                Dim r As New dUsuario
                r.ID = c.USUARIOCREADOR
                r = r.buscar
                If Not r Is Nothing Then
                    TextResponsable.Text = r.NOMBRE
                End If
                Dim p As New dProveedores
                p.ID = c.PROVEEDOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProveedor.Text = p.NOMBRE
                End If
                TextObservaciones.Text = c.OBSERVACIONES
            End If
            listarlineas()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("IdCompra").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                DateFecha.Value = c.FECHA
                Dim r As New dUsuario
                r.ID = c.USUARIOCREADOR
                r = r.buscar
                If Not r Is Nothing Then
                    TextResponsable.Text = r.NOMBRE
                End If
                Dim p As New dProveedores
                p.ID = c.PROVEEDOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProveedor.Text = p.NOMBRE
                End If
                TextObservaciones.Text = c.OBSERVACIONES
            End If
            listarlineas()
        End If
    End Sub
    Private Sub listarlineas()
        completada = 1
        Dim lc As New dLineaCompra
        Dim idcompra As Long = TextIdCompra.Text
        Dim lista As New ArrayList
        lista = lc.listarxidcompra(idcompra)
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridView2(columna, fila).Value = lc.ID
                    columna = columna + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        DataGridView2(columna, fila).Value = pro.CODIGO
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = pro.NOMBRE
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = pro.DETALLE
                        columna = columna + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView2(columna, fila).Value = lc.CANTIDAD
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = lc.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        DataGridView2(columna, fila).Value = uni.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        DataGridView2(columna, fila).Value = pre.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView2(columna, fila).Value = lc.PRECIO
                    columna = columna + 1
                    If lc.MONEDA = 0 Then
                        DataGridView2(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDA = 1 Then
                        DataGridView2(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    If lc.NOCUMPLE = 0 Then
                        If lc.LOTE <> "" And lc.LOCACION <> 0 And lc.PRECIO <> 0 Then
                            DataGridView2(columna, fila).Value = "si"
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = "no"
                            columna = columna + 1
                            completada = 0
                        End If
                        DataGridView2(columna, fila).Value = "si"
                        columna = 0
                        fila = fila + 1
                    Else
                        If lc.LOTE <> "" And lc.LOCACION <> 0 And lc.PRECIO <> 0 Then
                            DataGridView2(columna, fila).Value = "si"
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = "no"
                            columna = columna + 1
                            completada = 1
                        End If
                        DataGridView2(columna, fila).Value = "no"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Completar" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id").Value
            Dim v As New FormCompletarCompra(Usuario, id)
            v.ShowDialog()
            listarlineas()
        End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "NoCumple" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id").Value
            Dim v As New FormNoCumple(Usuario, id)
            v.ShowDialog()
            listarlineas()
        End If
    End Sub

    Private Sub ButtonRecibir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecibir.Click
        If completada = 0 Then
            MsgBox("Debe completar las líneas de compra antes de aceptarla")
            Exit Sub
        Else
            Dim c As New dCompras
            Dim fecharecibo As Date = DateFechaRecibo.Value.ToString("yyyy-MM-dd")
            Dim fecrec As String
            Dim aceptado As Integer = 0
            Dim observaciones As String = ""
            If TextObservaciones.Text <> "" Then
                observaciones = TextObservaciones.Text
            End If
            fecrec = Format(fecharecibo, "yyyy-MM-dd")
            c.ID = TextIdCompra.Text
            If CheckAceptado.Checked = True Then
                aceptado = 1
            Else
                aceptado = 0
            End If
            c.FECHARECIBO = fecrec
            c.ACEPTADO = aceptado
            c.OBSERVACIONES = observaciones
            c.USUARIORECIBE = Usuario.ID
            If (c.marcarrecibido(Usuario)) Then
                limpiar()
                listarcompras()
                DataGridView2.Rows.Clear()
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextIdCompra.Text = ""
        DateFecha.Value = Now
        TextResponsable.Text = ""
        TextProveedor.Text = ""
        TextObservaciones.Text = ""
        DateFechaRecibo.Value = Now
        CheckAceptado.Checked = False
    End Sub

End Class