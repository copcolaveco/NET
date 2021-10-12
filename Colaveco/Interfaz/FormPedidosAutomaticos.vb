Public Class FormPedidosAutomaticos
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Private _pedidosauto As dPedidosAuto
    Public Property PedidosAuto() As dPedidosAuto
        Get
            Return _pedidosauto
        End Get
        Set(ByVal value As dPedidosAuto)
            _pedidosauto = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarComboConvenios()
        cargarComboAgencia()
        cargarComboTecnicos()
        cargarLista()
        limpiar()
    End Sub
    Public Sub cargarComboConvenios()
        Dim c As New dConvenio
        Dim lista As New ArrayList
        lista = c.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboConvenios.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista()
        Dim p As New dPedidosAuto
        Dim lista As New ArrayList
        lista = p.listar
        ListPedidosAutomaticos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListPedidosAutomaticos().Items.Add(p)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextDia.Text = ""
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        ComboConvenios.Text = ""
        ComboConvenios.SelectedItem = Nothing
        TextDireccion.Text = ""
        TextTelefono.Text = ""
        ComboTecnico.Text = ""
        ComboAgencia.Text = ""
        TextRC_compos.Text = ""
        TextAgua.Text = ""
        TextSangre.Text = ""
        TextEsteriles.Text = ""
        TextOtros.Text = ""
        TextObservaciones.Text = ""
        TextIdFactura.Text = ""
        TextFactura.Text = ""
        CheckSuspendido.Checked = False
        TextDia.Focus()

    End Sub

    Public Sub cargarComboAgencia()
        Dim et As New dEmpresaT
        Dim lista As New ArrayList
        lista = et.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each et In lista
                    ComboAgencia.Items.Add(et)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTecnicos()
        Dim t As New dCliente
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTecnico.Items.Add(t)
                Next
            End If
        End If
    End Sub
    Private Sub ButtonBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
            TextDireccion.Text = cli.ENVIO
            TextTelefono.Text = cli.TELEFONO1
            ComboTecnico.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico.Items
                If t.ID = cli.TECNICO1 Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = cli.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            TextRc_Compos.Focus()
        End If
    End Sub

    Private Sub ButtonBuscarProductor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor2.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdFactura.Text = cli.ID
            TextFactura.Text = cli.NOMBRE
            ButtonGuardar.Focus()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim dia As Integer = TextDia.Text.Trim
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim productor As Long = TextIdProductor.Text.Trim
        If TextDireccion.Text.Trim.Length = 0 Then MsgBox("No se ha detallado direccìón de envío", MsgBoxStyle.Exclamation, "Atención") : TextDireccion.Focus() : Exit Sub
        Dim direccion As String = TextDireccion.Text.Trim
        Dim telefono As String = TextTelefono.Text.Trim
        Dim tecnico As dCliente = CType(ComboTecnico.SelectedItem, dCliente)
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim rc_compos As Integer
        Dim agua As Integer
        Dim sangre As Integer
        Dim esteriles As Integer
        Dim otros As Integer
        If TextRc_Compos.Text <> "" Then
            rc_compos = TextRc_Compos.Text.Trim
        End If
        If TextAgua.Text <> "" Then
            agua = TextAgua.Text.Trim
        End If
        If TextSangre.Text <> "" Then
            sangre = TextSangre.Text.Trim
        End If
        If TextEsteriles.Text <> "" Then
            esteriles = TextEsteriles.Text.Trim
        End If
        If TextOtros.Text <> "" Then
            otros = TextOtros.Text.Trim
        End If
        Dim observaciones As String = TextObservaciones.Text.Trim
        Dim factura As Long
        If TextFactura.Text <> "" Then
            factura = TextFactura.Text.Trim
        End If
        Dim convenio As dConvenio = CType(ComboConvenios.SelectedItem, dConvenio)
        Dim idconv As Integer = 0
        If Not convenio Is Nothing Then
            idconv = convenio.ID
        End If
        Dim suspendido As Integer = 0
        If CheckSuspendido.Checked = True Then
            suspendido = 1
        End If
        If Not ListPedidosAutomaticos Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextId.Text.Trim.Length > 0 Then
                Dim ped As New dPedidosAuto()
                Dim id As Long = CType(TextId.Text.Trim, Long)
                ped.ID = id
                ped.DIA = dia
                ped.IDPRODUCTOR = productor
                ped.DIRECCION = direccion
                ped.TELEFONO = telefono
                If Not tecnico Is Nothing Then
                    ped.IDTECNICO = tecnico.ID
                End If
                If Not agencia Is Nothing Then
                    ped.IDAGENCIA = agencia.ID
                End If
                ped.RC_COMPOS = rc_compos
                ped.AGUA = agua
                ped.SANGRE = sangre
                ped.ESTERILES = esteriles
                ped.OTROS = otros
                ped.OBSERVACIONES = observaciones
                ped.FACTURA = factura
                ped.ENVIADO = 0
                ped.CONVENIO = idconv
                ped.SUSPENDIDO = suspendido
                If (ped.modificar(Usuario)) Then
                    MsgBox("pedido modificado", MsgBoxStyle.Information, "Atención")
                    limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
                cargarLista()
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim ped As New dPedidosAuto()
                ped.DIA = dia
                ped.IDPRODUCTOR = productor
                ped.DIRECCION = direccion
                ped.TELEFONO = telefono
                If Not tecnico Is Nothing Then
                    ped.IDTECNICO = tecnico.ID
                End If
                If Not agencia Is Nothing Then
                    ped.IDAGENCIA = agencia.ID
                End If
                ped.RC_COMPOS = rc_compos
                ped.AGUA = agua
                ped.SANGRE = sangre
                ped.ESTERILES = esteriles
                ped.OTROS = otros
                ped.OBSERVACIONES = observaciones
                ped.FACTURA = factura
                ped.ENVIADO = 0
                ped.CONVENIO = idconv
                ped.SUSPENDIDO = suspendido
                If (ped.guardar(Usuario)) Then
                    MsgBox("Pedido guardado", MsgBoxStyle.Information, "Atención")
                    limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        cargarLista()
    End Sub

    Private Sub ListPedidosAutomaticos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPedidosAutomaticos.SelectedIndexChanged
        limpiar()
        If ListPedidosAutomaticos.SelectedItems.Count = 1 Then
            Dim ped As dPedidosAuto = CType(ListPedidosAutomaticos.SelectedItem, dPedidosAuto)
            TextId.Text = ped.ID
            TextDia.Text = ped.DIA
            Dim p As New dCliente
            TextIdProductor.Text = ped.IDPRODUCTOR
            Dim id As Long = CType(TextIdProductor.Text, Long)
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE
                
            End If
            TextDireccion.Text = ped.DIRECCION
            TextTelefono.Text = ped.TELEFONO
            Dim t As dCliente
            ComboTecnico.SelectedItem = Nothing
            For Each t In ComboTecnico.Items
                If t.ID = ped.IDTECNICO Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            Dim et As dEmpresaT
            ComboAgencia.SelectedItem = Nothing
            For Each et In ComboAgencia.Items
                If et.ID = ped.IDAGENCIA Then
                    ComboAgencia.SelectedItem = et
                    Exit For
                End If
            Next
            TextRc_Compos.Text = ped.RC_COMPOS
            TextAgua.Text = ped.AGUA
            TextSangre.Text = ped.SANGRE
            TextEsteriles.Text = ped.ESTERILES
            TextOtros.Text = ped.OTROS
            TextObservaciones.Text = ped.OBSERVACIONES
            TextIdFactura.Text = ped.FACTURA
            If Not TextIdFactura.Text = "" Then
                p.ID = Val(TextIdFactura.Text)
                p = p.buscar
                If Not p Is Nothing Then
                    TextFactura.Text = p.NOMBRE
                End If
            End If
            Dim c As dConvenio
            ComboConvenios.SelectedItem = Nothing
            For Each c In ComboConvenios.Items
                If c.ID = ped.CONVENIO Then
                    ComboConvenios.SelectedItem = c
                    Exit For
                End If
            Next
            If ped.SUSPENDIDO = 0 Then
                CheckSuspendido.Checked = False
            Else
                CheckSuspendido.Checked = True
            End If
            TextDia.Focus()
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListPedidosAutomaticos.SelectedItem Is Nothing Then
            If MsgBox("El pedido será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim p As New dPedidosAuto
                Dim id As Long = CType(TextId.Text, Long)
                p.ID = id
                If (p.eliminar(Usuario)) Then
                    MsgBox("Pedido eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub
End Class