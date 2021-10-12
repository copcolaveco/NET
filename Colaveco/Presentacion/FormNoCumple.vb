Public Class FormNoCumple
#Region "Atributos"
    Private _usuario As dUsuario
    Private idlineacomp As Long = 0
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
    Public Sub New(ByVal u As dUsuario, ByVal idlinea As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        idlineacomp = idlinea
        limpiar()
        TextIdLineaCompra.Text = idlineacomp
        siexiste()

    End Sub

#End Region
    Private Sub siexiste()
        Dim nc As New dNoCumple
        nc.IDLINEACOMPRA = idlineacomp
        nc = nc.buscarxlineacompra
        If Not nc Is Nothing Then
            TextId.Text = nc.ID
            TextIdLineaCompra.Text = nc.IDLINEACOMPRA
            DateFecha.Value = nc.FECHA
            If nc.PUNTUALIDAD = 1 Then
                CheckPuntualidad.Checked = True
            End If
            If nc.CALIDAD = 1 Then
                CheckCalidad.Checked = True
            End If
            If nc.CANTIDAD = 1 Then
                CheckCantidad.Checked = True
            End If
            If nc.PRECIO = 1 Then
                CheckPrecio.Checked = True
            End If
            If nc.FACTURA = 1 Then
                CheckFactura.Checked = True
            End If
            TextDescripcion.Text = nc.DESCRIPCION
        End If
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        If TextIdLineaCompra.Text.Trim.Length = 0 Then MsgBox("No existe la línea de compra", MsgBoxStyle.Exclamation, "Atención") : TextIdLineaCompra.Focus() : Exit Sub
        Dim idlineacompra As Long = TextIdLineaCompra.Text
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim puntualidad As Integer = 0
        If CheckPuntualidad.Checked = True Then
            puntualidad = 1
        End If
        Dim calidad As Integer = 0
        If CheckCalidad.Checked = True Then
            calidad = 1
        End If
        Dim cantidad As Integer = 0
        If CheckCantidad.Checked = True Then
            cantidad = 1
        End If
        Dim precio As Integer = 0
        If CheckPrecio.Checked = True Then
            precio = 1
        End If
        Dim factura As Integer = 0
        If CheckFactura.Checked = True Then
            factura = 1
        End If
        Dim descripcion As String = ""
        If TextDescripcion.Text <> "" Then
            descripcion = TextDescripcion.Text
        End If
        Dim usu As Integer = Usuario.ID
        If TextId.Text <> "" Then
            Dim nc As New dNoCumple
            Dim id As Long = TextId.Text.Trim
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            nc.ID = id
            nc.IDLINEACOMPRA = idlineacompra
            nc.FECHA = fec
            nc.PUNTUALIDAD = puntualidad
            nc.CALIDAD = calidad
            nc.CANTIDAD = cantidad
            nc.PRECIO = precio
            nc.FACTURA = factura
            nc.DESCRIPCION = descripcion
            nc.USUARIO = usu
            If (nc.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                marcarnocumple()
                limpiar()
                Me.Close()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim nc As New dNoCumple
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            nc.IDLINEACOMPRA = idlineacompra
            nc.FECHA = fec
            nc.PUNTUALIDAD = puntualidad
            nc.CALIDAD = calidad
            nc.CANTIDAD = cantidad
            nc.PRECIO = precio
            nc.FACTURA = factura
            nc.DESCRIPCION = descripcion
            nc.USUARIO = usu
            If (nc.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                marcarnocumple()
                limpiar()
                Me.Close()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextIdLineaCompra.Text = ""
        DateFecha.Value = Now
        CheckPuntualidad.Checked = False
        CheckCalidad.Checked = False
        CheckCantidad.Checked = False
        CheckPrecio.Checked = False
        CheckFactura.Checked = False
        TextDescripcion.Text = ""
    End Sub
    Private Sub marcarnocumple()
        Dim lc As New dLineaCompra
        lc.ID = idlineacomp
        lc.marcarnocumple(Usuario)
    End Sub
End Class