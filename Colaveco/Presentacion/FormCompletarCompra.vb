Public Class FormCompletarCompra
#Region "Atributos"
    Private _usuario As dUsuario
    Private lineacompra As Long
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
        cargarLocaciones()
        cargarMonedas()
        TextLote.Text = "sin lote"
        buscarlineacompra()
    End Sub

#End Region
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
            TextId.Text = lc.ID
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
            lc.ID = id
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
                limpiar()
                Me.Close()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
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
End Class