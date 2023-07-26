Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormComprasInformes
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
        ComboEstado.Text = "Todo"
    End Sub

#End Region
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        DataGridCompras.Rows.Clear()
        DataGridLineas.Rows.Clear()

        If RadioProveedor.Checked = True Then
            If ComboEstado.Text = "Todo" Then
                listarporproveedortodo()
            ElseIf ComboEstado.Text = "Recibido" Then
                listarporproveedorrecibido()
            Else
                listarporproveedorsinrecibir()
            End If
        ElseIf RadioFechas.Checked = True Then
            If ComboEstado.Text = "Todo" Then
                listarporfechatodo()
            ElseIf ComboEstado.Text = "Recibido" Then
                listarporfecharecibido()
            Else
                listarporfechasinrecibir()
            End If
        Else
            If ComboEstado.Text = "Todo" Then
                listarporproductotodo()
            ElseIf ComboEstado.Text = "Recibido" Then
                listarporproductorecibido()
            Else
                listarporproductosinrecibir()
            End If
        End If
    End Sub

    Private Sub RadioProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProveedor.CheckedChanged
        ocultar_campos()
    End Sub

    Private Sub RadioFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioFechas.CheckedChanged
        ocultar_campos()
    End Sub

    Private Sub ButtonBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProveedor.Click
        Dim v As New FormBuscarProveedor
        v.ShowDialog()
        If Not v.Proveedor Is Nothing Then
            Dim pro As dProveedores = v.Proveedor
            TextIdProveedor.Text = pro.ID
            TextProveedor.Text = pro.NOMBRE
        End If
    End Sub
    Private Sub ocultar_campos()
        If RadioProveedor.Checked = True Then
            TextIdProveedor.Enabled = True
            TextProveedor.Enabled = True
            ButtonBuscarProveedor.Enabled = True
            DateTimeDesde.Enabled = False
            DateTimeHasta.Enabled = False
            TextIdProducto.Enabled = False
            TextProducto.Enabled = False
            ButtonBuscarProducto.Enabled = False
        ElseIf RadioFechas.Checked = True Then
            TextIdProveedor.Enabled = False
            TextProveedor.Enabled = False
            ButtonBuscarProveedor.Enabled = False
            DateTimeDesde.Enabled = True
            DateTimeHasta.Enabled = True
            TextIdProducto.Enabled = False
            TextProducto.Enabled = False
            ButtonBuscarProducto.Enabled = False
        Else
            TextIdProveedor.Enabled = False
            TextProveedor.Enabled = False
            ButtonBuscarProveedor.Enabled = False
            DateTimeDesde.Enabled = False
            DateTimeHasta.Enabled = False
            TextIdProducto.Enabled = True
            TextProducto.Enabled = True
            ButtonBuscarProducto.Enabled = True

        End If
    End Sub
    Private Sub listarporproveedortodo()

        Dim c As New dCompras
        Dim texto As Long = TextIdProveedor.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarxproveedor(texto)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim filab As Integer = 0
        Dim columnab As Integer = 0
        DataGridCompras.Rows.Clear()
        DataGridLineas.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridCompras.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporproveedorrecibido()

        Dim c As New dCompras
        Dim texto As Long = TextIdProveedor.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarxproveedorrecibido(texto)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim filab As Integer = 0
        Dim columnab As Integer = 0
        DataGridCompras.Rows.Clear()
        DataGridLineas.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridCompras.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporproveedorsinrecibir()

        Dim c As New dCompras
        Dim texto As Long = TextIdProveedor.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarxproveedorsinrecibir(texto)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim filab As Integer = 0
        Dim columnab As Integer = 0
        DataGridCompras.Rows.Clear()
        DataGridLineas.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridCompras.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporfechatodo()
        Dim c As New dCompras
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = c.listarxfecha(fechad, fechah)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim filab As Integer = 0
        Dim columnab As Integer = 0
        DataGridCompras.Rows.Clear()
        DataGridLineas.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridCompras.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar2
                            If Not pro Is Nothing Then

                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                If pro.ELIMINADO = 1 Then
                                    DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                                    DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                                End If
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                If pro.ELIMINADO = 1 Then
                                    DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                                    DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                                End If
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporfecharecibido()
        Dim c As New dCompras
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = c.listarxfecharecibido(fechad, fechah)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim filab As Integer = 0
        Dim columnab As Integer = 0
        DataGridCompras.Rows.Clear()
        DataGridLineas.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridCompras.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporfechasinrecibir()
        Dim c As New dCompras
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = c.listarxfechasinrecibir(fechad, fechah)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        Dim filab As Integer = 0
        Dim columnab As Integer = 0
        DataGridCompras.Rows.Clear()
        DataGridLineas.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridCompras.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DataGridCompras_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridCompras.CellContentClick
        If DataGridCompras.Columns(e.ColumnIndex).Name = "Compra" Then
            Dim row As DataGridViewRow = DataGridCompras.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Compra").Value
            Dim lista As New ArrayList
            Dim lc As New dLineaCompra
            Dim c As New dCompras
            c.ID = id
            c = c.buscar
            lista = lc.listarxidcompra(id)
            DataGridLineas.Rows.Clear()
            If Not lista Is Nothing Then
                Dim filab As Integer = 0
                Dim columnab As Integer = 0
                DataGridLineas.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                    columnab = columnab + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar2
                    If Not pro Is Nothing Then
                        DataGridLineas(columnab, filab).Value = pro.CODIGO
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                        DataGridLineas(columnab, filab).Value = pro.NOMBRE
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                        DataGridLineas(columnab, filab).Value = ""
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                    End If
                    Dim u As New dUnidades
                    u.ID = lc.UNIDAD
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridLineas(columnab, filab).Value = u.NOMBRE
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                    columnab = columnab + 1
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        DataGridLineas(columnab, filab).Value = pre.NOMBRE
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    Dim m As New dMoneda
                    m.ID = lc.MONEDA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridLineas(columnab, filab).Value = m.SIMBOLO
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.PRECIO
                    columnab = columnab + 1
                    If c.RECIBIDO = 1 Then
                        DataGridLineas(columnab, filab).Value = "si"
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = "no"
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.FACTURA
                    columnab = 0
                    filab = filab + 1
                    pro = Nothing
                    u = Nothing
                    pre = Nothing
                    m = Nothing
                Next
                lc = Nothing
            End If
        End If
        If DataGridCompras.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridCompras.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Compra").Value
            Dim lista As New ArrayList
            Dim lc As New dLineaCompra
            Dim c As New dCompras
            c.ID = id
            c = c.buscar
            lista = lc.listarxidcompra(id)
            DataGridLineas.Rows.Clear()
            If Not lista Is Nothing Then
                Dim filab As Integer = 0
                Dim columnab As Integer = 0
                DataGridLineas.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                    columnab = columnab + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar2
                    If Not pro Is Nothing Then
                        DataGridLineas(columnab, filab).Value = pro.CODIGO
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                        DataGridLineas(columnab, filab).Value = pro.NOMBRE
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                        DataGridLineas(columnab, filab).Value = ""
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                    End If
                    Dim u As New dUnidades
                    u.ID = lc.UNIDAD
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridLineas(columnab, filab).Value = u.NOMBRE
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                    columnab = columnab + 1
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        DataGridLineas(columnab, filab).Value = pre.NOMBRE
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    Dim m As New dMoneda
                    m.ID = lc.MONEDA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridLineas(columnab, filab).Value = m.SIMBOLO
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.PRECIO
                    columnab = columnab + 1
                    If c.RECIBIDO = 1 Then
                        DataGridLineas(columnab, filab).Value = "si"
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = "no"
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.FACTURA
                    columnab = 0
                    filab = filab + 1
                    pro = Nothing
                    u = Nothing
                    pre = Nothing
                    m = Nothing
                Next
                lc = Nothing
            End If
        End If
        If DataGridCompras.Columns(e.ColumnIndex).Name = "Proveedor" Then
            Dim row As DataGridViewRow = DataGridCompras.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Compra").Value
            Dim lista As New ArrayList
            Dim lc As New dLineaCompra
            Dim c As New dCompras
            c.ID = id
            c = c.buscar
            lista = lc.listarxidcompra(id)
            DataGridLineas.Rows.Clear()
            If Not lista Is Nothing Then
                Dim filab As Integer = 0
                Dim columnab As Integer = 0
                DataGridLineas.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                    columnab = columnab + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar2
                    If Not pro Is Nothing Then
                        DataGridLineas(columnab, filab).Value = pro.CODIGO
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                        DataGridLineas(columnab, filab).Value = pro.NOMBRE
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                        DataGridLineas(columnab, filab).Value = ""
                        If pro.ELIMINADO = 1 Then
                            DataGridLineas(columnab, filab).Style.BackColor = Color.Red
                            DataGridLineas(columnab, filab).Style.ForeColor = Color.White
                        End If
                        columnab = columnab + 1
                    End If
                    Dim u As New dUnidades
                    u.ID = lc.UNIDAD
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridLineas(columnab, filab).Value = u.NOMBRE
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                    columnab = columnab + 1
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        DataGridLineas(columnab, filab).Value = pre.NOMBRE
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    Dim m As New dMoneda
                    m.ID = lc.MONEDA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridLineas(columnab, filab).Value = m.SIMBOLO
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = ""
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.PRECIO
                    columnab = columnab + 1
                    If c.RECIBIDO = 1 Then
                        DataGridLineas(columnab, filab).Value = "si"
                        columnab = columnab + 1
                    Else
                        DataGridLineas(columnab, filab).Value = "no"
                        columnab = columnab + 1
                    End If
                    DataGridLineas(columnab, filab).Value = lc.FACTURA
                    columnab = 0
                    filab = filab + 1
                    pro = Nothing
                    u = Nothing
                    pre = Nothing
                    m = Nothing
                Next
                lc = Nothing
            End If
        End If
    End Sub

    Private Sub RadioProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProducto.CheckedChanged
        ocultar_campos()
    End Sub
    Private Sub listarporproductotodo()
        Dim idproducto As Long = 0
        If TextIdProducto.Text <> "" Then
            idproducto = TextIdProducto.Text.Trim
        Else
            MsgBox("No se ha seleccionado ningún producto!")
            Exit Sub
            ButtonBuscarProducto.Focus()
        End If

        Dim listaproductos As New ArrayList
        Dim lcompra As New dLineaCompra
        listaproductos = lcompra.listarxidproducto2(idproducto)
        Dim idcompra As Long = 0
        If Not listaproductos Is Nothing Then
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            Dim filab As Integer = 0
            Dim columnab As Integer = 0
            DataGridCompras.Rows.Clear()
            DataGridLineas.Rows.Clear()
            DataGridCompras.Rows.Add(listaproductos.Count)
            For Each lcompra In listaproductos
                idcompra = lcompra.IDCOMPRA
                Dim c As New dCompras
                c.ID = idcompra
                c = c.buscar
                If Not c Is Nothing Then
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub listarporproductorecibido()
        Dim idproducto As Long = 0
        If TextIdProducto.Text <> "" Then
            idproducto = TextIdProducto.Text.Trim
        Else
            MsgBox("No se ha seleccionado ningún producto!")
            Exit Sub
            ButtonBuscarProducto.Focus()
        End If

        Dim listaproductos As New ArrayList
        Dim lcompra As New dLineaCompra
        listaproductos = lcompra.listarxidproducto2(idproducto)
        Dim idcompra As Long = 0
        If Not listaproductos Is Nothing Then
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            Dim filab As Integer = 0
            Dim columnab As Integer = 0
            DataGridCompras.Rows.Clear()
            DataGridLineas.Rows.Clear()
            DataGridCompras.Rows.Add(listaproductos.Count)
            For Each lcompra In listaproductos
                idcompra = lcompra.IDCOMPRA
                Dim c As New dCompras
                c.ID = idcompra
                c = c.buscarrecibido
                If Not c Is Nothing Then
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub listarporproductosinrecibir()
        Dim idproducto As Long = 0
        If TextIdProducto.Text <> "" Then
            idproducto = TextIdProducto.Text.Trim
        Else
            MsgBox("No se ha seleccionado ningún producto!")
            Exit Sub
            ButtonBuscarProducto.Focus()
        End If

        Dim listaproductos As New ArrayList
        Dim lcompra As New dLineaCompra
        listaproductos = lcompra.listarxidproducto2(idproducto)
        Dim idcompra As Long = 0
        If Not listaproductos Is Nothing Then
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            Dim filab As Integer = 0
            Dim columnab As Integer = 0
            DataGridCompras.Rows.Clear()
            DataGridLineas.Rows.Clear()
            DataGridCompras.Rows.Add(listaproductos.Count)
            For Each lcompra In listaproductos
                idcompra = lcompra.IDCOMPRA
                Dim c As New dCompras
                c.ID = idcompra
                c = c.buscarsinrecibir
                If Not c Is Nothing Then
                    DataGridCompras(columna, fila).Value = c.ID
                    columna = columna + 1
                    DataGridCompras(columna, fila).Value = c.FECHARECIBO
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridCompras(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridCompras(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        DataGridLineas.Rows.Add(listalc.Count)
                        For Each lc In listalc
                            DataGridLineas(columnab, filab).Value = lc.IDCOMPRA
                            columnab = columnab + 1
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pro.CODIGO
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = pro.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                DataGridLineas(columnab, filab).Value = u.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.CANTIDAD
                            columnab = columnab + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                DataGridLineas(columnab, filab).Value = pre.NOMBRE
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                DataGridLineas(columnab, filab).Value = m.SIMBOLO
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = ""
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.PRECIO
                            columnab = columnab + 1
                            If c.RECIBIDO = 1 Then
                                DataGridLineas(columnab, filab).Value = "si"
                                columnab = columnab + 1
                            Else
                                DataGridLineas(columnab, filab).Value = "no"
                                columnab = columnab + 1
                            End If
                            DataGridLineas(columnab, filab).Value = lc.FACTURA
                            columnab = 0
                            filab = filab + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub ButtonBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProducto.Click
        Dim v As New FormBuscarProducto
        v.ShowDialog()
        If Not v.Producto Is Nothing Then
            Dim pro As dProductos = v.Producto
            TextIdProducto.Text = pro.ID
            TextProducto.Text = pro.NOMBRE
        End If
    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        If RadioProveedor.Checked = True Then
            If ComboEstado.Text = "Todo" Then
                imprimirporproveedortodo()
            ElseIf ComboEstado.Text = "Recibido" Then
                imprimirporproveedorrecibido()
            Else
                imprimirporproveedorsinrecibir()
            End If
        ElseIf RadioFechas.Checked = True Then
            If ComboEstado.Text = "Todo" Then
                imprimirporfechatodo()
            ElseIf ComboEstado.Text = "Recibido" Then
                imprimirporfecharecibido()
            Else
                imprimirporfechasinrecibir()
            End If
        Else
            If ComboEstado.Text = "Todo" Then
                imprimirporproductotodo()
            ElseIf ComboEstado.Text = "Recibido" Then
                imprimirporproductorecibido()
            Else
                imprimirporproductosinrecibir()
            End If
        End If
    End Sub
    Private Sub imprimirporproveedortodo()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por proveedor (todas)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim c As New dCompras
        Dim texto As Long = TextIdProveedor.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarxproveedor(texto)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporproveedorrecibido()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por proveedor (recibidas)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim c As New dCompras
        Dim texto As Long = TextIdProveedor.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarxproveedorrecibido(texto)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporproveedorsinrecibir()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por proveedor (sin recibir)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim c As New dCompras
        Dim texto As Long = TextIdProveedor.Text.Trim
        Dim lista As New ArrayList
        lista = c.listarxproveedorsinrecibir(texto)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporfechatodo()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por fecha (todas)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim c As New dCompras
        Dim lista As New ArrayList
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        lista = c.listarxfecha(fechad, fechah)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporfecharecibido()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por fecha (recibidas)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim c As New dCompras
        Dim lista As New ArrayList
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        lista = c.listarxfecharecibido(fechad, fechah)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporfechasinrecibir()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por fecha (sin recibir)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim c As New dCompras
        Dim lista As New ArrayList
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        lista = c.listarxfechasinrecibir(fechad, fechah)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporproductotodo()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por producto (todas)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim idproducto As Long = 0
        If TextIdProducto.Text <> "" Then
            idproducto = TextIdProducto.Text.Trim
        Else
            MsgBox("No se ha seleccionado ningún producto!")
            Exit Sub
            ButtonBuscarProducto.Focus()
        End If

        Dim listaproductos As New ArrayList
        Dim lcompra As New dLineaCompra
        listaproductos = lcompra.listarxidproducto2(idproducto)
        Dim idcompra As Long = 0
        If Not listaproductos Is Nothing Then
            For Each lcompra In listaproductos
                idcompra = lcompra.IDCOMPRA
                Dim c As New dCompras
                c.ID = idcompra
                c = c.buscar
                If Not c Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                End If
            Next
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporproductorecibido()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por producto (recibidas)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim idproducto As Long = 0
        If TextIdProducto.Text <> "" Then
            idproducto = TextIdProducto.Text.Trim
        Else
            MsgBox("No se ha seleccionado ningún producto!")
            Exit Sub
            ButtonBuscarProducto.Focus()
        End If

        Dim listaproductos As New ArrayList
        Dim lcompra As New dLineaCompra
        listaproductos = lcompra.listarxidproducto2(idproducto)
        Dim idcompra As Long = 0
        If Not listaproductos Is Nothing Then
            For Each lcompra In listaproductos
                idcompra = lcompra.IDCOMPRA
                Dim c As New dCompras
                c.ID = idcompra
                c = c.buscarrecibido
                If Not c Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                End If
            Next
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimirporproductosinrecibir()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 15
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 15
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de compras - Por producto (sin recibir)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2

        Dim idproducto As Long = 0
        If TextIdProducto.Text <> "" Then
            idproducto = TextIdProducto.Text.Trim
        Else
            MsgBox("No se ha seleccionado ningún producto!")
            Exit Sub
            ButtonBuscarProducto.Focus()
        End If

        Dim listaproductos As New ArrayList
        Dim lcompra As New dLineaCompra
        listaproductos = lcompra.listarxidproducto2(idproducto)
        Dim idcompra As Long = 0
        If Not listaproductos Is Nothing Then
            For Each lcompra In listaproductos
                idcompra = lcompra.IDCOMPRA
                Dim c As New dCompras
                c.ID = idcompra
                c = c.buscarsinrecibir
                If Not c Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = "Compra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Fecha"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = "Proveedor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = c.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = c.FECHARECIBO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If

                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idcomp As Long = 0
                    idcomp = c.ID
                    listalc = lc.listarxidcompra(idcomp)
                    If Not listalc Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = "Código"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Producto"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Cantidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Presentación"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Moneda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Precio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Recibido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "Factura"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        For Each lc In listalc
                            Dim pro As New dProductos
                            pro.ID = lc.PRODUCTO
                            pro = pro.buscar
                            If Not pro Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pro.CODIGO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim u As New dUnidades
                            u.ID = lc.UNIDAD
                            u = u.buscar
                            If Not u Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = u.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.CANTIDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            Dim pre As New dPresentacionUnidades
                            pre.ID = lc.PRESENTACION
                            pre = pre.buscar
                            If Not pre Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = pre.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            Dim m As New dMoneda
                            m.ID = lc.MONEDA
                            m = m.buscar
                            If Not m Is Nothing Then
                                x1hoja.Cells(fila, columna).formula = m.SIMBOLO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = ""
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.PRECIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            If c.RECIBIDO = 1 Then
                                x1hoja.Cells(fila, columna).formula = "si"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "no"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 10
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                columna = columna + 1
                            End If
                            x1hoja.Cells(fila, columna).formula = lc.FACTURA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                            pro = Nothing
                            u = Nothing
                            pre = Nothing
                            m = Nothing
                        Next
                        lc = Nothing
                        fila = fila + 1
                    End If
                End If
            Next
        End If
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub FormComprasInformes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class