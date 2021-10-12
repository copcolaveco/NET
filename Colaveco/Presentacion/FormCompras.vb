Public Class FormCompras
#Region "Atributos"
    Private _usuario As dUsuario
    Private idcotizacion As Long = 0
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
        cargarUnidades()
        cargarPresentacion()
        cargarmonedas()
        ComboEmail.Enabled = False
        'limpiar()
    End Sub

#End Region
    Public Sub cargarUnidades()
        Dim uni As New dUnidades
        Dim lista As New ArrayList
        lista = uni.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each uni In lista
                    ComboUnidad.Items.Add(uni)
                Next
            End If
        End If
    End Sub
    Public Sub cargarPresentacion()
        Dim p As New dPresentacionUnidades
        Dim lista As New ArrayList
        lista = p.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ComboPresentacion.Items.Add(p)
                Next
            End If
        End If
    End Sub
    Public Sub cargarMonedas()
        Dim m As New dMoneda
        Dim lista As New ArrayList
        lista = m.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ComboMoneda.Items.Add(m)
                    ComboMonedaAnterior.Items.Add(m)
                Next
            End If
        End If
    End Sub
  
    Private Sub guardarcabezal()
        If TextProveedor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el proveedor", MsgBoxStyle.Exclamation, "Atención") : ButtonBuscarProveedor.Focus() : Exit Sub
        Dim proveedor As Integer = TextIdProveedor.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim usuariocreador As Integer = Usuario.ID
        Dim usuarioautoriza As Integer = 0
        Dim autoriza As Integer = 0
        Dim enviado As Integer = 0
        Dim aceptado As Integer = 0
        Dim usuariorecibe As Integer = 0
        Dim anulada As Integer = 0
        Dim cotizacion As Long = 0
        If idcotizacion <> 0 Then
            cotizacion = idcotizacion
        End If
        If TextId.Text <> "" Then
            Dim c As New dCompras
            Dim id As Long = TextId.Text.Trim
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.ID = id
            c.PROVEEDOR = proveedor
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.USUARIOAUTORIZA = usuarioautoriza
            c.FECHAAUTORIZA = fec
            c.AUTORIZA = autoriza
            c.ENVIADO = enviado
            c.FECHARECIBO = fec
            c.ACEPTADO = aceptado
            c.USUARIORECIBE = usuariorecibe
            c.ANULADA = anulada
            c.COTIZACION = cotizacion
            If (c.modificar(Usuario)) Then
                'MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")

            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim c As New dCompras
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.PROVEEDOR = proveedor
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.USUARIOAUTORIZA = usuarioautoriza
            c.FECHAAUTORIZA = fec
            c.AUTORIZA = autoriza
            c.ENVIADO = enviado
            c.FECHARECIBO = fec
            c.ACEPTADO = aceptado
            c.USUARIORECIBE = usuariorecibe
            c.ANULADA = anulada
            c.COTIZACION = cotizacion
            If (c.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                buscarultimoid()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub buscarultimoid()
        Dim c As New dCompras
        Dim id As Long = 0
        c = c.buscarultimoid()
        If Not c Is Nothing Then
            id = c.ID
            TextId.Text = id
        End If
    End Sub

    Private Sub agregarlinea()
        If TextId.Text.Trim.Length = 0 Then MsgBox("Seleccione un proveedor", MsgBoxStyle.Exclamation, "Atención") : ButtonBuscarProveedor.Focus() : Exit Sub
        If TextIdProducto.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado un producto", MsgBoxStyle.Exclamation, "Atención") : TextIdProducto.Focus() : Exit Sub
        If TextCantidad.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la cantidad", MsgBoxStyle.Exclamation, "Atención") : TextCantidad.Focus() : Exit Sub
        If ComboUnidad.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado una unidad", MsgBoxStyle.Exclamation, "Atención") : ComboUnidad.Focus() : Exit Sub
        If ComboPresentacion.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado una presentación", MsgBoxStyle.Exclamation, "Atención") : ComboPresentacion.Focus() : Exit Sub
        Dim idcompra As Integer = TextId.Text.Trim
        Dim producto As Integer = TextIdProducto.Text
        Dim unidad As dUnidades = CType(ComboUnidad.SelectedItem, dUnidades)
        Dim cantidad As Double = TextCantidad.Text
        Dim presentacion As dPresentacionUnidades = CType(ComboPresentacion.SelectedItem, dPresentacionUnidades)
        Dim precioant As Double = 0
        If TextPrecioAnterior.Text <> "" Then
            precioant = TextPrecioAnterior.Text.Trim
        End If
        Dim monedaant As Integer = 0
        If ComboMonedaAnterior.Text = "$" Then
            monedaant = 0
        ElseIf ComboMonedaAnterior.Text = "U$S" Then
            monedaant = 1
        End If
        Dim fechaprecioant As Date = DateUltimaCompra.Value.ToString("yyyy-MM-dd")
        Dim lote As String = ""
        Dim fechavenc As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim locacion As Integer = 0
        Dim precio As Double = 0
        If TextPrecio.Text <> "" Then
            precio = TextPrecio.Text.Trim
        End If
        Dim moneda As Integer = 0
        If ComboMoneda.Text = "$" Then
            moneda = 0
        ElseIf ComboMoneda.Text = "U$S" Then
            moneda = 1
        End If
        Dim nocumple As Integer = 0
        If TextIdLinea.Text <> "" Then
            Dim lc As New dLineaCompra
            Dim id As Long = TextIdLinea.Text.Trim
            Dim fecprecioant As String
            fecprecioant = Format(fechaprecioant, "yyyy-MM-dd")
            Dim fecven As String
            fecven = Format(fechavenc, "yyyy-MM-dd")
            lc.ID = id
            lc.IDCOMPRA = idcompra
            lc.PRODUCTO = producto
            lc.UNIDAD = unidad.ID
            lc.CANTIDAD = cantidad
            lc.PRESENTACION = presentacion.ID
            lc.PRECIOANT = precioant
            lc.MONEDAANT = monedaant
            lc.FECHAPRECIOANT = fecprecioant
            lc.LOTE = lote
            lc.VENCIMIENTO = fecven
            lc.LOCACION = locacion
            lc.PRECIO = precio
            lc.MONEDA = moneda
            lc.NOCUMPLE = nocumple
            If (lc.modificar(Usuario)) Then
                'MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                listarlineas()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim lc As New dLineaCompra
            Dim fecprecioant As String
            fecprecioant = Format(fechaprecioant, "yyyy-MM-dd")
            Dim fecven As String
            fecven = Format(fechavenc, "yyyy-MM-dd")
            lc.IDCOMPRA = idcompra
            lc.PRODUCTO = producto
            lc.UNIDAD = unidad.ID
            lc.CANTIDAD = cantidad
            lc.PRESENTACION = presentacion.ID
            lc.PRECIOANT = precioant
            lc.MONEDAANT = monedaant
            lc.FECHAPRECIOANT = fecprecioant
            lc.LOTE = lote
            lc.VENCIMIENTO = fecven
            lc.LOCACION = locacion
            lc.PRECIO = precio
            lc.MONEDA = moneda
            lc.NOCUMPLE = nocumple
            If (lc.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                listarlineas()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub agregarlineacotizacion()
        Dim lcot As New dLineaCotizacion
        Dim lista As New ArrayList
        Dim idcompra As Integer = TextId.Text.Trim
        Dim producto As Integer = 0
        Dim cantidad As Double = 0
        Dim unidad As Integer = 0
        Dim presentacion As Integer = 0
        Dim precioant As Double = 0
        Dim monedaant As Integer = 0
        Dim fechaprecioant As Date
        Dim precio As Double = 0
        Dim moneda As Integer = 0
        Dim fechavenc As Date = DateFecha.Value.ToString("yyyy-MM-dd")

        lista = lcot.listarxidcotizacion(idcotizacion)
        If Not lista Is Nothing Then
            For Each lcot In lista
                Dim lc As New dLineaCompra
                Dim fecven As String
                Dim fecprecioanterior
                producto = lcot.PRODUCTO
                'Dim p As New dProductos
                'p.ID = lcot.PRODUCTO
                'p = p.buscar
                'If Not p Is Nothing Then
                '    unidad = p.UNIDAD
                'End If
                cantidad = lcot.CANTIDAD
                unidad = lcot.UNIDAD
                presentacion = lcot.PRESENTACION
                precioant = lcot.PRECIO
                monedaant = lcot.MONEDA
                fechaprecioant = lcot.FECHAPRECIO
                fecprecioanterior = Format(fechaprecioant, "yyyy-MM-dd")
                fecven = Format(fechavenc, "yyyy-MM-dd")

                lc.IDCOMPRA = idcompra
                lc.PRODUCTO = producto
                lc.CANTIDAD = cantidad
                lc.UNIDAD = unidad
                lc.PRESENTACION = presentacion
                lc.PRECIOANT = precioant
                lc.MONEDAANT = monedaant
                lc.FECHAPRECIOANT = fecprecioanterior
                lc.VENCIMIENTO = fecven
                If (lc.guardar(Usuario)) Then
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    listarlineas()
                    limpiar2()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Next

        End If
    End Sub
    Private Sub listarlineas()
        Dim lc As New dLineaCompra
        Dim idcompra As Long = TextId.Text
        Dim lista As New ArrayList
        Dim subtotal As Double = 0
        lista = lc.listarxidcompra(idcompra)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridView1(columna, fila).Value = lc.ID
                    columna = columna + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        DataGridView1(columna, fila).Value = pro.NOMBRE
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = pro.DETALLE
                        columna = columna + 1
                      
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = lc.PRECIOANT
                    columna = columna + 1
                    If lc.MONEDAANT = 0 Then
                        DataGridView1(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDAANT = 1 Then
                        DataGridView1(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = lc.FECHAPRECIOANT
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lc.CANTIDAD
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = lc.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        DataGridView1(columna, fila).Value = uni.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim p As New dPresentacionUnidades
                    p.ID = lc.PRESENTACION
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = lc.PRECIO
                    columna = columna + 1
                    subtotal = lc.CANTIDAD * lc.PRECIO
                    If lc.MONEDA = 0 Then
                        DataGridView1(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDA = 1 Then
                        DataGridView1(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = subtotal
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextIdProveedor.Text = ""
        TextProveedor.Text = ""
        ComboEmail.Text = ""
        ComboEmail.Items.Clear()
        DateFecha.Value = Now
        DataGridView1.Rows.Clear()
        TextObservaciones.Text = ""
        ButtonBuscarProveedor.Focus()
    End Sub
    Private Sub limpiar2()
        TextIdProducto.Text = ""
        TextProducto.Text = ""
        TextDetalle.Text = ""
        TextCantidad.Text = ""
        ComboUnidad.Text = ""
        ComboPresentacion.Text = ""
        TextPrecio.Text = ""
        ComboMoneda.SelectedItem = Nothing
        ComboMoneda.Text = ""
        TextPrecioAnterior.Text = ""
        ComboMonedaAnterior.SelectedItem = Nothing
        ComboMonedaAnterior.Text = ""
        TextIdLinea.Text = ""
        ButtonBuscarProducto.Focus()
    End Sub

    Private Sub guardar()
        If TextProveedor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el proveedor", MsgBoxStyle.Exclamation, "Atención") : ButtonBuscarProveedor.Focus() : Exit Sub
        Dim proveedor As Integer = TextIdProveedor.Text.Trim
        Dim email As String = ""
        If ComboEmail.Text <> "" Then
            email = ComboEmail.Text
        End If
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim usuariocreador As Integer = Usuario.ID
        Dim usuarioautoriza As Integer = -1
        Dim autoriza As Integer = 0
        Dim enviado As Integer = 0
        Dim aceptado As Integer = 0
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim usuariorecibe As Integer = -1
        Dim anulada As Integer = 0
        Dim cotizacion As Long = 0
        If idcotizacion <> 0 Then
            cotizacion = idcotizacion
        End If
        If TextId.Text <> "" Then
            Dim c As New dCompras
            Dim id As Long = TextId.Text.Trim
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.ID = id
            c.PROVEEDOR = proveedor
            c.EMAIL = email
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.USUARIOAUTORIZA = usuarioautoriza
            c.FECHAAUTORIZA = fec
            c.AUTORIZA = autoriza
            c.ENVIADO = enviado
            c.FECHARECIBO = fec
            c.ACEPTADO = aceptado
            c.OBSERVACIONES = observaciones
            c.USUARIORECIBE = usuariorecibe
            c.ANULADA = anulada
            c.COTIZACION = cotizacion
            If (c.modificar(Usuario)) Then
                If cotizacion <> 0 Then
                    Dim cot As New dCotizacion
                    cot.ID = cotizacion
                    cot.marcarasociada(Usuario)
                End If
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar2()
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim c As New dCompras
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.PROVEEDOR = proveedor
            c.EMAIL = email
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.USUARIOAUTORIZA = usuarioautoriza
            c.FECHAAUTORIZA = fec
            c.AUTORIZA = autoriza
            c.ENVIADO = enviado
            c.FECHARECIBO = fec
            c.ACEPTADO = aceptado
            c.OBSERVACIONES = observaciones
            c.USUARIORECIBE = usuariorecibe
            c.ANULADA = anulada
            c.COTIZACION = cotizacion
            If (c.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'buscarultimoid()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonBuscarProveedor_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProveedor.Click
        Dim v As New FormBuscarProveedor
        v.ShowDialog()
        If Not v.Proveedor Is Nothing Then
            Dim pro As dProveedores = v.Proveedor
            TextIdProveedor.Text = pro.ID
            TextProveedor.Text = pro.NOMBRE
            TextIdProducto.Focus()
            guardarcabezal()
            If pro.EMAIL <> "" Then
                ComboEmail.Enabled = True
                ComboEmail.Items.Add(pro.EMAIL)
                ComboEmail.Text = pro.EMAIL
            End If
            If pro.EMAIL2 <> "" Then
                ComboEmail.Items.Add(pro.EMAIL2)
            End If
            If pro.EMAIL3 <> "" Then
                ComboEmail.Items.Add(pro.EMAIL3)
            End If
        End If
    End Sub

    Private Sub ButtonBuscarProducto_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProducto.Click
        Dim v As New FormBuscarProducto
        v.ShowDialog()
        If Not v.Producto Is Nothing Then
            Dim pro As dProductos = v.Producto
            TextIdProducto.Text = pro.ID
            TextProducto.Text = pro.NOMBRE
            TextDetalle.Text = pro.DETALLE
            'Dim uni As New dUnidades
            'ComboUnidad.SelectedItem = Nothing
            'For Each uni In ComboUnidad.Items
            '    If uni.ID = pro.UNIDAD Then
            '        ComboUnidad.SelectedItem = uni
            '        Exit For
            '    End If
            'Next
            buscarultimacompra()
            TextCantidad.Focus()
        End If
    End Sub
    Private Sub buscarultimacompra()
        Dim c As New dCompras
        Dim lc As New dLineaCompra
        Dim idproducto As Integer = TextIdProducto.Text.Trim
        lc.PRODUCTO = idproducto
        lc = lc.buscarultimacompra()
        If Not lc Is Nothing Then
            TextPrecioAnterior.Text = lc.PRECIO
            If lc.MONEDA = 0 Then
                ComboMonedaAnterior.Text = "$"
            ElseIf lc.MONEDA = 1 Then
                ComboMonedaAnterior.Text = "U$S"
            End If
            c.ID = lc.IDCOMPRA
            c = c.buscar
            If Not c Is Nothing Then
                DateUltimaCompra.Value = c.FECHARECIBO
            End If
        End If

    End Sub
    Private Sub ButtonAgregar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        agregarlinea()
    End Sub

    Private Sub ButtonGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim lc As New dLineaCompra
            id = row.Cells("Id").Value
            lc.ID = id
            lc.eliminar(Usuario)
            listarlineas()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Editar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim lc As New dLineaCompra
            id = row.Cells("Id").Value
            lc.ID = id
            lc = lc.buscar
            If Not lc Is Nothing Then
                TextIdLinea.Text = lc.ID
                TextIdProducto.Text = lc.PRODUCTO
                Dim p As New dProductos
                p.ID = lc.PRODUCTO
                p = p.buscar
                If Not p Is Nothing Then
                    TextProducto.Text = p.NOMBRE
                    TextDetalle.Text = p.DETALLE
                End If
                TextCantidad.Text = lc.CANTIDAD
                Dim uni As New dUnidades
                uni.ID = lc.UNIDAD
                uni = uni.buscar
                If Not uni Is Nothing Then
                    ComboUnidad.Text = uni.NOMBRE
                End If
                Dim pre As New dPresentacionUnidades
                pre.ID = lc.PRESENTACION
                pre = pre.buscar
                If Not pre Is Nothing Then
                    ComboPresentacion.Text = pre.NOMBRE
                End If
                TextPrecio.Text = lc.PRECIO
                If lc.MONEDA = 0 Then
                    ComboMoneda.Text = "$"
                ElseIf lc.MONEDA = 1 Then
                    ComboMoneda.Text = "U$S"
                End If
                TextPrecioAnterior.Text = lc.PRECIOANT
                If lc.MONEDAANT = 0 Then
                    ComboMonedaAnterior.Text = "$"
                ElseIf lc.MONEDAANT = 1 Then
                    ComboMonedaAnterior.Text = "U$S"
                End If
                If lc.FECHAPRECIOANT <> "00:00:00" Then
                    DateUltimaCompra.Value = lc.FECHAPRECIOANT
                End If
            End If
        End If
    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNueva.Click
        limpiar2()
        limpiar()

    End Sub

    Private Sub ButtonAsociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAsociar.Click
        Dim v As New FormAsociar(Usuario)
        v.ShowDialog()
        If Not v.Cotizacion Is Nothing Then
            Dim cot As dCotizacion = v.Cotizacion
            If Not cot Is Nothing Then
                idcotizacion = cot.ID
                TextIdProveedor.Text = cot.PROVEEDOR
                Dim p As New dProveedores
                p.ID = cot.PROVEEDOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProveedor.Text = p.NOMBRE
                    guardarcabezal()
                    If p.EMAIL <> "" Then
                        ComboEmail.Enabled = True
                        ComboEmail.Items.Add(p.EMAIL)
                        ComboEmail.Text = p.EMAIL
                    End If
                    If p.EMAIL2 <> "" Then
                        ComboEmail.Items.Add(p.EMAIL2)
                    End If
                    If p.EMAIL3 <> "" Then
                        ComboEmail.Items.Add(p.EMAIL3)
                    End If

                End If
                agregarlineacotizacion()
                cot.marcarasociada(Usuario)
            End If

        End If
    End Sub
End Class