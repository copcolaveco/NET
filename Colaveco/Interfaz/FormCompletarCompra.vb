Public Class FormCompletarCompra
#Region "Atributos"
    Private _usuario As dUsuario
    Private lineacompra As Long
    Private cantidadoriginal As Double = 0
    Private ultimoid As Long = 0
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
    Public Sub New(ByVal u As dUsuario, ByVal id As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        lineacompra = id
        DateRecibido.Value = Now
        cargarUnidades()
        cargarLocaciones()
        cargarMonedas()
        TextLote.Text = "sin lote"
        buscarlineacompra()
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
    Public Sub cargarLocaciones()
        Dim l As New dLocacion
        Dim lista As New ArrayList
        lista = l.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    ComboLocacion.Items.Add(l)
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
                Next
            End If
        End If
    End Sub
    Private Sub buscarlineacompra()
        Dim lc As New dLineaCompra
        lc.ID = lineacompra
        lc = lc.buscar
        If Not lc Is Nothing Then
            TextFactura.Text = lc.FACTURA
            TextId.Text = lc.ID
            Dim p As New dProductos
            p.ID = lc.PRODUCTO
            p = p.buscar
            If Not p Is Nothing Then
                TextCodigo.Text = p.CODIGO
                TextProducto.Text = p.NOMBRE
            End If
            cantidadoriginal = lc.CANTIDAD
            TextCantidad.Text = lc.CANTIDAD
            Dim u As dUnidades
            ComboUnidad.SelectedItem = Nothing
            For Each u In ComboUnidad.Items
                If u.ID = p.UNIDAD Then
                    ComboUnidad.SelectedItem = u
                    Exit For
                End If
            Next
            If lc.LOTE <> "" Then
                TextLote.Text = lc.LOTE
            End If
            DateVencimiento.Value = lc.VENCIMIENTO
            Dim l As New dLocacion
            l.ID = lc.LOCACION
            l = l.buscar
            If Not l Is Nothing Then
                ComboLocacion.Text = l.NOMBRE
            End If
            TextPrecio.Text = lc.PRECIO
            Dim m As New dMoneda
            m.ID = lc.MONEDA
            m = m.buscar
            If Not m Is Nothing Then
                ComboMoneda.Text = m.SIMBOLO
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim fecharecibido As Date = DateRecibido.Value.ToString("yyyy-MM-dd")
        Dim fecrec As String
        fecrec = Format(fecharecibido, "yyyy-MM-dd")
        Dim factura As String = ""
        If TextFactura.Text <> "" Then
            factura = TextFactura.Text
        End If
        Dim cantidad As Double = 0
        cantidad = TextCantidad.Text.Trim
        Dim unidad As dUnidades = CType(ComboUnidad.SelectedItem, dUnidades)
        Dim lote As String = ""
        If TextLote.Text <> "" Then
            lote = TextLote.Text
        End If
        Dim fechavenc As Date = DateVencimiento.Value.ToString("yyyy-MM-dd")
        Dim locacion As dLocacion = CType(ComboLocacion.SelectedItem, dLocacion)
        Dim precio As Double = 0
        If TextPrecio.Text <> "" Then
            precio = TextPrecio.Text
        End If
        Dim moneda As dMoneda = CType(ComboMoneda.SelectedItem, dMoneda)
        If TextId.Text <> "" Then
            Dim lc As New dLineaCompra
            Dim id As Long = TextId.Text.Trim
            Dim fecven As String
            fecven = Format(fechavenc, "yyyy-MM-dd")
            lc.RECIBIDO = fecrec
            lc.FACTURA = factura
            lc.ID = id
            lc.CANTIDAD = cantidad
            lc.LOTE = lote
            lc.VENCIMIENTO = fecven
            If Not locacion Is Nothing Then
                lc.LOCACION = locacion.ID
            End If
            lc.PRECIO = precio
            If Not moneda Is Nothing Then
                lc.MONEDA = moneda.ID
            End If
            lc.FECHAAPERTURA = fecven
            lc.FECHACONSUMIDO = fecven
            lc.FECHADESCARTADO = fecven
            If (lc.modificar2(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                If CheckCambiarCantidad.Checked = True Then
                    nuevacompra()
                    MsgBox("Se creó una nueva compra con la cantidad pendiente.", MsgBoxStyle.Information, "Atención")
                End If
                limpiar()
                Me.Close()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub nuevacompra()
        Dim nuevacantidad As Double = 0
        Dim cantidad As Double = 0
        cantidad = TextCantidad.Text
        nuevacantidad = cantidadoriginal - cantidad
        If nuevacantidad > 0 Then
            Dim lc As New dLineaCompra
            lc.ID = lineacompra
            lc = lc.buscar
            If Not lc Is Nothing Then
                Dim c As New dCompras
                c.ID = lc.IDCOMPRA
                c = c.buscar
                If Not c Is Nothing Then
                    Dim c2 As New dCompras
                    Dim fecha As Date = Now
                    Dim fec As String
                    fec = Format(fecha, "yyyy-MM-dd")
                    c2.PROVEEDOR = c.PROVEEDOR
                    c2.EMAIL = c.EMAIL
                    c2.FECHA = fec
                    c2.USUARIOCREADOR = Usuario.ID
                    c2.USUARIOAUTORIZA = c.USUARIOAUTORIZA
                    c2.FECHAAUTORIZA = fec
                    c2.AUTORIZA = c.AUTORIZA
                    c2.ENVIA = c.ENVIA
                    c2.ENVIADO = c.ENVIADO
                    c2.FECHARECIBO = fec
                    c2.ACEPTADO = 0
                    c2.OBSERVACIONES = c.OBSERVACIONES
                    c2.USUARIORECIBE = -1
                    c2.ANULADA = 0
                    c2.COTIZACION = c.COTIZACION
                    If (c2.guardar(Usuario)) Then
                        ' MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                        buscarultimoid()
                        Dim lc2 As New dLineaCompra
                        lc2.ID = lineacompra
                        lc2 = lc2.buscar
                        If Not lc2 Is Nothing Then
                            Dim lc3 As New dLineaCompra
                            lc3.IDCOMPRA = ultimoid
                            lc3.PRODUCTO = lc2.PRODUCTO
                            lc3.UNIDAD = lc2.UNIDAD
                            lc3.CANTIDAD = nuevacantidad
                            lc3.PRESENTACION = lc2.PRESENTACION
                            lc3.PRECIOANT = lc2.PRECIOANT
                            lc3.MONEDAANT = lc2.MONEDAANT
                            lc3.FECHAPRECIOANT = lc2.FECHAPRECIOANT
                            lc3.LOTE = ""
                            lc3.VENCIMIENTO = fec
                            lc3.LOCACION = 0
                            lc3.PRECIO = lc2.PRECIO
                            lc3.MONEDA = lc2.MONEDA
                            lc3.NOCUMPLE = 0
                            If (lc3.guardar(Usuario)) Then
                                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                            End If
                        End If
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub buscarultimoid()
        Dim c As New dCompras
        Dim id As Long = 0
        c = c.buscarultimoid()
        If Not c Is Nothing Then
            ultimoid = c.ID
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextLote.Text = ""
        DateVencimiento.Value = Now
        ComboLocacion.Text = ""
        TextPrecio.Text = ""
        ComboMoneda.Text = ""
    End Sub

    Private Sub CheckCambiarCantidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCambiarCantidad.CheckedChanged
        habilitacantidad()
        cantidadoriginal = TextCantidad.Text.Trim
    End Sub
    Private Sub habilitacantidad()
        If CheckCambiarCantidad.Checked = True Then
            TextCantidad.Enabled = True
            TextCantidad.ReadOnly = False
        Else
            TextCantidad.Enabled = False
            TextCantidad.ReadOnly = True
        End If
    End Sub

    Private Sub TextCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextCantidad.LostFocus
        CheckCambiarCantidad.Enabled = False
    End Sub
End Class