Public Class FormListadodeCompras
    Dim compraid As Long = 0
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
        listarcomprasautorizadas()
        listarcomprassinautorizar()
        'limpiar()
    End Sub

#End Region
    Private Sub listarcomprasautorizadas()
        Dim c As New dCompras
        Dim lc As New dLineaCompra
        Dim lista As New ArrayList
        lista = c.listarautorizadas
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
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
    Private Sub listarcomprassinautorizar()
        Dim c As New dCompras

        Dim lista As New ArrayList
        lista = c.listarsinautorizar
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each c In lista
                    Dim lc As New dLineaCompra
                    lc.IDCOMPRA = c.ID
                    lc = lc.buscarxidcompra
                    If Not lc Is Nothing Then
                        DataGridView2(columna, fila).Value = c.ID
                        columna = columna + 1
                        Dim pro As New dProveedores
                        pro.ID = c.PROVEEDOR
                        pro = pro.buscar
                        If Not pro Is Nothing Then
                            DataGridView2(columna, fila).Value = pro.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        DataGridView2(columna, fila).Value = c.FECHA
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
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
            End If
            listarlineas()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Proveedor" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
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
            End If
            listarlineas()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("Id").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
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
            End If
            listarlineas()
        End If
    End Sub
    Private Sub listarlineas()
        Dim lc As New dLineaCompra
        Dim idcompra As Long = TextIdCompra.Text
        Dim lista As New ArrayList
        Dim subtotal As Double = 0
        lista = lc.listarxidcompra(idcompra)
        DataGridView3.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView3.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridView3(columna, fila).Value = lc.ID
                    columna = columna + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        DataGridView3(columna, fila).Value = pro.NOMBRE
                        columna = columna + 1
                        DataGridView3(columna, fila).Value = pro.DETALLE
                        columna = columna + 1
                    End If
                    DataGridView3(columna, fila).Value = lc.PRECIOANT
                    columna = columna + 1
                    If lc.MONEDAANT = 0 Then
                        DataGridView3(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDAANT = 1 Then
                        DataGridView3(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    DataGridView3(columna, fila).Value = lc.FECHAPRECIOANT
                    columna = columna + 1
                    DataGridView3(columna, fila).Value = lc.CANTIDAD
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = lc.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        DataGridView3(columna, fila).Value = uni.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView3(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        DataGridView3(columna, fila).Value = pre.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView3(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView3(columna, fila).Value = lc.PRECIO
                    columna = columna + 1
                    If lc.MONEDA = 0 Then
                        DataGridView3(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDA = 1 Then
                        DataGridView3(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    subtotal = lc.CANTIDAD * lc.PRECIO
                    DataGridView3(columna, fila).Value = subtotal
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Id2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("Id2").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
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
            End If
            listarlineas()
        ElseIf DataGridView2.Columns(e.ColumnIndex).Name = "Proveedor2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("Id2").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
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
            End If
            listarlineas()
        ElseIf DataGridView2.Columns(e.ColumnIndex).Name = "Fecha2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("Id2").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
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
            End If
            listarlineas()
        End If
    End Sub
End Class