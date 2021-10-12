Public Class FormPedidoFrascos
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Private _pedidos As dPedidos
    Public Property Pedidos() As dPedidos
        Get
            Return _pedidos
        End Get
        Set(ByVal value As dPedidos)
            _pedidos = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarComboAgencia()
        cargarComboTecnicos()
        cargarLista()
        limpiar()
    End Sub


    Public Sub cargarLista()
        Dim p As New dPedidos
        Dim lista As New ArrayList
        lista = p.listar
        ListPedidos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListPedidos().Items.Add(p)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        DateFechaposEnvio.Value = Now
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        TextDireccion.Text = ""
        TextTelefono.Text = ""
        TextEmail.Text = ""
        ComboTecnico.Text = ""
        ComboAgencia.Text = ""
        TextRC_compos.Text = ""
        TextResponsable.Text = ""
        TextAgua.Text = ""
        TextSangre.Text = ""
        TextEsteriles.Text = ""
        TextOtros.Text = ""
        TextObservaciones.Text = ""
        TextFactura1.Text = ""
        TextF1.Text = ""
        TextCantidad1.Text = ""
        TextFactura2.Text = ""
        TextF2.Text = ""
        TextCantidad2.Text = ""
        TextFactura3.Text = ""
        TextF3.Text = ""
        TextCantidad3.Text = ""
        DateFecha.Focus()
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
        Dim t As New dTecnicos
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
    
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fechaposenvio As Date = DateFechaposEnvio.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim productor As Long = TextIdProductor.Text.Trim
        If TextDireccion.Text.Trim.Length = 0 Then MsgBox("No se ha detallado direccìón de envío", MsgBoxStyle.Exclamation, "Atención") : TextDireccion.Focus() : Exit Sub
        Dim direccion As String = TextDireccion.Text.Trim
        Dim telefono As String = TextTelefono.Text.Trim
        Dim tecnico As dTecnicos = CType(ComboTecnico.SelectedItem, dTecnicos)
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim responsable As String
        If TextResponsable.Text <> "" Then
            responsable = TextResponsable.Text.Trim
        End If
        Dim rc_compos As Integer
        Dim agua As Integer
        Dim sangre As Integer
        Dim esteriles As Integer
        Dim otros As Integer
        If TextRC_compos.Text <> "" Then
            rc_compos = TextRC_compos.Text.Trim
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
        Dim factura1 As Long
        Dim cantidad1 As Integer
        Dim factura2 As Long
        Dim cantidad2 As Integer
        Dim factura3 As Long
        Dim cantidad3 As Integer
        If TextFactura1.Text <> "" Then
            factura1 = TextFactura1.Text.Trim
        End If
        If TextCantidad1.Text <> "" Then
            cantidad1 = TextCantidad1.Text.Trim
        End If
        If TextFactura2.Text <> "" Then
            factura2 = TextFactura2.Text.Trim
        End If
        If TextCantidad2.Text <> "" Then
            cantidad2 = TextCantidad2.Text.Trim
        End If
        If TextFactura3.Text <> "" Then
            factura3 = TextFactura3.Text.Trim
        End If
        If TextCantidad3.Text <> "" Then
            cantidad3 = TextCantidad3.Text.Trim
        End If
        If Not ListPedidos Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextId.Text.Trim.Length > 0 Then
                Dim ped As New dPedidos()
                Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                Dim fecposenvio As String
                fec = Format(fecha, "yyyy-MM-dd")
                fecposenvio = Format(fechaposenvio, "yyyy-MM-dd")
                ped.ID = id
                ped.FECHA = fec
                ped.FECHAPOSENVIO = fecposenvio
                ped.IDPRODUCTOR = productor
                ped.DIRECCION = direccion
                ped.TELEFONO = telefono
                If Not tecnico Is Nothing Then
                    ped.IDTECNICO = tecnico.ID
                End If
                ped.RESPONSABLE = responsable
                ped.IDAGENCIA = agencia.ID
                ped.RC_COMPOS = rc_compos
                ped.AGUA = agua
                ped.SANGRE = sangre
                ped.ESTERILES = esteriles
                ped.OTROS = otros
                ped.OBSERVACIONES = observaciones
                ped.FACTURA1 = factura1
                ped.CANTIDAD1 = cantidad1
                ped.FACTURA2 = factura2
                ped.CANTIDAD2 = cantidad2
                ped.FACTURA3 = factura3
                ped.CANTIDAD3 = cantidad3
                If (ped.modificar(Usuario)) Then
                    MsgBox("pedido modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim ped As New dPedidos()
                'Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                Dim fecposenvio As String
                fec = Format(fecha, "yyyy-MM-dd")
                fecposenvio = Format(fechaposenvio, "yyyy-MM-dd")
                'ped.ID = id
                ped.FECHA = fec
                ped.FECHAPOSENVIO = fecposenvio
                ped.IDPRODUCTOR = productor
                ped.DIRECCION = direccion
                ped.TELEFONO = telefono
                If Not tecnico Is Nothing Then
                    ped.IDTECNICO = tecnico.ID
                End If
                ped.RESPONSABLE = responsable
                ped.IDAGENCIA = agencia.ID
                ped.RC_COMPOS = rc_compos
                ped.AGUA = agua
                ped.SANGRE = sangre
                ped.ESTERILES = esteriles
                ped.OTROS = otros
                ped.OBSERVACIONES = observaciones
                ped.FACTURA1 = factura1
                ped.CANTIDAD1 = cantidad1
                ped.FACTURA2 = factura2
                ped.CANTIDAD2 = cantidad2
                ped.FACTURA3 = factura3
                ped.CANTIDAD3 = cantidad3
                If (ped.guardar(Usuario)) Then
                    MsgBox("Pedido guardado", MsgBoxStyle.Information, "Atención")
                    limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        cargarLista()
    End Sub
    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListPedidos.SelectedItem Is Nothing Then
            If MsgBox("El pedido será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim p As New dPedidos
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

 
    Private Sub TextIdProductor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextIdProductor.LostFocus
        'If Not ListSubsidios.SelectedItems.Count = 1 Then
        If Not TextIdProductor.Text = "" Then
            Dim p As New dProductor
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE

                If p.MOROSO = 1 Then
                    MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
                    TextIdProductor.Text = ""
                    TextProductor.Text = ""
                    ComboTecnico.SelectedItem = Nothing
                    Exit Sub
                End If

            Else
                MsgBox("El productor no existe")
                TextIdProductor.Text = ""
                TextIdProductor.Focus()
            End If
        End If
    End Sub
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            If pro.CONTRATO = 0 Then
                MsgBox("El cliente no tiene contrato firmado.")
            End If
            TextIdProductor.Text = pro.ID
            TextProductor.Text = pro.NOMBRE
            TextDireccion.Text = pro.ENVIO
            TextTelefono.Text = pro.TELEFONO
            TextEmail.Text = pro.EMAIL1
            ComboTecnico.SelectedItem = Nothing
            Dim t As dTecnicos
            For Each t In ComboTecnico.Items
                If t.ID = pro.TECNICO Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = pro.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            'Controla si debe cajas **************************************
            Dim ec As New dEnvioCajas
            Dim lista As New ArrayList
            Dim idpro As Long = 0
            Dim listacajas As String = ""
            idpro = pro.ID
            lista = ec.listarxcliente(idpro)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each ec In lista
                        listacajas = listacajas & ec.IDCAJA & "  "
                    Next
                End If
            End If
            If listacajas <> "" Then
                MsgBox("El cliente debe las siguientes cajas: " & listacajas)
            End If
            'Controla que el cliente no tenga deuda atrasada*************************************
            If pro.MOROSO = 1 Then
                MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
                TextIdProductor.Text = ""
                TextProductor.Text = ""
                ComboTecnico.SelectedItem = Nothing
                Exit Sub
            End If

            TextResponsable.Focus()
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarLista()
    End Sub

    Private Sub ListPedidos_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPedidos.SelectedIndexChanged
        limpiar()
        If ListPedidos.SelectedItems.Count = 1 Then
            Dim ped As dPedidos = CType(ListPedidos.SelectedItem, dPedidos)
            TextId.Text = ped.ID
            DateFecha.Value = ped.FECHA
            DateFechaposEnvio.Value = ped.FECHAPOSENVIO
            Dim p As New dProductor
            TextIdProductor.Text = ped.IDPRODUCTOR
            Dim id As Long = CType(TextIdProductor.Text, Long)
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE
                TextEmail.Text = p.EMAIL1
            End If
            TextDireccion.Text = ped.DIRECCION
            TextTelefono.Text = ped.TELEFONO
            Dim t As dTecnicos
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
            TextResponsable.Text = ped.RESPONSABLE
            TextRC_compos.Text = ped.RC_COMPOS
            TextAgua.Text = ped.AGUA
            TextSangre.Text = ped.SANGRE
            TextEsteriles.Text = ped.ESTERILES
            TextOtros.Text = ped.OTROS
            TextObservaciones.Text = ped.OBSERVACIONES
            TextFactura1.Text = ped.FACTURA1
            If Not TextFactura1.Text = "0" Then
                p.ID = Val(TextFactura1.Text)
                p = p.buscar
                If Not p Is Nothing Then
                    TextF1.Text = p.NOMBRE
                End If
            End If
            TextCantidad1.Text = ped.CANTIDAD1
            TextFactura2.Text = ped.FACTURA2
            If Not TextFactura2.Text = "0" Then
                p.ID = Val(TextFactura2.Text)
                p = p.buscar
                If Not p Is Nothing Then
                    TextF2.Text = p.NOMBRE
                End If
            End If
            TextCantidad2.Text = ped.CANTIDAD2
            TextFactura3.Text = ped.FACTURA3
            If Not TextFactura3.Text = "0" Then
                p.ID = Val(TextFactura3.Text)
                p = p.buscar
                If Not p Is Nothing Then
                    TextF3.Text = p.NOMBRE
                End If
            End If
            TextCantidad3.Text = ped.CANTIDAD3
            DateFecha.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextFactura1.Text = pro.ID
            TextF1.Text = pro.NOMBRE
            TextCantidad1.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextFactura2.Text = pro.ID
            TextF2.Text = pro.NOMBRE
            TextCantidad2.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextFactura3.Text = pro.ID
            TextF3.Text = pro.NOMBRE
            TextCantidad3.Focus()
        End If
    End Sub
    Private Sub actualizardireccion()
        Dim p As New dProductor
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim env As String = TextDireccion.Text.Trim
        p.ID = id
        p.actualizardireccion(p.ID, env, Usuario)
    End Sub
    Private Sub actualizartelefono()
        Dim p As New dProductor
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim tel As String = TextTelefono.Text.Trim
        p.ID = id
        p.actualizartelefono(p.ID, tel, Usuario)
    End Sub
    Private Sub actualizartecnico()
        Dim p As New dProductor
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim tecnico As dTecnicos = CType(ComboTecnico.SelectedItem, dTecnicos)
        Dim tec As Long = tecnico.ID
        p.ID = id
        p.actualizartecnico(p.ID, tec, Usuario)
    End Sub
    Private Sub actualizaragencia()
        Dim p As New dProductor
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim age As Long = agencia.ID
        p.ID = id
        p.actualizaragencia(p.ID, age, Usuario)
    End Sub
    Private Sub actualizaremail()
        Dim p As New dProductor
        Dim id As Integer = TextIdProductor.Text.Trim
        Dim email As String = TextEmail.Text.Trim
        p.ID = id
        p.actualizarmail(p.ID, email, Usuario)
    End Sub

    Private Sub TextDireccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextDireccion.LostFocus
        actualizardireccion()
    End Sub

    Private Sub TextTelefono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextTelefono.LostFocus
        actualizartelefono()
    End Sub

    Private Sub ComboTecnico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboTecnico.LostFocus
        actualizartecnico()
    End Sub

    Private Sub ComboAgencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboAgencia.LostFocus
        actualizaragencia()
    End Sub

    
    Private Sub TextTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextTelefono.TextChanged

    End Sub

    Private Sub TextEmail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmail.LostFocus
        actualizaremail()
    End Sub

    Private Sub TextEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextEmail.TextChanged

    End Sub
End Class